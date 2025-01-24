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

        public abstract string ActionName { get; }

        public async Task OpenDialog()
        {
            await using var action = await _client.KritaInstance.Action(ActionName);
            await action.Trigger();
            _filterConfigWidgetReference = (string)(await _client.GetFilterConfigWidget()).Value;
        }

        public async Task ClickRadio(params string[] widgetPathNames)
        {
            await _client.ClickFilterRadio(_filterConfigWidgetReference, widgetPathNames);
        }

        public async Task SetSpinBoxValue(int value, params string[] widgetPathNames)
        {
            await _client.SetSpinBoxValue(_filterConfigWidgetReference, value, widgetPathNames);
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
