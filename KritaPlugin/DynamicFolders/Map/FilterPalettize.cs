using LoupedeckKritaApiClient.FiltersDialogs;

namespace Loupedeck.KritaPlugin.DynamicFolders
{
    public class FilterPalettize : FilterDialogBase
    {
        public FilterPalettize()
            : base(FilterNames.Palettize)
        {
        }

        static internal FilterDialogDefinition GetDefinition()
        {
            return new FilterDialogDefinition("Palettize",
                FilterNames.Palettize,
                [],
                []);
        }
    }
}
