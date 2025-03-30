using LoupedeckKritaApiClient.FiltersDialogs;

namespace Loupedeck.KritaPlugin.DynamicFolders
{
    public class FilterEmbossAllDirections
    {
        static internal FilterDialogDefinition GetDefinition()
        {
            return new FilterDialogDefinition("Emboss All directions",
                FilterNames.EmbossAllDirections,
                true,
                "Loupedeck.KritaPlugin.images.Filters.filters-EmbossAllDirections.png");
        }
    }
}
