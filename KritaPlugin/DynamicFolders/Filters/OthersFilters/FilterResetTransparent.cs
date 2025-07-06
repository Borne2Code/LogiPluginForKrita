using LogiKritaApiClient.FiltersDialogs;

namespace Logi.KritaPlugin.DynamicFolders
{
    public class FilterResetTransparent
    {
        static internal FilterDialogDefinition GetDefinition()
        {
            return new FilterDialogDefinition("Reset Transparent",
                FilterNames.ResetTransparent,
                false,
                "Logi.KritaPlugin.images.Filters.filters-ResetTransparent.png");
        }
    }
}
