using LoupedeckKritaApiClient.FiltersDialogs;

namespace Loupedeck.KritaPlugin.DynamicFolders
{
    public class FilterColorToAlpha : FilterDialogBase
    {
        public FilterColorToAlpha()
            : base(FilterNames.ColorToAlpha)
        {
        }

        static internal FilterDialogDefinition GetDefinition()
        {
            return new FilterDialogDefinition("Color to alpha",
                FilterNames.ColorToAlpha,
                true,
                "Loupedeck.KritaPlugin.images.Filters.filters-ColorToAlpha.png",
                [
                    new AdjustmentDefinition("Threshold", (dialog, delta) => (dialog.Dialog as KritaFilterColorToAlpha).AdjustThreshold((int)delta).Result, 100),
                ]);
        }
    }
}
