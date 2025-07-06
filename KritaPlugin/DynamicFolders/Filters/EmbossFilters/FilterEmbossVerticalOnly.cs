using LogiKritaApiClient.FiltersDialogs;

namespace Logi.KritaPlugin.DynamicFolders
{
    public class FilterEmbossVerticalOnly
    {
        static internal FilterDialogDefinition GetDefinition()
        {
            return new FilterDialogDefinition("Emboss Vertical only",
                FilterNames.EmbossVerticalOnly,
                true,
                "Logi.KritaPlugin.images.Filters.filters-EmbossVertical.png");
        }
    }
}
