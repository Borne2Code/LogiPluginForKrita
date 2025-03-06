using System.Runtime.CompilerServices;
using LoupedeckKritaApiClient.FiltersDialogs;

namespace Loupedeck.KritaPlugin.DynamicFolders
{
    public class FilterLevels : FilterDialogBase
    {
        public FilterLevels()
            : base(FilterNames.Levels)
        {
        }

        static internal FilterDialogDefinition GetDefinition()
        {
            return new FilterDialogDefinition("Levels",
                FilterNames.Levels,
                [
                    new FilterCommandDefinition("Lightness", (dialog) => ((KritaFilterLevels)dialog.Dialog).SetLightnessMode()),
                    new FilterCommandDefinition("All channels", (dialog) => ((KritaFilterLevels)dialog.Dialog).SetAllChannelsMode()),

                    new FilterCommandDefinition("Reset", (dialog) => ((KritaFilterLevels)dialog.Dialog).ResetAll()),
                    new FilterCommandDefinition("Reset input levels", (dialog) => ((KritaFilterLevels)dialog.Dialog).ResetInputLevels()),
                    new FilterCommandDefinition("Reset output levels", (dialog) => ((KritaFilterLevels)dialog.Dialog).ResetoutputLevels()),

                    new FilterCommandDefinition("Linear histogram", (dialog) => ((KritaFilterLevels)dialog.Dialog).SetLinearHistogram()),
                    new FilterCommandDefinition("Logarithmic histogram", (dialog) => ((KritaFilterLevels)dialog.Dialog).SetLogarithmicHistogram()),
                    new FilterCommandDefinition("Scale to fit", (dialog) => ((KritaFilterLevels)dialog.Dialog).SetScaleHistogramToFit()),
                    new FilterCommandDefinition("Scale to cut long peaks", (dialog) => ((KritaFilterLevels)dialog.Dialog).SetScaleHistogramToCutLongPeaks()),

                    new FilterCommandDefinition("Channel RGBA", (dialog) => ((KritaFilterLevels)dialog.Dialog).SetChannel(KritaFilterLevels.Channel.RGBA)),
                    new FilterCommandDefinition("Channel Red", (dialog) => ((KritaFilterLevels)dialog.Dialog).SetChannel(KritaFilterLevels.Channel.Red)),
                    new FilterCommandDefinition("Channel Green", (dialog) => ((KritaFilterLevels)dialog.Dialog).SetChannel(KritaFilterLevels.Channel.Green)),
                    new FilterCommandDefinition("Channel Blue", (dialog) => ((KritaFilterLevels)dialog.Dialog).SetChannel(KritaFilterLevels.Channel.Blue)),
                    new FilterCommandDefinition("Channel Alpha", (dialog) => ((KritaFilterLevels)dialog.Dialog).SetChannel(KritaFilterLevels.Channel.Alpha)),
                    new FilterCommandDefinition("Channel Hue", (dialog) => ((KritaFilterLevels)dialog.Dialog).SetChannel(KritaFilterLevels.Channel.Hue)),
                    new FilterCommandDefinition("Channel Saturation", (dialog) => ((KritaFilterLevels)dialog.Dialog).SetChannel(KritaFilterLevels.Channel.Saturation)),
                    new FilterCommandDefinition("Channel Lightness", (dialog) => ((KritaFilterLevels)dialog.Dialog).SetChannel(KritaFilterLevels.Channel.Lightness)),

                    new FilterCommandDefinition("Auto levels", (dialog) => ((KritaFilterLevels)dialog.Dialog).ApplyAutoLevels()),
                    new FilterCommandDefinition("Reset all channels", (dialog) => ((KritaFilterLevels)dialog.Dialog).ResetAllChannels()),
                ],
                [
                    new FilterAdjustmentDefinition("Input Black", (dialog, delta) => ((KritaFilterLevels)dialog.Dialog).AdjustInputBlackValue((int)delta).Result, 0),
                    new FilterAdjustmentDefinition("Input Gamma", 
                        (dialog, delta) => ((KritaFilterLevels)dialog.Dialog).AdjustInputGamma(delta).Result,
                        1.0f, (val, delta) => val / (1 + (float)delta / 100) - val, 3),
                    new FilterAdjustmentDefinition("Input White", (dialog, delta) => ((KritaFilterLevels)dialog.Dialog).AdjustInputWhiteValue((int)delta).Result, 255),
                    new FilterAdjustmentDefinition("Output Black", (dialog, delta) => ((KritaFilterLevels)dialog.Dialog).AdjustOutputBlackValue((int)delta).Result, 0),
                    new FilterAdjustmentDefinition("Output  White", (dialog, delta) => ((KritaFilterLevels)dialog.Dialog).AdjustOutputWhiteValue((int)delta).Result, 255),
                ]);
        }
    }
}
