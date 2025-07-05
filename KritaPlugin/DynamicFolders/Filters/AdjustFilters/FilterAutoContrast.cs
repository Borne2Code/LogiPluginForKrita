using LoupedeckKritaApiClient.FiltersDialogs;

namespace Loupedeck.KritaPlugin.DynamicFolders
{
    public class FilterAutoContrast
    {
        static internal FilterDialogDefinition GetDefinition()
        {
            return new FilterDialogDefinition("Auto Contrast",
                FilterNames.AutoConstrast,
                false,
                "Loupedeck.KritaPlugin.images.Filters.filters-AutoContrast.png");
        }
    }
}
