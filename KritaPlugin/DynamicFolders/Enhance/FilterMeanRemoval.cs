using Loupedeck.KritaPlugin.DynamicFolders.FilterDefinitions;
using LoupedeckKritaApiClient.FiltersDialogs;

namespace Loupedeck.KritaPlugin.DynamicFolders
{
    public class FilterMeanRemoval : FilterDialogBase
    {
        public FilterMeanRemoval()
            : base(GetDefinition())
        {
        }

        static internal FilterDialogDefinition GetDefinition()
        {
            return new FilterDialogDefinition("Mean removal",
                FiltersEnum.MeanRemoval,
                [],
                []);
        }
    }
}
