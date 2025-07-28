using LogiKritaApiClient.FiltersDialogs;

namespace Logi.KritaPlugin.DynamicFolders
{
    public class FilterMeanRemoval
    {
        static internal FilterDialogDefinition GetDefinition()
        {
            return new FilterDialogDefinition("Mean removal",
                FilterNames.MeanRemoval,
                true,
                "Logi.KritaPlugin.images.Filters.filters-MeanRemoval.png");
        }
    }
}
