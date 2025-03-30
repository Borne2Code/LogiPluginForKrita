using LoupedeckKritaApiClient.FiltersDialogs;

namespace Loupedeck.KritaPlugin.DynamicFolders
{
    public class FilterAscCdl : FilterDialogBase
    {
        public FilterAscCdl()
            : base(FilterNames.AscCdl)
        {
        }

        static internal FilterDialogDefinition GetDefinition()
        {
            return new FilterDialogDefinition("Slope / Offset / Power (Asc-Cdl)",
                FilterNames.AscCdl,
                true,
                "Loupedeck.KritaPlugin.images.Filters.filters-AscCdl.png",
                [],
                []);
        }
    }
}
