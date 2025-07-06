using LogiKritaApiClient.FiltersDialogs;

namespace Logi.KritaPlugin.DynamicFolders
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
                "Logi.KritaPlugin.images.Filters.filters-RoundCorners.png",
                [
                    new AdjustmentDefinition("Radius", (dialog, delta) => (dialog.Dialog as KritaFilterRoundCorners).AdjustRadius((int)delta).Result, 30),
                ]);
        }
    }
}
