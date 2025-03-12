using LoupedeckKritaApiClient.FiltersDialogs;

namespace Loupedeck.KritaPlugin.DynamicFolders
{
    public class FilterHalftone : FilterDialogBase
    {
        public FilterHalftone()
            : base(FilterNames.Halftone)
        {
        }

        static internal DialogDefinition GetDefinition()
        {
            return new DialogDefinition("Halftone",
                FilterNames.Halftone,
                [],
                []);
        }
    }
}
