using Loupedeck.KritaPlugin.DynamicFolders.FilterDefinitions;
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
                    new FilterAdjustmentDefinition("Threshold", (dialog, _, delta) => ((KritaFilterColorToAlpha)dialog.Dialog).AdjustThreshold(delta).Result),
                ]);
        }
    }
}
