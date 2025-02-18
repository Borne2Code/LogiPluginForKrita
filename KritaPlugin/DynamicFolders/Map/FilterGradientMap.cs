using Loupedeck.KritaPlugin.DynamicFolders.FilterDefinitions;
using LoupedeckKritaApiClient.FiltersDialogs;

namespace Loupedeck.KritaPlugin.DynamicFolders
{
    public class FilterGradientMap : FilterDialogBase
    {
        public FilterGradientMap()
            : base(GetDefinition())
        {
        }

        static internal FilterDialogDefinition GetDefinition()
        {
            return new FilterDialogDefinition("Gradient Map",
                FiltersEnum.GradientMap,
                [],
                []);
        }
    }
}
