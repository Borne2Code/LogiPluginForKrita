using System.Runtime.CompilerServices;
using LoupedeckKritaApiClient.FiltersDialogs;

namespace Loupedeck.KritaPlugin.DynamicFolders
{
    public class FilterCrossChannelColorAdjustment : FilterDialogBase
    {
        public FilterCrossChannelColorAdjustment()
            : base(GetDefinition())
        {
        }

        static internal FilterDialogDefinition GetDefinition()
        {
            return new FilterDialogDefinition("Cross channel Adjustment",
                FiltersEnum.CrossChannel,
                [
                    new FilterCommandDefinition("Channel RGBA", (dialog) => ((KritaFilterCrossChannel)dialog.Dialog).SetTargetChannelIndex(KritaFilterCrossChannel.TargetChannel.RGBA)),
                    new FilterCommandDefinition("Channel Red", (dialog) => ((KritaFilterCrossChannel)dialog.Dialog).SetTargetChannelIndex(KritaFilterCrossChannel.TargetChannel.Red)),
                    new FilterCommandDefinition("Channel Green", (dialog) => ((KritaFilterCrossChannel)dialog.Dialog).SetTargetChannelIndex(KritaFilterCrossChannel.TargetChannel.Green)),
                    new FilterCommandDefinition("Channel Blue", (dialog) => ((KritaFilterCrossChannel)dialog.Dialog).SetTargetChannelIndex(KritaFilterCrossChannel.TargetChannel.Blue)),
                    new FilterCommandDefinition("Channel Alpha", (dialog) => ((KritaFilterCrossChannel)dialog.Dialog).SetTargetChannelIndex(KritaFilterCrossChannel.TargetChannel.Alpha)),
                    new FilterCommandDefinition("Channel Hue", (dialog) => ((KritaFilterCrossChannel)dialog.Dialog).SetTargetChannelIndex(KritaFilterCrossChannel.TargetChannel.Hue)),
                    new FilterCommandDefinition("Channel Saturation", (dialog) => ((KritaFilterCrossChannel)dialog.Dialog).SetTargetChannelIndex(KritaFilterCrossChannel.TargetChannel.Saturation)),
                    new FilterCommandDefinition("Channel Lightness", (dialog) => ((KritaFilterCrossChannel)dialog.Dialog).SetTargetChannelIndex(KritaFilterCrossChannel.TargetChannel.Lightness)),

                    new FilterCommandDefinition("Driver Red", (dialog) => ((KritaFilterCrossChannel)dialog.Dialog).SetDriverChannelIndex(KritaFilterCrossChannel.DriverChannel.Red)),
                    new FilterCommandDefinition("Driver Green", (dialog) => ((KritaFilterCrossChannel)dialog.Dialog).SetDriverChannelIndex(KritaFilterCrossChannel.DriverChannel.Green)),
                    new FilterCommandDefinition("Driver Blue", (dialog) => ((KritaFilterCrossChannel)dialog.Dialog).SetDriverChannelIndex(KritaFilterCrossChannel.DriverChannel.Blue)),
                    new FilterCommandDefinition("Driver Alpha", (dialog) => ((KritaFilterCrossChannel)dialog.Dialog).SetDriverChannelIndex(KritaFilterCrossChannel.DriverChannel.Alpha)),
                    new FilterCommandDefinition("Driver Hue", (dialog) => ((KritaFilterCrossChannel)dialog.Dialog).SetDriverChannelIndex(KritaFilterCrossChannel.DriverChannel.Hue)),
                    new FilterCommandDefinition("Driver Saturation", (dialog) => ((KritaFilterCrossChannel)dialog.Dialog).SetDriverChannelIndex(KritaFilterCrossChannel.DriverChannel.Saturation)),
                    new FilterCommandDefinition("Driver Lightness", (dialog) => ((KritaFilterCrossChannel)dialog.Dialog).SetDriverChannelIndex(KritaFilterCrossChannel.DriverChannel.Lightness)),

                    new FilterCommandDefinition("Logarithmic", (dialog) => ((KritaFilterCrossChannel)dialog.Dialog).ToggleLogarithmic()),
                    new FilterCommandDefinition("Reset", (dialog) => ((KritaFilterCrossChannel)dialog.Dialog).Reset()),
                ],
                [
                    new FilterAdjustmentDefinition("Input", (dialog, delta) => ((KritaFilterCrossChannel)dialog.Dialog).AdjustInputValue((int)delta).Result),
                    new FilterAdjustmentDefinition("Output", (dialog, delta) => ((KritaFilterCrossChannel)dialog.Dialog).AdjustOutputValue((int)delta).Result),
                ]);
        }
    }
}
