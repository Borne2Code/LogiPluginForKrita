using LogiKritaApiClient.FiltersDialogs;

namespace Logi.KritaPlugin.DynamicFolders
{
    public class FilterThreshold : FilterDialogBase
    {
        public FilterThreshold()
            : base(FilterNames.Threshold)
        {
        }

        static internal FilterDialogDefinition GetDefinition()
        {
            return new FilterDialogDefinition("Threshold",
                FilterNames.Threshold,
                true,
                "Logi.KritaPlugin.images.Filters.filters-Threshold.png",
                [
                    new AdjustmentDefinition("Threshold", (dialog, delta) => (dialog.Dialog as KritaFilterThreshold).AdjustThreshold((int)delta).Result, 128)
                ]);
        }
    }
}
