using LogiKritaApiClient.FiltersDialogs;

namespace Logi.KritaPlugin.DynamicFolders
{
    public class FilterAutoContrast
    {
        static internal FilterDialogDefinition GetDefinition()
        {
            return new FilterDialogDefinition("Auto Contrast",
                FilterNames.AutoConstrast,
                false,
                "Logi.KritaPlugin.images.Filters.filters-AutoContrast.png");
        }
    }
}
