using LoupedeckKritaApiClient.FiltersDialogs;

namespace Loupedeck.KritaPlugin.DynamicFolders
{
    public class FilterNormalize
    {
        static internal FilterDialogDefinition GetDefinition()
        {
            return new FilterDialogDefinition("Normalize",
                FilterNames.Normalize,
                true,
                "Loupedeck.KritaPlugin.images.Filters.filters-Normalize.png");
        }
    }
}
