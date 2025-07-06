using LogiKritaApiClient.FiltersDialogs;

namespace Logi.KritaPlugin.DynamicFolders
{
    public class FilterInvert
    {
        static internal FilterDialogDefinition GetDefinition()
        {
            return new FilterDialogDefinition("Invert",
                FilterNames.Invert,
                true,
                "Logi.KritaPlugin.images.Filters.filters-Invert.png");
        }
    }
}
