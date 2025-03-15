using LoupedeckKritaApiClient.FiltersDialogs;

namespace Loupedeck.KritaPlugin.DynamicFolders
{
    public class FilterHalftone : FilterDialogBase
    {
        public FilterHalftone()
            : base(FilterNames.Halftone)
        {
        }

        static internal FilterDialogDefinition GetDefinition()
        {
            return new FilterDialogDefinition("Halftone",
                FilterNames.Halftone,
                "Loupedeck.KritaPlugin.images.Filters.filters-Halftone.png",
                [],
                []);
        }
    }
}
