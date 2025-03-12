using LoupedeckKritaApiClient.FiltersDialogs;

namespace Loupedeck.KritaPlugin.DynamicFolders
{
    public class FilterNormalize : FilterDialogBase
    {
        public FilterNormalize()
            : base(FilterNames.Normalize)
        {
        }

        static internal DialogDefinition GetDefinition()
        {
            return new DialogDefinition("Normalize",
                FilterNames.Normalize);
        }
    }
}
