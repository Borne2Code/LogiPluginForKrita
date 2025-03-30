using LoupedeckKritaApiClient.FiltersDialogs;

namespace Loupedeck.KritaPlugin.DynamicFolders
{
    public class FilterMeanRemoval : FilterDialogBase
    {
        public FilterMeanRemoval()
            : base(FilterNames.MeanRemoval)
        {
        }

        static internal FilterDialogDefinition GetDefinition()
        {
            return new FilterDialogDefinition("Mean removal",
                FilterNames.MeanRemoval,
                true,
                "Loupedeck.KritaPlugin.images.Filters.filters-MeanRemoval.png");
        }
    }
}
