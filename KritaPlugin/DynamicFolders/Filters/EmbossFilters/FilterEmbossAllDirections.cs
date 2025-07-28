using LogiKritaApiClient.FiltersDialogs;

namespace Logi.KritaPlugin.DynamicFolders
{
    public class FilterEmbossAllDirections
    {
        static internal FilterDialogDefinition GetDefinition()
        {
            return new FilterDialogDefinition("Emboss All directions",
                FilterNames.EmbossAllDirections,
                true,
                "Logi.KritaPlugin.images.Filters.filters-EmbossAllDirections.png");
        }
    }
}
