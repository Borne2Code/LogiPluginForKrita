using LoupedeckKritaApiClient.ClientBase;

namespace LoupedeckKritaApiClient
{
    public class FileLayerPropertiesDialog : KritaDialogBase
    {
        public FileLayerPropertiesDialog(Client client) : base(client)
        {
        }

        public override async Task AttachDialog()
        {
            _dialogConfigWidgetReference = (string)(await _client.GetModalDialogConfigWidget("1")).Value;
        }

        public override Task Confirm()
        {
            return _client.ClickMainDialogButton(_dialogConfigWidgetReference!, "0", "1");
        }

        public override Task Cancel()
        {
            return _client.ClickMainDialogButton(_dialogConfigWidgetReference!, "0", "2");
        }

        public Task OpenFileSelector()
        {
            return ClickPushButton("wdgUrlRequester", "btnSelectFile");
        }

        public Task SelectNoScale()
        {
            return ClickRadio("grpScalingOptions", "radioDontScale");
        }

        public Task SelectScaleToImage()
        {
            return ClickRadio("grpScalingOptions", "radioScaleToImageSize");
        }

        public Task SelectScaleToPpi()
        {
            return ClickRadio("grpScalingOptions", "radioScalePPI");
        }
    }
}