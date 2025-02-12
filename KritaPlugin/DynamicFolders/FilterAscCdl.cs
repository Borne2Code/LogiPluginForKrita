using Loupedeck.KritaPlugin.DynamicFolders.FilterDefinitions;
using LoupedeckKritaApiClient.FiltersDialogs;

namespace Loupedeck.KritaPlugin.DynamicFolders
{
    public class FilterAscCdl : FilterDialogBase
    {
        public FilterAscCdl()
            : base(GetDefinition())
        {
        }

        static internal FilterDialogDefinition GetDefinition()
        {
            return new FilterDialogDefinition("Slope / Offset / Power (Asc-Cdl)",
                FiltersEnum.AscCdl,
                [],
                []);
        }
    }
}
