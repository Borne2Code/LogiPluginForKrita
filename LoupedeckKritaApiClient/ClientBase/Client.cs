using System.Net.Sockets;
using System.Net;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Threading;
using System.Security.AccessControl;

namespace LoupedeckKritaApiClient.ClientBase
{
    public class Client : IAsyncDisposable
    {
        private Socket? client;
        private readonly KritaInstance _kritaInstance;
        private readonly Canvas _currentCanvas;
        private readonly Document _currentDocument;
        private readonly SemaphoreSlim _semaphore = new(1, 1);
        public Client()
        {
            _kritaInstance = new KritaInstance()
            {
                Client = this,
                PrimitiveName = "kritaInstance"
            };
            _currentCanvas = new Canvas()
            {
                Client = this,
                PrimitiveName = "currentCanvas"
            };
            _currentDocument = new Document()
            {
                Client = this,
                PrimitiveName = "currentDocument"
            };
        }

        public async Task Connect()
        {
            IPEndPoint ipEndPoint = new(IPAddress.Parse("127.0.0.1"), 1247);

            client = new(
                ipEndPoint.AddressFamily,
                SocketType.Stream,
                ProtocolType.Tcp);
            await client.ConnectAsync(ipEndPoint);
        }

        public async Task Close()
        {
            client?.Close(100);
        }

        internal Task<ReturnValue> ExecuteCall(string objectName, string methodName, params object[] parameters)
        {
            return InternalExecuteCall("E", objectName, methodName, parameters);
        }

        private async Task<ReturnValue> InternalExecuteCall(string action, string? objectName = null, string? methodName = null, params object[] parameters)
        {
            if (client == null)
            {
                throw new Exception("Please connect before calling a method");
            }

            await _semaphore.WaitAsync();

            try
            {
                var parametersListString = "[" + string.Join(',', parameters
                    .Select((val) =>
                        {
                            string type;
                            object value;

                            switch (val.GetType().Name)
                            {
                                case "String":
                                    {
                                        type = "str";
                                        value = $"\"{val}\"";
                                    }; break;
                                case "Int32":
                                    {
                                        type = "int";
                                        value = $"{val}";
                                    }; break;
                                case "Single":
                                    {
                                        type = "float";
                                        value = $"{val?.ToString()?.Replace(',', '.')}";
                                    }; break;
                                case "Boolean":
                                    {
                                        type = "bool";
                                        value = $"{val?.ToString()?.ToLower()}";
                                    }; break;
                                default:
                                    {
                                        if (val is LoupedeckClientKritaBaseClass typedVal)
                                        {
                                            type = val.GetType().Name;
                                            value = $"\"{typedVal.Reference}\"";
                                        }
                                        else
                                            throw new ArgumentException($"Unmanaged argument type: {val.GetType().Name}");
                                    }; break;
                            }

                            return $"{{\"type\":\"{type}\",\"value\":{value}}}";
                        })
                    ) + "]";

                var message = $"{{\"action\":\"{action}\"";
                if (methodName != null) message += $",\"method\":\"{methodName}\"";
                if (objectName != null) message += $",\"object\":\"{objectName}\"";
                if (parameters.Length > 0) message += $",\"parameters\":{parametersListString}";
                message += "}";
                var messageBytes = Encoding.UTF8.GetBytes(message);
                _ = await client.SendAsync(messageBytes, SocketFlags.None).ConfigureAwait(true);

                var responseBytes = new byte[1024];
                var byteCount = await client.ReceiveAsync(responseBytes, SocketFlags.None).ConfigureAwait(true);
                if (byteCount > 0)
                {
                    var sb = new StringBuilder();

                    sb.Append(Encoding.UTF8.GetString(responseBytes, 0, byteCount));

                    while (client.Available > 0)
                    {
                        byteCount = await client.ReceiveAsync(responseBytes, SocketFlags.None).ConfigureAwait(true);
                        sb.Append(Encoding.UTF8.GetString(responseBytes, 0, byteCount));
                    }

                    dynamic? response = JsonConvert.DeserializeObject(sb.ToString());

                    if (response?.result == "OK")
                        if (response.returnType.Value == "list")
                        {
                            return new ReturnValue
                            {
                                Type = response.returnType.Value,
                                Value = ((JArray)response.returnValue).Select(node => node.Value<string>())
                            };
                        }
                        else
                        {
                            return new ReturnValue
                            {
                                Type = response.returnType.Value,
                                Value = response.returnValue.Value
                            };
                        }
                    else
                    {
                        throw new Exception((string)(response?.error ?? "Unknown error"));
                    }
                }

                throw new Exception("Could not get a return");
            }
            finally
            {
                _semaphore.Release();
            }
        }

        public Task Delete(string objectName)
        {
            return InternalExecuteCall("D", objectName);
        }

        public Task<ReturnValue> GetFilterConfigWidget()
        {
            return InternalExecuteCall("F");
        }

        internal Task ClickFilterWidget(string filterConfigWidgetReference, string[] widgetPathNames)
        {
            return InternalExecuteCall("FB", filterConfigWidgetReference, parameters:  widgetPathNames);
        }

        internal Task SetFilterSpinBoxValue(string filterConfigWidgetReference, float value, string[] widgetPathNames)
        {
            return InternalExecuteCall("FS", filterConfigWidgetReference, parameters: [value, .. widgetPathNames]);
        }

        internal Task SetFilterAngleSelectorValue(string filterConfigWidgetReference, int value, string[] widgetPathNames)
        {
            return InternalExecuteCall("FA", filterConfigWidgetReference, parameters: [value, .. widgetPathNames]);
        }

        internal Task SetFilterComboBoxSelectedItem(string filterConfigWidgetReference, int value, string[] widgetPathNames)
        {
            return InternalExecuteCall("FC", filterConfigWidgetReference, parameters: [value, .. widgetPathNames]);
        }

        public async ValueTask DisposeAsync()
        {
            await _semaphore.WaitAsync();

            if (client?.Connected ?? false)
            {
                client.Close();
            }

            client?.Dispose();

            _semaphore.Release();
        }

        public KritaInstance KritaInstance { get => _kritaInstance; }
        public Canvas CurrentCanvas { get => _currentCanvas; }
        public Document CurrentDocument { get => _currentDocument; }
    }
}
