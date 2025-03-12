using LoupedeckKritaApiClient.FiltersDialogs;

namespace Loupedeck.KritaPlugin.DynamicFolders
{
    public class FilterPalettize : FilterDialogBase
    {
        public FilterPalettize()
            : base(FilterNames.Palettize)
        {
        }

        static internal DialogDefinition GetDefinition()
        {
            return new DialogDefinition("Palettize",
                FilterNames.Palettize,
                [],
                []);
        }
    }
}
