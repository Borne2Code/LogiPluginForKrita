using LogiKritaApiClient.FiltersDialogs;

namespace Logi.KritaPlugin.DynamicFolders
{
    public class FilterUnsharpMask : FilterDialogBase
    {
        public FilterUnsharpMask()
            : base(FilterNames.Unsharp)
        {
        }

        static internal FilterDialogDefinition GetDefinition()
        {
            return new FilterDialogDefinition("Unsharp Mask",
                FilterNames.Unsharp,
                true,
                "Logi.KritaPlugin.images.Filters.filters-Unsharp.png",
                [
                    new AdjustmentDefinition("Radius", (dialog, delta) => (dialog.Dialog as KritaFilterUnsharp).AdjustRadius(delta).Result, 1),
                    new AdjustmentDefinition("Amount", (dialog, delta) => (dialog.Dialog as KritaFilterUnsharp).AdjustAmount(delta).Result, 0.5f),
                    new AdjustmentDefinition("Threshold", (dialog, delta) => (dialog.Dialog as KritaFilterUnsharp).AdjustThreshold((int)delta).Result, 0),

                    new CommandDefinition("Lightness only", (dialog) => (dialog.Dialog as KritaFilterUnsharp).ToggleLightnessOnly()),
                ]);
        }
    }
}
