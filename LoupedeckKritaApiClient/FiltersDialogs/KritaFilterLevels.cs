using LoupedeckKritaApiClient.ClientBase;

namespace LoupedeckKritaApiClient.FiltersDialogs
{
    public class KritaFilterLevels(Client client) : FilterDialog(client)
    {
        protected override string ActionName => "krita_filter_levels";

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

        public Task SetLightnessMode()
        {
            return ClickPushButton("buttonLightnessMode");
        }

        public Task SetAllChannelsMode()
        {
            return ClickPushButton("buttonAllChannelsMode");
        }

        public Task SetChannel(Channel channel)
        {
            return SetComboBoxSelectedIndex((int)channel, "comboBoxChannel");
        }

        public Task ResetAll()
        {
            return ClickPushButton("buttonResetAll");
        }

        public Task SetLinearHistogram()
        {
            return ClickPushButton("buttonLinearHistogram");
        }

        public Task SetLogarithmicHistogram()
        {
            return ClickPushButton("buttonLogarithmicHistogram");
        }

        public Task SetScaleHistogramToFit()
        {
            return ClickPushButton("buttonScaleHistogramToFit");
        }

        public Task SetScaleHistogramToCutLongPeaks()
        {
            return ClickPushButton("buttonScaleHistogramToCutLongPeaks");
        }

        public Task ApplyAutoLevels()
        {
            return ClickPushButton("buttonAutoLevels");
        }

        public Task ResetInputLevels()
        {
            return ClickPushButton("buttonResetInputLevels");
        }

        public Task SetInputBlackValue(int value)
        {
            return SetSpinBoxValue(value, "spinBoxInputBlackPoint");
        }

        public Task SetInputGamma(float value)
        {
            return SetSpinBoxValue(value, "spinBoxInputGamma");
        }

        public Task SetInputWhiteValue(int value)
        {
            return SetSpinBoxValue(value, "spinBoxInputWhitePoint");
        }

        public Task ResetoutputLevels()
        {
            return ClickPushButton("buttonResetOutputLevels");
        }

        public Task SetOutputBlackValue(int value)
        {
            return SetSpinBoxValue(value, "spinBoxOutputBlackPoint");
        }

        public Task SetOutputWhiteValue(int value)
        {
            return SetSpinBoxValue(value, "spinBoxOutputWhitePoint");
        }

        public Task ApplyAutoLevelsOnAllChannels()
        {
            return ClickPushButton("containerAllChannels", "buttonAutoLevelsAllChannels");
        }

        public Task ResetAllChannels()
        {
            return ClickPushButton("containerAllChannels", "buttonResetAllChannels");
        }


    }
}
