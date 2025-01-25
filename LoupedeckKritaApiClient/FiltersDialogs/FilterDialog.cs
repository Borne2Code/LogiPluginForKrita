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

        protected async Task SetSpinBoxValue(int value, params string[] widgetPathNames)
        {
            await _client.SetFilterSpinBoxValue(_filterConfigWidgetReference, value, widgetPathNames);
        }

        protected async Task SetAngleSelectorValue(int value, params string[] widgetPathNames)
        {
            await _client.SetFilterAngleSelectorValue(_filterConfigWidgetReference, value, widgetPathNames);
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
