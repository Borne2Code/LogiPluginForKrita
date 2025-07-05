using LoupedeckKritaApiClient.FiltersDialogs;

namespace Loupedeck.KritaPlugin.DynamicFolders
{
    public class FilterEmbossHorizontalOnly
    {
        static internal FilterDialogDefinition GetDefinition()
        {
            return new FilterDialogDefinition("Emboss Horizontal only",
                FilterNames.EmbossHorizontalOnly,
                true,
                "Loupedeck.KritaPlugin.images.Filters.filters-EmbossHorizontal.png");
        }
    }
}
