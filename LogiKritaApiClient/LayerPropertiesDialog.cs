using LogiKritaApiClient.ClientBase;

namespace LogiKritaApiClient
{
    public class LayerPropertiesDialog : KritaDialogBase
    {
        public LayerPropertiesDialog(Client client) : base(client)
        {
        }

        public override async Task AttachDialog()
        {
            _dialogConfigWidgetReference = (string)(await _client.GetDialogConfigWidget("1")).Value;
        }

        public override Task Confirm()
        {
            return _client.ClickMainDialogButton(_dialogConfigWidgetReference!, "0", "1");
        }

        public override Task Cancel()
        {
            return _client.ClickMainDialogButton(_dialogConfigWidgetReference!, "0", "2");
        }

        public Task ToggleVIsible()
        {
            return ClickPushButton("grpProperties", "1");
        }

        public Task ToggleLocked()
        {
            return ClickPushButton("grpProperties", "2");
        }

        public Task ToggleInheritAlpha()
        {
            return ClickPushButton("grpProperties", "3");
        }

        public async Task ToggleAlphaLocked()
        {
            await ClickPushButton("grpProperties", "4");
        }

        public Task<int> AdjustOpacity(int adjust)
        {
            return AdjustIntSpinBoxValue(adjust, "intOpacity");
        }

        public Task ToggleChannelBlue()
        {
            return ClickCheckBox("grpActiveChannels",  "1");
        }

        public Task ToggleChannelGreen()
        {
            return ClickCheckBox("grpActiveChannels", "2");
        }

        public Task ToggleChannelRed()
        {
            return ClickCheckBox("grpActiveChannels", "3");
        }

        public Task ToggleChannelAlpha()
        {
            return ClickCheckBox("grpActiveChannels", "4");
        }

        public Task ClickColorButton(int colorIndex)
        {
            return ClickPushButton("colorLabelSelector", (colorIndex + 2).ToString());
        }
    }
}