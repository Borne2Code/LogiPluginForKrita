using LoupedeckKritaApiClient.ClientBase;

namespace LoupedeckKritaApiClient.FiltersDialogs
{
    public class KritaFilterLevels(Client client) : FilterDialogBase(client)
    {
        internal override string ActionName => "krita_filter_levels";

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

        public Task<int> AdjustInputBlackValue(int value)
        {
            return AdjustIntSpinBoxValue(value, "spinBoxInputBlackPoint");
        }

        public Task<float> AdjustInputGamma(float value)
        {
            return AdjustFloatSpinBoxValue(value, "spinBoxInputGamma");
        }

        public Task<int> AdjustInputWhiteValue(int value)
        {
            return AdjustIntSpinBoxValue(value, "spinBoxInputWhitePoint");
        }

        public Task ResetoutputLevels()
        {
            return ClickPushButton("buttonResetOutputLevels");
        }

        public Task<int> AdjustOutputBlackValue(int value)
        {
            return AdjustIntSpinBoxValue(value, "spinBoxOutputBlackPoint");
        }

        public Task<int> AdjustOutputWhiteValue(int value)
        {
            return AdjustIntSpinBoxValue(value, "spinBoxOutputWhitePoint");
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
