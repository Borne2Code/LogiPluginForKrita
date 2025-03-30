using LoupedeckKritaApiClient.FiltersDialogs;

namespace Loupedeck.KritaPlugin.DynamicFolders
{
    public class FilterColorMinimize : FilterDialogBase
    {
        public FilterColorMinimize()
            : base(FilterNames.Minimize)
        {
        }

        static internal FilterDialogDefinition GetDefinition()
        {
            return new FilterDialogDefinition("Minimize channels",
                FilterNames.Minimize,
                true,
                "Loupedeck.KritaPlugin.images.Filters.filters-Minimize.png");
        }
    }
}
