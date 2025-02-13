using Loupedeck.KritaPlugin.DynamicFolders.FilterDefinitions;
using LoupedeckKritaApiClient.FiltersDialogs;

namespace Loupedeck.KritaPlugin.DynamicFolders
{
    public class FilterHalftone : FilterDialogBase
    {
        public FilterHalftone()
            : base(GetDefinition())
        {
        }

        static internal FilterDialogDefinition GetDefinition()
        {
            return new FilterDialogDefinition("Halftone",
                FiltersEnum.Halftone,
                [],
                []);
        }
    }
}
