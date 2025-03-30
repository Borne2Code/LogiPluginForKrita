using LoupedeckKritaApiClient.FiltersDialogs;

namespace Loupedeck.KritaPlugin.DynamicFolders
{
    public class FilterColorMinimize
    {
        static internal FilterDialogDefinition GetDefinition()
        {
            return new FilterDialogDefinition("Minimize channels",
                FilterNames.Minimize,
                true,
                "Loupedeck.KritaPlugin.images.Filters.filters-Minimize.png");
        }
    }
}
