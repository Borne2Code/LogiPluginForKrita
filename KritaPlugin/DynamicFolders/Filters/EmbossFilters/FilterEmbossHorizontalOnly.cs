using LogiKritaApiClient.FiltersDialogs;

namespace Logi.KritaPlugin.DynamicFolders
{
    public class FilterEmbossHorizontalOnly
    {
        static internal FilterDialogDefinition GetDefinition()
        {
            return new FilterDialogDefinition("Emboss Horizontal only",
                FilterNames.EmbossHorizontalOnly,
                true,
                "Logi.KritaPlugin.images.Filters.filters-EmbossHorizontal.png");
        }
    }
}
