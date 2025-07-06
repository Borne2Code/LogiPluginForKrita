using LoupedeckKritaApiClient.FiltersDialogs;

namespace Loupedeck.KritaPlugin.DynamicFolders
{
    public class FilterRoundCorners : FilterDialogBase
    {
        public FilterRoundCorners()
            : base(FilterNames.RoundCorners)
        {
        }

        static internal FilterDialogDefinition GetDefinition()
        {
            return new FilterDialogDefinition("Round Corners",
                FilterNames.RoundCorners,
                true,
                "Loupedeck.KritaPlugin.images.Filters.filters-RoundCorners.png",
                [
                    new AdjustmentDefinition("Radius", (dialog, delta) => (dialog.Dialog as KritaFilterRoundCorners).AdjustRadius((int)delta).Result, 30),
                ]);
        }
    }
}
