using LogiKritaApiClient.FiltersDialogs;

namespace Logi.KritaPlugin.DynamicFolders
{
    public class FilterPerChannelColorAdjustment : FilterDialogBase
    {
        public FilterPerChannelColorAdjustment()
            : base(FilterNames.PerChannelColorAdjustment)
        {
        }

        static internal FilterDialogDefinition GetDefinition()
        {
            return new FilterDialogDefinition("Color Adjustment",
                FilterNames.PerChannelColorAdjustment,
                true,
                "Logi.KritaPlugin.images.Filters.filters-ColorAdjustment.png",
                [
                    new AdjustmentDefinition("Input", (dialog, delta) => ((KritaFilterPerChannelColorAdjustment)dialog.Dialog).AdjustInValue((int)delta).Result),
                    new AdjustmentDefinition("Output", (dialog, delta) => ((KritaFilterPerChannelColorAdjustment)dialog.Dialog).AdjustOutValue((int)delta).Result),

                    new CommandDefinition("Channel RGBA", (dialog) => ((KritaFilterPerChannelColorAdjustment)dialog.Dialog).SetChannel(KritaFilterPerChannelColorAdjustment.Channel.RGBA)),
                    new CommandDefinition("Channel Red", (dialog) => ((KritaFilterPerChannelColorAdjustment)dialog.Dialog).SetChannel(KritaFilterPerChannelColorAdjustment.Channel.Red)),
                    new CommandDefinition("Channel Green", (dialog) => ((KritaFilterPerChannelColorAdjustment)dialog.Dialog).SetChannel(KritaFilterPerChannelColorAdjustment.Channel.Green)),
                    new CommandDefinition("Channel Blue", (dialog) => ((KritaFilterPerChannelColorAdjustment)dialog.Dialog).SetChannel(KritaFilterPerChannelColorAdjustment.Channel.Blue)),
                    new CommandDefinition("Channel Alpha", (dialog) => ((KritaFilterPerChannelColorAdjustment)dialog.Dialog).SetChannel(KritaFilterPerChannelColorAdjustment.Channel.Alpha)),
                    new CommandDefinition("Channel Hue", (dialog) => ((KritaFilterPerChannelColorAdjustment)dialog.Dialog).SetChannel(KritaFilterPerChannelColorAdjustment.Channel.Hue)),
                    new CommandDefinition("Channel Saturation", (dialog) => ((KritaFilterPerChannelColorAdjustment)dialog.Dialog).SetChannel(KritaFilterPerChannelColorAdjustment.Channel.Saturation)),
                    new CommandDefinition("Channel Lightness", (dialog) => ((KritaFilterPerChannelColorAdjustment)dialog.Dialog).SetChannel(KritaFilterPerChannelColorAdjustment.Channel.Lightness)),

                    new CommandDefinition("Logarithmic", (dialog) => ((KritaFilterPerChannelColorAdjustment)dialog.Dialog).ToggleLogarithmic()),
                    new CommandDefinition("Reset", (dialog) => ((KritaFilterPerChannelColorAdjustment)dialog.Dialog).Reset()),
                ]);
        }
    }
}
