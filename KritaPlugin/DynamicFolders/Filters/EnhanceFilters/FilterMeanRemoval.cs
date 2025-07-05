using LoupedeckKritaApiClient.FiltersDialogs;

namespace Loupedeck.KritaPlugin.DynamicFolders
{
    public class FilterMeanRemoval
    {
        static internal FilterDialogDefinition GetDefinition()
        {
            return new FilterDialogDefinition("Mean removal",
                FilterNames.MeanRemoval,
                true,
                "Loupedeck.KritaPlugin.images.Filters.filters-MeanRemoval.png");
        }
    }
}
