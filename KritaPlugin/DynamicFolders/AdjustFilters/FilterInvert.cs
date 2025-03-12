using LoupedeckKritaApiClient.FiltersDialogs;

namespace Loupedeck.KritaPlugin.DynamicFolders
{
    public class FilterInvert : FilterDialogBase
    {
        public FilterInvert()
            : base(FilterNames.Invert)
        {
        }

        static internal DialogDefinition GetDefinition()
        {
            return new DialogDefinition("Invert",
                FilterNames.Invert);
        }
    }
}
