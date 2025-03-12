using LoupedeckKritaApiClient.ClientBase;
using LoupedeckKritaApiClient.FiltersDialogs;

namespace LoupedeckKritaApiClient
{
    public class LayerPropertiesDialog : KritaDialogBase
    {
        public LayerPropertiesDialog(Client client) : base(client)
        {
        }

        public override async Task AttachDialog()
        {
            _dialogConfigWidgetReference = (string)(await _client.GetFilterConfigWidget()).Value;
        }
    }
}