using LoupedeckKritaApiClient.FiltersDialogs;

namespace Loupedeck.KritaPlugin.DynamicFolders
{
    public class FilterResetTransparent
    {
        static internal FilterDialogDefinition GetDefinition()
        {
            return new FilterDialogDefinition("Reset Transparent",
                FilterNames.ResetTransparent,
                false,
                null);
        }
    }
}
