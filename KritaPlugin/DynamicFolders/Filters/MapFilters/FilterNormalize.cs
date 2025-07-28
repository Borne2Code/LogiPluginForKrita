using LogiKritaApiClient.FiltersDialogs;

namespace Logi.KritaPlugin.DynamicFolders
{
    public class FilterNormalize
    {
        static internal FilterDialogDefinition GetDefinition()
        {
            return new FilterDialogDefinition("Normalize",
                FilterNames.Normalize,
                true,
                "Logi.KritaPlugin.images.Filters.filters-Normalize.png");
        }
    }
}
