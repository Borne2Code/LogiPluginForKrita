using LogiKritaApiClient.FiltersDialogs;

namespace Logi.KritaPlugin.DynamicFolders
{
    public class FilterEmbossLaplacian
    {
        static internal FilterDialogDefinition GetDefinition()
        {
            return new FilterDialogDefinition("Emboss Laplascian",
                FilterNames.EmbossLaplascian,
                true,
                "Logi.KritaPlugin.images.Filters.filters-EmbossLaplacian.png");
        }
    }
}
