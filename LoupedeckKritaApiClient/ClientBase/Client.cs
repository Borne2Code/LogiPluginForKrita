using System.Net.Sockets;
using System.Net;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Threading;

namespace LoupedeckKritaApiClient.ClientBase
{
    public class Client : IDisposable
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
                ObjectName = "kritaInstance"
            };
            _currentCanvas = new Canvas()
            {
                Client = this,
                ObjectName = "currentCanvas"
            };
            _currentDocument = new Document()
            {
                Client = this,
                ObjectName = "currentDocument"
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

        internal async Task<ReturnValue> ExecuteCall(string objectName, string methodName, params object[] parameters)
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
                                        if (typeof(LoupedeckClientKritaBaseClass).IsInstanceOfType(val))
                                        {
                                            type = val.GetType().Name;
                                            value = $"\"{((LoupedeckClientKritaBaseClass)val).ObjectName}\"";
                                        }
                                        else
                                            throw new ArgumentException($"Unmanaged argument type: {val.GetType().Name}");
                                    }; break;
                            }

                            return $"{{\"type\":\"{type}\",\"value\":{value}}}";
                        })
                    ) + "]";

                var messageBytes = Encoding.UTF8.GetBytes($"{{\"action\":\"E\",\"method\":\"{methodName}\",\"object\":\"{objectName}\",\"parameters\":{parametersListString}}}");
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

        public async Task Delete(string objectName)
        {
            if (client == null)
            {
                throw new Exception("Please connect before calling a method");
            }

            await _semaphore.WaitAsync();

            try
            {
                var messageBytes = Encoding.UTF8.GetBytes($"{{\"action\":\"D\",\"object\":\"{objectName}\"}}");
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

                    if (response?.result != "OK")
                    {
                        throw new Exception((string)(response?.error ?? "Unknown error"));
                    }

                    return;
                }

                throw new Exception("Could not delete instance");
            }
            finally
            {
                _semaphore.Release();
            }
        }

        public void Dispose()
        {
            if (client?.Connected ?? false)
            {
                client.Close();
            }

            client?.Dispose();
        }

        public KritaInstance KritaInstance { get => _kritaInstance; }
        public Canvas CurrentCanvas { get => _currentCanvas; }
        public Document CurrentDocument { get => _currentDocument; }
    }
}
