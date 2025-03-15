using LoupedeckKritaApiClient.FiltersDialogs;

namespace Loupedeck.KritaPlugin.DynamicFolders
{
    public class FilterCrossChannelColorAdjustment : FilterDialogBase
    {
        public FilterCrossChannelColorAdjustment()
            : base(FilterNames.CrossChannel)
        {
        }

        static internal FilterDialogDefinition GetDefinition()
        {
            return new FilterDialogDefinition("Cross channel Adjustment",
                FilterNames.CrossChannel,
                "Loupedeck.KritaPlugin.images.Filters.filters-CrossChannelColorAdjustment.png",
                [
                    new CommandDefinition("Channel RGBA", (dialog) => ((KritaFilterCrossChannel)dialog.Dialog).SetTargetChannelIndex(KritaFilterCrossChannel.TargetChannel.RGBA)),
                    new CommandDefinition("Channel Red", (dialog) => ((KritaFilterCrossChannel)dialog.Dialog).SetTargetChannelIndex(KritaFilterCrossChannel.TargetChannel.Red)),
                    new CommandDefinition("Channel Green", (dialog) => ((KritaFilterCrossChannel)dialog.Dialog).SetTargetChannelIndex(KritaFilterCrossChannel.TargetChannel.Green)),
                    new CommandDefinition("Channel Blue", (dialog) => ((KritaFilterCrossChannel)dialog.Dialog).SetTargetChannelIndex(KritaFilterCrossChannel.TargetChannel.Blue)),
                    new CommandDefinition("Channel Alpha", (dialog) => ((KritaFilterCrossChannel)dialog.Dialog).SetTargetChannelIndex(KritaFilterCrossChannel.TargetChannel.Alpha)),
                    new CommandDefinition("Channel Hue", (dialog) => ((KritaFilterCrossChannel)dialog.Dialog).SetTargetChannelIndex(KritaFilterCrossChannel.TargetChannel.Hue)),
                    new CommandDefinition("Channel Saturation", (dialog) => ((KritaFilterCrossChannel)dialog.Dialog).SetTargetChannelIndex(KritaFilterCrossChannel.TargetChannel.Saturation)),
                    new CommandDefinition("Channel Lightness", (dialog) => ((KritaFilterCrossChannel)dialog.Dialog).SetTargetChannelIndex(KritaFilterCrossChannel.TargetChannel.Lightness)),

                    new CommandDefinition("Driver Red", (dialog) => ((KritaFilterCrossChannel)dialog.Dialog).SetDriverChannelIndex(KritaFilterCrossChannel.DriverChannel.Red)),
                    new CommandDefinition("Driver Green", (dialog) => ((KritaFilterCrossChannel)dialog.Dialog).SetDriverChannelIndex(KritaFilterCrossChannel.DriverChannel.Green)),
                    new CommandDefinition("Driver Blue", (dialog) => ((KritaFilterCrossChannel)dialog.Dialog).SetDriverChannelIndex(KritaFilterCrossChannel.DriverChannel.Blue)),
                    new CommandDefinition("Driver Alpha", (dialog) => ((KritaFilterCrossChannel)dialog.Dialog).SetDriverChannelIndex(KritaFilterCrossChannel.DriverChannel.Alpha)),
                    new CommandDefinition("Driver Hue", (dialog) => ((KritaFilterCrossChannel)dialog.Dialog).SetDriverChannelIndex(KritaFilterCrossChannel.DriverChannel.Hue)),
                    new CommandDefinition("Driver Saturation", (dialog) => ((KritaFilterCrossChannel)dialog.Dialog).SetDriverChannelIndex(KritaFilterCrossChannel.DriverChannel.Saturation)),
                    new CommandDefinition("Driver Lightness", (dialog) => ((KritaFilterCrossChannel)dialog.Dialog).SetDriverChannelIndex(KritaFilterCrossChannel.DriverChannel.Lightness)),

                    new CommandDefinition("Logarithmic", (dialog) => ((KritaFilterCrossChannel)dialog.Dialog).ToggleLogarithmic()),
                    new CommandDefinition("Reset", (dialog) => ((KritaFilterCrossChannel)dialog.Dialog).Reset()),
                ],
                [
                    new AdjustmentDefinition("Input", (dialog, delta) => ((KritaFilterCrossChannel)dialog.Dialog).AdjustInputValue((int)delta).Result),
                    new AdjustmentDefinition("Output", (dialog, delta) => ((KritaFilterCrossChannel)dialog.Dialog).AdjustOutputValue((int)delta).Result),
                ]);
        }
    }
}
