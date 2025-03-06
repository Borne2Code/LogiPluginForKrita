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
                [],
                [
                    new FilterAdjustmentDefinition("Threshold", (dialog, delta) => ((KritaFilterColorToAlpha)dialog.Dialog).AdjustThreshold((int)delta).Result, 100),
                ]);
        }
    }
}
