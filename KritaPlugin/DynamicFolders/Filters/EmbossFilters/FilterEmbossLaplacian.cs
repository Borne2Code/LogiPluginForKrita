using LoupedeckKritaApiClient.FiltersDialogs;

namespace Loupedeck.KritaPlugin.DynamicFolders
{
    public class FilterEmbossLaplacian
    {
        static internal FilterDialogDefinition GetDefinition()
        {
            return new FilterDialogDefinition("Emboss Laplascian",
                FilterNames.EmbossLaplascian,
                true,
                "Loupedeck.KritaPlugin.images.Filters.filters-EmbossLaplacian.png");
        }
    }
}
