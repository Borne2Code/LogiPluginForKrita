using LogiKritaApiClient.FiltersDialogs;

namespace Logi.KritaPlugin.DynamicFolders
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
                true,
                "Logi.KritaPlugin.images.Filters.filters-Levels.png",
                [
                    new AdjustmentDefinition("Input Black", (dialog, delta) => ((KritaFilterLevels)dialog.Dialog).AdjustInputBlackValue((int)delta).Result, 0),
                    new AdjustmentDefinition("Input Gamma",
                        (dialog, delta) => ((KritaFilterLevels)dialog.Dialog).AdjustInputGamma(delta).Result,
                        1.0f, (val, delta) => val / (1 + (float)delta / 100) - val, 3),
                    new AdjustmentDefinition("Input White", (dialog, delta) => ((KritaFilterLevels)dialog.Dialog).AdjustInputWhiteValue((int)delta).Result, 255),
                    new AdjustmentDefinition("Output Black", (dialog, delta) => ((KritaFilterLevels)dialog.Dialog).AdjustOutputBlackValue((int)delta).Result, 0),
                    new AdjustmentDefinition("Output  White", (dialog, delta) => ((KritaFilterLevels)dialog.Dialog).AdjustOutputWhiteValue((int)delta).Result, 255),

                    new CommandDefinition("Lightness", (dialog) => ((KritaFilterLevels)dialog.Dialog).SetLightnessMode()),
                    new CommandDefinition("All channels", (dialog) => ((KritaFilterLevels)dialog.Dialog).SetAllChannelsMode()),

                    new CommandDefinition("Reset", (dialog) => ((KritaFilterLevels)dialog.Dialog).ResetAll()),
                    new CommandDefinition("Reset input levels", (dialog) => ((KritaFilterLevels)dialog.Dialog).ResetInputLevels()),
                    new CommandDefinition("Reset output levels", (dialog) => ((KritaFilterLevels)dialog.Dialog).ResetoutputLevels()),

                    new CommandDefinition("Linear histogram", (dialog) => ((KritaFilterLevels)dialog.Dialog).SetLinearHistogram()),
                    new CommandDefinition("Logarithmic histogram", (dialog) => ((KritaFilterLevels)dialog.Dialog).SetLogarithmicHistogram()),
                    new CommandDefinition("Scale to fit", (dialog) => ((KritaFilterLevels)dialog.Dialog).SetScaleHistogramToFit()),
                    new CommandDefinition("Scale to cut long peaks", (dialog) => ((KritaFilterLevels)dialog.Dialog).SetScaleHistogramToCutLongPeaks()),

                    new CommandDefinition("Channel RGBA", (dialog) => ((KritaFilterLevels)dialog.Dialog).SetChannel(KritaFilterLevels.Channel.RGBA)),
                    new CommandDefinition("Channel Red", (dialog) => ((KritaFilterLevels)dialog.Dialog).SetChannel(KritaFilterLevels.Channel.Red)),
                    new CommandDefinition("Channel Green", (dialog) => ((KritaFilterLevels)dialog.Dialog).SetChannel(KritaFilterLevels.Channel.Green)),
                    new CommandDefinition("Channel Blue", (dialog) => ((KritaFilterLevels)dialog.Dialog).SetChannel(KritaFilterLevels.Channel.Blue)),
                    new CommandDefinition("Channel Alpha", (dialog) => ((KritaFilterLevels)dialog.Dialog).SetChannel(KritaFilterLevels.Channel.Alpha)),
                    new CommandDefinition("Channel Hue", (dialog) => ((KritaFilterLevels)dialog.Dialog).SetChannel(KritaFilterLevels.Channel.Hue)),
                    new CommandDefinition("Channel Saturation", (dialog) => ((KritaFilterLevels)dialog.Dialog).SetChannel(KritaFilterLevels.Channel.Saturation)),
                    new CommandDefinition("Channel Lightness", (dialog) => ((KritaFilterLevels)dialog.Dialog).SetChannel(KritaFilterLevels.Channel.Lightness)),

                    new CommandDefinition("Auto levels", (dialog) => ((KritaFilterLevels)dialog.Dialog).ApplyAutoLevels()),
                    new CommandDefinition("Reset all channels", (dialog) => ((KritaFilterLevels)dialog.Dialog).ResetAllChannels()),
                ]);
        }
    }
}
