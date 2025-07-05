using LoupedeckKritaApiClient.FiltersDialogs;

namespace Loupedeck.KritaPlugin.DynamicFolders
{
    public class FilterColorMaximize
    {
        static internal FilterDialogDefinition GetDefinition()
        {
            return new FilterDialogDefinition("Maximize channels",
                FilterNames.Maximize,
                true,
                "Loupedeck.KritaPlugin.images.Filters.filters-Maximize.png");
        }
    }
}
