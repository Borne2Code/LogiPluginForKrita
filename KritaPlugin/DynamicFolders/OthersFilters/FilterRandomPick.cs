using LoupedeckKritaApiClient.FiltersDialogs;

namespace Loupedeck.KritaPlugin.DynamicFolders
{
    public class FilterRandomPick : FilterDialogBase
    {
        public FilterRandomPick()
            : base(FilterNames.RandomPick)
        {
        }

        static internal DialogDefinition GetDefinition()
        {
            return new DialogDefinition("Random Pick",
                FilterNames.RandomPick,
                [],
                [
                    new AdjustmentDefinition("Level", (dialog, delta) => (dialog.Dialog as KritaFilterRandomPick).AdjustLevel((int)delta).Result, 50),
                    new AdjustmentDefinition("Window Size", (dialog, delta) => (dialog.Dialog as KritaFilterRandomPick).AdjustWindowSize((int)delta).Result, 3),
                    new AdjustmentDefinition("Opacity", (dialog, delta) => (dialog.Dialog as KritaFilterRandomPick).AdjustOpacity((int)delta).Result, 99),
                ]);
        }
    }
}
