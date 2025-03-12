using LoupedeckKritaApiClient.FiltersDialogs;

namespace Loupedeck.KritaPlugin.DynamicFolders
{
    public class FilterColorToAlpha : FilterDialogBase
    {
        public FilterColorToAlpha()
            : base(FilterNames.ColorToAlpha)
        {
        }

        static internal DialogDefinition GetDefinition()
        {
            return new DialogDefinition("Color to alpha",
                FilterNames.ColorToAlpha,
                [],
                [
                    new AdjustmentDefinition("Threshold", (dialog, delta) => (dialog.Dialog as KritaFilterColorToAlpha).AdjustThreshold((int)delta).Result, 100),
                ]);
        }
    }
}
