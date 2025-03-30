using LoupedeckKritaApiClient.FiltersDialogs;

namespace Loupedeck.KritaPlugin.DynamicFolders
{
    public class FilterResetTransparent : FilterDialogBase
    {
        public FilterResetTransparent()
            : base(FilterNames.ResetTransparent)
        {
        }

        static internal FilterDialogDefinition GetDefinition()
        {
            return new FilterDialogDefinition("Reset Transparent",
                FilterNames.ResetTransparent,
                false,
                null);
        }
    }
}
