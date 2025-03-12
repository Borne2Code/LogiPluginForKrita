using LoupedeckKritaApiClient.FiltersDialogs;

namespace Loupedeck.KritaPlugin.DynamicFolders
{
    public class FilterAutoContrast : FilterDialogBase
    {
        public FilterAutoContrast()
            : base(FilterNames.AutoConstrast)
        {
        }

        static internal DialogDefinition GetDefinition()
        {
            return new DialogDefinition("Auto Contrast",
                FilterNames.AutoConstrast);
        }
    }
}
