using LoupedeckKritaApiClient.FiltersDialogs;

namespace Loupedeck.KritaPlugin.DynamicFolders
{
    public class FilterAscCdl : FilterDialogBase
    {
        public FilterAscCdl()
            : base(FilterNames.AscCdl)
        {
        }

        static internal DialogDefinition GetDefinition()
        {
            return new DialogDefinition("Slope / Offset / Power (Asc-Cdl)",
                FilterNames.AscCdl,
                [],
                []);
        }
    }
}
