using LoupedeckKritaApiClient.ClientBase;

namespace LoupedeckKritaApiClient.FiltersDialogs
{
    public class KritaFilterPerChannelColorAdjustment(Client client) : FilterDialog(client)
    {
        protected override string ActionName => "PerChannelColorAdjustment";

        public enum Channel
        {
            RGBA = 0,
            Red,
            Green,
            Blue,
            Alpha,
            Hue,
            Saturation,
            Lightness
        }

        public Task SetChannel(Channel channel)
        {
            return SetComboBoxSelectedIndex((int)channel, "WdgPerChannel", "cmbChannel");
        }

        public Task ToggleLogarithmic()
        {
            return ClickCheckBox("WdgPerChannel", "chkLogarithmic");
        }

        public Task Reset()
        {
            return ClickCheckBox("WdgPerChannel", "resetButton");
        }

        public Task SetInValue(int value)
        {
            return SetSpinBoxValue(value, "WdgPerChannel", "intIn");
        }

        public Task SetOutValue(int value)
        {
            return SetSpinBoxValue(value, "WdgPerChannel", "intOut");
        }
    }
}
