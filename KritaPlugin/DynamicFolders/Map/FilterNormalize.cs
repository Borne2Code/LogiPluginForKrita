using LoupedeckKritaApiClient.FiltersDialogs;

namespace Loupedeck.KritaPlugin.DynamicFolders
{
    public class FilterNormalize : FilterDialogBase
    {
        public FilterNormalize()
            : base(FilterNames.Normalize)
        {
        }

        static internal FilterDialogDefinition GetDefinition()
        {
            return new FilterDialogDefinition("Normalize",
                FilterNames.Normalize);
        }
    }
}
