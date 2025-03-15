using LoupedeckKritaApiClient.FiltersDialogs;

namespace Loupedeck.KritaPlugin.DynamicFolders
{
    public class FilterColorMaximize : FilterDialogBase
    {
        public FilterColorMaximize()
            : base(FilterNames.Maximize)
        {
        }

        static internal FilterDialogDefinition GetDefinition()
        {
            return new FilterDialogDefinition("Maximize channels",
                FilterNames.Maximize,
                "Loupedeck.KritaPlugin.images.Filters.filters-Maximize.png");
        }
    }
}
