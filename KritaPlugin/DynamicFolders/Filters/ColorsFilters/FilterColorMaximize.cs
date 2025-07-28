using LogiKritaApiClient.FiltersDialogs;

namespace Logi.KritaPlugin.DynamicFolders
{
    public class FilterColorMaximize
    {
        static internal FilterDialogDefinition GetDefinition()
        {
            return new FilterDialogDefinition("Maximize channels",
                FilterNames.Maximize,
                true,
                "Logi.KritaPlugin.images.Filters.filters-Maximize.png");
        }
    }
}
