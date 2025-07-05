using LoupedeckKritaApiClient.FiltersDialogs;

namespace Loupedeck.KritaPlugin.DynamicFolders
{
    public class FilterSharpen
    {
        static internal FilterDialogDefinition GetDefinition()
        {
            return new FilterDialogDefinition("Sharpen",
                FilterNames.Sharpen,
                true,
                "Loupedeck.KritaPlugin.images.Filters.filters-Sharpen.png");
        }
    }
}
