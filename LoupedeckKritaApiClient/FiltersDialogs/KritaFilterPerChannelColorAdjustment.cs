using LoupedeckKritaApiClient.ClientBase;

namespace LoupedeckKritaApiClient.FiltersDialogs
{
    public class KritaFilterPerChannelColorAdjustment(Client client) : FilterDialogBase(client)
    {
        internal override string ActionName => "krita_filter_perchannel";

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

        public Task<int> AdjustInValue(int value)
        {
            return AdjustIntSpinBoxValue(value, "WdgPerChannel", "intIn");
        }

        public Task<int> AdjustOutValue(int value)
        {
            return AdjustIntSpinBoxValue(value, "WdgPerChannel", "intOut");
        }
    }
}
