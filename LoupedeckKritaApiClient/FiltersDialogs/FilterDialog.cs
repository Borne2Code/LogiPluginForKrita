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

        public async Task Confirm()
        {
#pragma warning disable CS8604 // Possible null reference argument.
            await _client.ConfirmFilter(_filterConfigWidgetReference);
#pragma warning restore CS8604 // Possible null reference argument.
        }

        public async Task Cancel()
        {
#pragma warning disable CS8604 // Possible null reference argument.
            await _client.CancelFilter(_filterConfigWidgetReference);
#pragma warning restore CS8604 // Possible null reference argument.
        }

        protected async Task ClickRadio(params string[] widgetPathNames)
        {
#pragma warning disable CS8604 // Possible null reference argument.
            await _client.ClickFilterWidget(_filterConfigWidgetReference, widgetPathNames);
#pragma warning restore CS8604 // Possible null reference argument.
        }

        protected async Task ClickPushButton(params string[] widgetPathNames)
        {
#pragma warning disable CS8604 // Possible null reference argument.
            await _client.ClickFilterWidget(_filterConfigWidgetReference, widgetPathNames);
#pragma warning restore CS8604 // Possible null reference argument.
        }

        protected async Task ClickCheckBox(params string[] widgetPathNames)
        {
#pragma warning disable CS8604 // Possible null reference argument.
            await _client.ClickFilterWidget(_filterConfigWidgetReference, widgetPathNames);
#pragma warning restore CS8604 // Possible null reference argument.
        }

        protected async Task<int> AdjustIntSpinBoxValue(int value, params string[] widgetPathNames)
        {
#pragma warning disable CS8604 // Possible null reference argument.
            var returnValue = await _client.AdjustFilterIntSpinBoxValue(_filterConfigWidgetReference, value, widgetPathNames);
#pragma warning restore CS8604 // Possible null reference argument.

            if (returnValue.Type != "int")
            {
                throw new Exception($"The method call didn't return a int ({returnValue.Type}");
            }

            return (int)(long)returnValue.Value;
        }

        protected async Task<float> AdjustFloatSpinBoxValue(float value, params string[] widgetPathNames)
        {
#pragma warning disable CS8604 // Possible null reference argument.
            var returnValue = await _client.AdjustFilterFloatSpinBoxValue(_filterConfigWidgetReference, value, widgetPathNames);
#pragma warning restore CS8604 // Possible null reference argument.

            if (returnValue.Type != "float")
            {
                throw new Exception($"The method call didn't return a float ({returnValue.Type}");
            }

            return (float)(double)returnValue.Value;
        }

        protected async Task<int> AdjustAngleSelectorValue(int value, params string[] widgetPathNames)
        {
#pragma warning disable CS8604 // Possible null reference argument.
            var returnValue = await _client.SetFilterAngleSelectorValue(_filterConfigWidgetReference, value, widgetPathNames);
#pragma warning restore CS8604 // Possible null reference argument.

            if (returnValue.Type != "float" && returnValue.Type != "int")
            {
                throw new Exception($"The method call didn't return a float ({returnValue.Type}");
            }

            return (int)returnValue.Value;
        }

        protected async Task SetComboBoxSelectedIndex(int value, params string[] widgetPathNames)
        {
#pragma warning disable CS8604 // Possible null reference argument.
            await _client.SetFilterComboBoxSelectedItem(_filterConfigWidgetReference, value, widgetPathNames);
#pragma warning restore CS8604 // Possible null reference argument.
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
