using LoupedeckKritaApiClient.FiltersDialogs;

namespace Loupedeck.KritaPlugin.DynamicFolders
{
    public class FilterRandomPick : FilterDialogBase
    {
        public FilterRandomPick()
            : base(FilterNames.RandomPick)
        {
        }

        static internal FilterDialogDefinition GetDefinition()
        {
            return new FilterDialogDefinition("Random Pick",
                FilterNames.RandomPick,
                [],
                [
                    new FilterAdjustmentDefinition("Level", (dialog, delta) => ((KritaFilterRandomPick)dialog.Dialog).AdjustLevel((int)delta).Result, 50),
                    new FilterAdjustmentDefinition("Window Size", (dialog, delta) => ((KritaFilterRandomPick)dialog.Dialog).AdjustWindowSize((int)delta).Result, 3),
                    new FilterAdjustmentDefinition("Opacity", (dialog, delta) => ((KritaFilterRandomPick)dialog.Dialog).AdjustOpacity((int)delta).Result, 99),
                ]);
        }
    }
}
