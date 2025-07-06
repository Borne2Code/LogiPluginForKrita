using LogiKritaApiClient.FiltersDialogs;

namespace Logi.KritaPlugin.DynamicFolders
{
    public class FilterSharpen
    {
        static internal FilterDialogDefinition GetDefinition()
        {
            return new FilterDialogDefinition("Sharpen",
                FilterNames.Sharpen,
                true,
                "Logi.KritaPlugin.images.Filters.filters-Sharpen.png");
        }
    }
}
