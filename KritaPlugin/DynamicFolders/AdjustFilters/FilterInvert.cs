using LoupedeckKritaApiClient.FiltersDialogs;

namespace Loupedeck.KritaPlugin.DynamicFolders
{
    public class FilterInvert
    {
        static internal FilterDialogDefinition GetDefinition()
        {
            return new FilterDialogDefinition("Invert",
                FilterNames.Invert,
                true,
                "Loupedeck.KritaPlugin.images.Filters.filters-Invert.png");
        }
    }
}
