using System.Runtime.CompilerServices;
using Loupedeck.KritaPlugin.DynamicFolders.FilterDefinitions;
using LoupedeckKritaApiClient.FiltersDialogs;

namespace Loupedeck.KritaPlugin.DynamicFolders
{
    public class FilterPerChannelColorAdjustment : FilterDialogBase
    {
        public FilterPerChannelColorAdjustment()
            : base(GetDefinition())
        {
        }

        static internal FilterDialogDefinition GetDefinition()
        {
            return new FilterDialogDefinition("Color Adjustment",
                FiltersEnum.PerChannelColorAdjustment,
                [
                    new FilterCommandDefinition("Channel RGBA", (dialog) => ((KritaFilterPerChannelColorAdjustment)dialog.Dialog).SetChannel(KritaFilterPerChannelColorAdjustment.Channel.RGBA)),
                    new FilterCommandDefinition("Channel Red", (dialog) => ((KritaFilterPerChannelColorAdjustment)dialog.Dialog).SetChannel(KritaFilterPerChannelColorAdjustment.Channel.Red)),
                    new FilterCommandDefinition("Channel Green", (dialog) => ((KritaFilterPerChannelColorAdjustment)dialog.Dialog).SetChannel(KritaFilterPerChannelColorAdjustment.Channel.Green)),
                    new FilterCommandDefinition("Channel Blue", (dialog) => ((KritaFilterPerChannelColorAdjustment)dialog.Dialog).SetChannel(KritaFilterPerChannelColorAdjustment.Channel.Blue)),
                    new FilterCommandDefinition("Channel Alpha", (dialog) => ((KritaFilterPerChannelColorAdjustment)dialog.Dialog).SetChannel(KritaFilterPerChannelColorAdjustment.Channel.Alpha)),
                    new FilterCommandDefinition("Channel Hue", (dialog) => ((KritaFilterPerChannelColorAdjustment)dialog.Dialog).SetChannel(KritaFilterPerChannelColorAdjustment.Channel.Hue)),
                    new FilterCommandDefinition("Channel Saturation", (dialog) => ((KritaFilterPerChannelColorAdjustment)dialog.Dialog).SetChannel(KritaFilterPerChannelColorAdjustment.Channel.Saturation)),
                    new FilterCommandDefinition("Channel Lightness", (dialog) => ((KritaFilterPerChannelColorAdjustment)dialog.Dialog).SetChannel(KritaFilterPerChannelColorAdjustment.Channel.Lightness)),

                    new FilterCommandDefinition("Logarithmic", (dialog) => ((KritaFilterPerChannelColorAdjustment)dialog.Dialog).ToggleLogarithmic()),
                    new FilterCommandDefinition("Reset", (dialog) => ((KritaFilterPerChannelColorAdjustment)dialog.Dialog).Reset()),
                ],
                [
                    new FilterAdjustmentDefinition("Input", (dialog, _, delta) => ((KritaFilterPerChannelColorAdjustment)dialog.Dialog).AdjustInValue(delta).Result),
                    new FilterAdjustmentDefinition("Output", (dialog, _, delta) => ((KritaFilterPerChannelColorAdjustment)dialog.Dialog).AdjustOutValue(delta).Result),
                ]);
        }
    }
}
