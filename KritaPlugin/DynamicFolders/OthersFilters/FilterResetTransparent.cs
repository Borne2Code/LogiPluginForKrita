using LoupedeckKritaApiClient.FiltersDialogs;

namespace Loupedeck.KritaPlugin.DynamicFolders
{
    public class FilterResetTransparent : FilterDialogBase
    {
        public FilterResetTransparent()
            : base(FilterNames.ResetTransparent)
        {
        }

        static internal DialogDefinition GetDefinition()
        {
            return new DialogDefinition("Reset Transparent",
                FilterNames.ResetTransparent);
        }
    }
}
