using LoupedeckKritaApiClient.FiltersDialogs;

namespace Loupedeck.KritaPlugin.DynamicFolders
{
    public class FilterColorToAlpha : FilterDialogBase
    {
        public FilterColorToAlpha()
            : base(GetDefinition())
        {
        }

        static internal FilterDialogDefinition GetDefinition()
        {
            return new FilterDialogDefinition("Color to alpha",
                FiltersEnum.ColorToAlpha,
                [],
                [
                    new FilterAdjustmentDefinition("Threshold", (dialog, delta) => ((KritaFilterColorToAlpha)dialog.Dialog).AdjustThreshold((int)delta).Result, 100),
                ]);
        }
    }
}
