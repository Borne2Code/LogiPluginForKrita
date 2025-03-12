using LoupedeckKritaApiClient.ClientBase;

namespace LoupedeckKritaApiClient.FiltersDialogs
{
    public abstract class FilterDialogBase : KritaDialogBase
    {
        public FilterDialogBase(Client client):base(client)
        {
        }

        internal abstract string ActionName { get; }

        public override async Task AttachDialog()
        {
            _dialogConfigWidgetReference = (string)(await _client.GetFilterConfigWidget()).Value;
        }

        public async Task CreateMask()
        {
#pragma warning disable CS8604 // Possible null reference argument.
            await _client.CreateFilterMask(_dialogConfigWidgetReference);
#pragma warning restore CS8604 // Possible null reference argument.
        }
    }
}
