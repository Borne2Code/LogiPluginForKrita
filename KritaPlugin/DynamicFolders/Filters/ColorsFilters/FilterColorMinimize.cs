using LogiKritaApiClient.FiltersDialogs;

namespace Logi.KritaPlugin.DynamicFolders
{
    public class FilterColorMinimize
    {
        static internal FilterDialogDefinition GetDefinition()
        {
            return new FilterDialogDefinition("Minimize channels",
                FilterNames.Minimize,
                true,
                "Logi.KritaPlugin.images.Filters.filters-Minimize.png");
        }
    }
}
