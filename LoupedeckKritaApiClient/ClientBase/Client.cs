using System.Net;
using System.Net.Sockets;
using System.Text;
using LoupedeckKritaApiClient.FiltersDialogs;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace LoupedeckKritaApiClient.ClientBase
{
    public class Client : IAsyncDisposable
    {
        private Socket? client;
        private readonly KritaInstance _kritaInstance;
        private readonly Canvas _currentCanvas;
        private readonly View _currentView;
        private readonly Document _currentDocument;
        private readonly Node _currentNode;
        private readonly Selection _currentSelection;
        private readonly Node _globalSelectionNode;
        private readonly SemaphoreSlim _semaphore = new(1, 1);

        private const string DeleteActionName = "Delete"; // delete instance in classes proxy cache
        private const string ExecuteActionName = "Execute"; // Execute a method in an object's context
        private const string GetFilterDialogActionName = "GetFilterDialog"; // Drive a filter dialog
        private const string SetFilterAngleActionName = "SetFilterAngle"; // Set filter angle selector value
        private const string ClickFilterButtonActionName = "ClickFilterButton"; // Click on filter button, radio or checkbox
        private const string SetFilterComboSelectActionName = "SetFilterComboSelect"; // Select filter combo box selected index
        private const string SetFilterSpinboxIntValueActionName = "SetFilterSpinboxIntValue"; // Set filter spinbox int value
        private const string SetFilterSpinboxFloatValueActionName = "SetFilterSpinboxFloatValue"; // Set filter spinbox float value
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
        }

        internal Task<ReturnValue> ExecuteCall(string objectName, string methodName, params object[] parameters)
        {
            return InternalExecuteCall(ExecuteActionName, objectName, methodName, parameters);
        }

        private async Task<ReturnValue> InternalExecuteCall(string action, string? objectName = null, string? methodName = null, params object[] parameters)
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
                                        if (val is LoupedeckClientKritaBaseClass typedVal)
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
            return InternalExecuteCall(DeleteActionName, objectName);
        }

        public Task<ReturnValue> GetFilterConfigWidget()
        {
            return InternalExecuteCall(GetFilterDialogActionName);
        }

        internal Task ConfirmFilter(string filterConfigWidgetReference)
        {
            return InternalExecuteCall(ValidateFilterDialogActionName, filterConfigWidgetReference);
        }

        internal Task CancelFilter(string filterConfigWidgetReference)
        {
            return InternalExecuteCall(CancelFilterDialogActionName, filterConfigWidgetReference);
        }

        internal Task CreateFilterMask(string filterConfigWidgetReference)
        {
            return InternalExecuteCall(CreateFilterAsMaskActionName, filterConfigWidgetReference);
        }

        internal Task ClickFilterWidget(string filterConfigWidgetReference, string[] widgetPathNames)
        {
            return InternalExecuteCall(ClickFilterButtonActionName, filterConfigWidgetReference, parameters:  widgetPathNames);
        }

        internal Task<ReturnValue> AdjustFilterIntSpinBoxValue(string filterConfigWidgetReference, int value, string[] widgetPathNames)
        {
            return InternalExecuteCall(SetFilterSpinboxIntValueActionName, filterConfigWidgetReference, parameters: [value, .. widgetPathNames]);
        }

        internal Task<ReturnValue> AdjustFilterFloatSpinBoxValue(string filterConfigWidgetReference, float value, string[] widgetPathNames)
        {
            return InternalExecuteCall(SetFilterSpinboxFloatValueActionName, filterConfigWidgetReference, parameters: [value, .. widgetPathNames]);
        }

        internal Task<ReturnValue> SetFilterAngleSelectorValue(string filterConfigWidgetReference, float value, string[] widgetPathNames)
        {
            return InternalExecuteCall(SetFilterAngleActionName, filterConfigWidgetReference, parameters: [value, .. widgetPathNames]);
        }

        internal Task SetFilterComboBoxSelectedItem(string filterConfigWidgetReference, int value, string[] widgetPathNames)
        {
            return InternalExecuteCall(SetFilterComboSelectActionName, filterConfigWidgetReference, parameters: [value, .. widgetPathNames]);
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

        public async Task<FilterDialogBase> GetFilterDialog(string filterName)
        {
            FilterDialogBase dialog = FilterNames.GetFilterDialogByFilterName(this, filterName);

            await using var action = await KritaInstance.Action(dialog.ActionName);
            await action.Trigger();

            await dialog.AttachDialog();

            return dialog;
        }

        public async Task<(FilterDialogBase? filterDialog, string? filterName)> GetLayerPropertiesDialog()
        {
            await using var filter = await CurrentNode.Filter();
            if (filter == null)
            {
                return (null, null);
            }

            await KritaInstance.ExecuteAction(ActionsNames.Layer_properties);

            var filterName = await filter.name();
            var dialog = FilterNames.GetFilterDialogByFilterName(this, filterName);
            await dialog.AttachDialog();

            return (dialog, filterName);
        }
    }
}
