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
                true,
                "Loupedeck.KritaPlugin.images.Filters.filters-RandomPick.png",
                [
                    new AdjustmentDefinition("Level", (dialog, delta) => (dialog.Dialog as KritaFilterRandomPick).AdjustLevel((int)delta).Result, 50),
                    new AdjustmentDefinition("Window Size", (dialog, delta) => (dialog.Dialog as KritaFilterRandomPick).AdjustWindowSize((int)delta).Result, 3),
                    new AdjustmentDefinition("Opacity", (dialog, delta) => (dialog.Dialog as KritaFilterRandomPick).AdjustOpacity((int)delta).Result, 99),
                ]);
        }
    }
}
