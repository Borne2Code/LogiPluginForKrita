using LogiKritaApiClient.FiltersDialogs;

namespace Logi.KritaPlugin.DynamicFolders
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
                "Logi.KritaPlugin.images.Filters.filters-AscCdl.png",
                []);
        }
    }
}
