using LoupedeckKritaApiClient.FiltersDialogs;

namespace Loupedeck.KritaPlugin.DynamicFolders
{
    public class FilterGradientMap : FilterDialogBase
    {
        public FilterGradientMap()
            : base(FilterNames.GradientMap)
        {
        }

        static internal DialogDefinition GetDefinition()
        {
            return new DialogDefinition("Gradient Map",
                FilterNames.GradientMap,
                [],
                []);
        }
    }
}
