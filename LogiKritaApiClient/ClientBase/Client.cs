using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace LogiKritaApiClient.ClientBase
{
    public class Client : IAsyncDisposable
    {
        private Socket? client;
        private string securityToken = string.Empty;
        private readonly KritaInstance _kritaInstance;
        private readonly Canvas _currentCanvas;
        private readonly View _currentView;
        private readonly Document _currentDocument;
        private readonly Node _currentNode;
        private readonly Selection _currentSelection;
        private readonly Node _globalSelectionNode;
        private readonly SemaphoreSlim _semaphore = new(1, 1);

        private const string InitializeActionName = "Initialize"; // Initialize the client
        private const string DeleteActionName = "Delete"; // delete instance in classes proxy cache
        private const string ExecuteActionName = "Execute"; // Execute a method in an object's context
        private const string GetDialogActionName = "GetDialog"; // Drive a dialog
        private const string GetModalDialogActionName = "GetModalDialog"; // Drive a modal dialog
        private const string SetDialogAngleActionName = "SetDialogAngle"; // Set angle selector value
        private const string ClickDialogButtonActionName = "ClickDialogButton"; // Click on widget button, radio or checkbox
        private const string SetDialogComboSelectActionName = "SetDialogComboSelect"; // Select combo box selected index
        private const string SetDialogSpinboxIntValueActionName = "SetDialogSpinboxIntValue"; // Set spinbox int value
        private const string SetDialogSpinboxFloatValueActionName = "SetDialogSpinboxFloatValue"; // Set spinbox float value
        private const string ClickMainDialogButtonActionName = "ClickMainDialogButton"; // Click on main dialog button
        private const string CreateFilterAsMaskActionName = "CreateFilterAsMask"; // Create filter mask from dialog
        private const string ValidateFilterDialogActionName = "ValidateFilterDialog"; // Validate filter dialog
        private const string CancelFilterDialogActionName = "CancelFilterDialog"; // Cancel filter dialog

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
            _currentView = new View()
            {
                Client = this,
                PrimitiveName = "currentView"
            };
            _currentDocument = new Document()
            {
                Client = this,
                PrimitiveName = "currentDocument"
            };
            _currentNode = new Node()
            {
                Client = this,
                PrimitiveName = "currentNode"
            };
            _currentSelection= new Selection()
            {
                Client = this,
                PrimitiveName = "currentSelection"
            };
            _globalSelectionNode = new Node()
            {
                Client = this,
                PrimitiveName = "globalSelectionNode"
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

            CreateSecurityToken();
            await SendInitializationMessage();
        }

        private async Task SendInitializationMessage()
        {
            var result = await InternalExecuteCall(securityToken, InitializeActionName);

            if (result.Type == "bool" && (bool)result.Value == true)
            {
                return;
            }

            throw new Exception("Could not initialize the client");
        }

        private void CreateSecurityToken()
        {
            // Convert.ToBase64String(RandomNumberGenerator.GetBytes(count));
            securityToken = "abcdef";
        }

        internal Task<ReturnValue> ExecuteCall(string objectName, string methodName, params object[] parameters)
        {
            return InternalExecuteCall(securityToken, ExecuteActionName, objectName, methodName, parameters);
        }

        private async Task<ReturnValue> InternalExecuteCall(string securityToken, string action, string? objectName = null, string? methodName = null, params object[] parameters)
        {

            if (client == null || !client.Connected)
            try
            {
                    await Connect();
            }
            catch
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
                                        if (val is LogiClientKritaBaseClass typedVal)
                                        {
                                            type = val.GetType().Name;
                                            value = $"\"{typedVal.Reference ?? typedVal.PrimitiveName}\"";
                                        }
                                        else
                                            throw new ArgumentException($"Unmanaged argument type: {val.GetType().Name}");
                                    }; break;
                            }

                            return $"{{\"type\":\"{type}\",\"value\":{value}}}";
                        })
                    ) + "]";

                var message = $"{{\"action\":\"{action}\",\"securityToken\":\"{securityToken}\"";
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
                        client.Disconnect(false);
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
            return InternalExecuteCall(securityToken, DeleteActionName, objectName);
        }

        public Task<ReturnValue> GetDialogConfigWidget(params string[] widgetsNamesOrIndexes)
        {
            return InternalExecuteCall(securityToken, GetDialogActionName, null, null, widgetsNamesOrIndexes);
        }

        public Task<ReturnValue> GetModalDialogConfigWidget(params string[] widgetsNamesOrIndexes)
        {
            return InternalExecuteCall(securityToken, GetModalDialogActionName, null, null, widgetsNamesOrIndexes);
        }

        internal Task ClickDialogButton(string dialogConfigWidgetReference, params string[] widgetPathNames)
        {
            return InternalExecuteCall(securityToken, ClickDialogButtonActionName, dialogConfigWidgetReference, parameters: widgetPathNames);
        }

        internal Task<ReturnValue> AdjustDialogIntSpinBoxValue(string dialogConfigWidgetReference, int value, params string[] widgetPathNames)
        {
            return InternalExecuteCall(securityToken, SetDialogSpinboxIntValueActionName, dialogConfigWidgetReference, parameters: [value, .. widgetPathNames]);
        }

        internal Task<ReturnValue> AdjustDialogFloatSpinBoxValue(string dialogConfigWidgetReference, float value, params string[] widgetPathNames)
        {
            return InternalExecuteCall(securityToken, SetDialogSpinboxFloatValueActionName, dialogConfigWidgetReference, parameters: [value, .. widgetPathNames]);
        }

        internal Task<ReturnValue> SetDialogAngleSelectorValue(string dialogConfigWidgetReference, float value, params string[] widgetPathNames)
        {
            return InternalExecuteCall(securityToken, SetDialogAngleActionName, dialogConfigWidgetReference, parameters: [value, .. widgetPathNames]);
        }

        internal Task SetDialogComboBoxSelectedItem(string dialogConfigWidgetReference, int value, params string[] widgetPathNames)
        {
            return InternalExecuteCall(securityToken, SetDialogComboSelectActionName, dialogConfigWidgetReference, parameters: [value, .. widgetPathNames]);
        }

        internal Task ClickMainDialogButton(string filterConfigWidgetReference, params string[] widgetPathNames)
        {
            return InternalExecuteCall(securityToken, ClickMainDialogButtonActionName, filterConfigWidgetReference, parameters: widgetPathNames);
        }

        internal Task ConfirmFilter(string filterConfigWidgetReference)
        {
            return InternalExecuteCall(securityToken, ValidateFilterDialogActionName, filterConfigWidgetReference);
        }

        internal Task CancelFilter(string filterConfigWidgetReference)
        {
            return InternalExecuteCall(securityToken, CancelFilterDialogActionName, filterConfigWidgetReference);
        }

        internal Task CreateFilterMask(string filterConfigWidgetReference)
        {
            return InternalExecuteCall(securityToken, CreateFilterAsMaskActionName, filterConfigWidgetReference);
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
        public View CurrentView { get => _currentView; }
        public Document CurrentDocument { get => _currentDocument; }
        public Node CurrentNode { get => _currentNode; }
        public Selection CurrentSelection { get => _currentSelection; }
        public Node GlobalSelectionNode { get => _globalSelectionNode; }
    }
}
