using LoupedeckKritaApiClient.ClientBase;

namespace LoupedeckKritaApiClient
{
    public class LayerPropertiesDialog : KritaDialogBase
    {
        public LayerPropertiesDialog(Client client) : base(client)
        {
        }

        public override async Task AttachDialog()
        {
            //_dialogConfigWidgetReference = (string)(await _client.GetModalDialogConfigWidget("1", "3")).Value;
        }

        public override async Task Confirm()
        {
#pragma warning disable CS8604 // Possible null reference argument.
            //await _client.ClickMainDialogButton(_dialogConfigWidgetReference, "0", "1");
#pragma warning restore CS8604 // Possible null reference argument.
        }

        public override async Task Cancel()
        {
#pragma warning disable CS8604 // Possible null reference argument.
            //await _client.ClickMainDialogButton(_dialogConfigWidgetReference, "0", "2");
#pragma warning restore CS8604 // Possible null reference argument.
        }
    }
}