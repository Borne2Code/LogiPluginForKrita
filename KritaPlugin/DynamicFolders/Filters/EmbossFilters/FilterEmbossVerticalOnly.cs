using LoupedeckKritaApiClient.FiltersDialogs;

namespace Loupedeck.KritaPlugin.DynamicFolders
{
    public class FilterEmbossVerticalOnly
    {
        static internal FilterDialogDefinition GetDefinition()
        {
            return new FilterDialogDefinition("Emboss Vertical only",
                FilterNames.EmbossVerticalOnly,
                true,
                "Loupedeck.KritaPlugin.images.Filters.filters-EmbossVertical.png");
        }
    }
}
