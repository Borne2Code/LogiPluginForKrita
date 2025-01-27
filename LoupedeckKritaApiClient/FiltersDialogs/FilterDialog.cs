using LoupedeckKritaApiClient.ClientBase;

namespace LoupedeckKritaApiClient.FiltersDialogs
{
    public abstract class FilterDialog : IAsyncDisposable
    {
        private Client _client;
        private string? _filterConfigWidgetReference = null;

        public FilterDialog(Client client)
        {
            _client = client;
        }

        protected abstract string ActionName { get; }

        public async Task OpenDialog()
        {
            await using var action = await _client.KritaInstance.Action(ActionName);
            await action.Trigger();
            _filterConfigWidgetReference = (string)(await _client.GetFilterConfigWidget()).Value;
        }

        protected async Task ClickRadio(params string[] widgetPathNames)
        {
            await _client.ClickFilterWidget(_filterConfigWidgetReference, widgetPathNames);
        }

        protected async Task ClickPushButton(params string[] widgetPathNames)
        {
            await _client.ClickFilterWidget(_filterConfigWidgetReference, widgetPathNames);
        }

        protected async Task ClickCheckBox(params string[] widgetPathNames)
        {
            await _client.ClickFilterWidget(_filterConfigWidgetReference, widgetPathNames);
        }

        protected async Task<int> AdjustIntSpinBoxValue(int value, params string[] widgetPathNames)
        {
            var returnValue = await _client.AdjustFilterIntSpinBoxValue(_filterConfigWidgetReference, value, widgetPathNames);

            if (returnValue.Type != "int")
            {
                throw new Exception($"The method call didn't return a int ({returnValue.Type}");
            }

            return (int)(long)returnValue.Value;
        }

        protected async Task<float> AdjustFloatSpinBoxValue(float value, params string[] widgetPathNames)
        {
            var returnValue = await _client.AdjustFilterFloatSpinBoxValue(_filterConfigWidgetReference, value, widgetPathNames);

            if (returnValue.Type != "float")
            {
                throw new Exception($"The method call didn't return a float ({returnValue.Type}");
            }

            return (float)(double)returnValue.Value;
        }

        protected async Task<int> AdjustAngleSelectorValue(int value, params string[] widgetPathNames)
        {
            var returnValue = await _client.SetFilterAngleSelectorValue(_filterConfigWidgetReference, value, widgetPathNames);

            if (returnValue.Type != "float" && returnValue.Type != "int")
            {
                throw new Exception($"The method call didn't return a float ({returnValue.Type}");
            }

            return (int)returnValue.Value;
        }

        protected async Task SetComboBoxSelectedIndex(int value, params string[] widgetPathNames)
        {
            await _client.SetFilterComboBoxSelectedItem(_filterConfigWidgetReference, value, widgetPathNames);
        }

        public async ValueTask DisposeAsync()
        {
            if (_filterConfigWidgetReference != null && _client != null)
            {
                await _client.Delete(_filterConfigWidgetReference);
            }
        }
    }
}
