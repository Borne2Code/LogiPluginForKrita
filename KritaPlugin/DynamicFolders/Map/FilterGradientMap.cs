using LoupedeckKritaApiClient.FiltersDialogs;

namespace Loupedeck.KritaPlugin.DynamicFolders
{
    public class FilterGradientMap : FilterDialogBase
    {
        public FilterGradientMap()
            : base(FilterNames.GradientMap)
        {
        }

        static internal FilterDialogDefinition GetDefinition()
        {
            return new FilterDialogDefinition("Gradient Map",
                FilterNames.GradientMap,
                [],
                []);
        }
    }
}
