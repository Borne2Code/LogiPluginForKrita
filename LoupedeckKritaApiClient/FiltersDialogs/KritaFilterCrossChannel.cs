using LoupedeckKritaApiClient.ClientBase;

namespace LoupedeckKritaApiClient.FiltersDialogs
{
    public class KritaFilterCrossChannel(Client client) : FilterDialog(client)
    {
        protected override string ActionName => "krita_filter_crosschannel";

        public enum TargetChannel
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

        public enum DriverChannel
        {
            Red = 0,
            Green,
            Blue,
            Alpha,
            Hue,
            Saturation,
            Lightness
        }

        public Task SetTargetChannelIndex(TargetChannel index)
        {
            return SetComboBoxSelectedIndex((int)index, "WdgPerChannel", "cmbChannel");
        }

        public Task SetDriverChannelIndex(DriverChannel index)
        {
            return SetComboBoxSelectedIndex((int)index, "WdgPerChannel", "cmbDriverChannel");
        }

        public Task ToggleLogarithmic()
        {
            return ClickCheckBox("WdgPerChannel", "chkLogarithmic");
        }

        public Task Reset()
        {
            return ClickPushButton("WdgPerChannel", "resetButton");
        }

        public Task<int> AdjustInputValue(int value)
        {
            return AdjustIntSpinBoxValue(value, "WdgPerChannel", "intIn");
        }

        public Task<int> AdjustOutputValue(int value)
        {
            return AdjustIntSpinBoxValue(value, "WdgPerChannel", "intOut");
        }
    }
}
