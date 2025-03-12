using LoupedeckKritaApiClient.FiltersDialogs;

namespace Loupedeck.KritaPlugin.DynamicFolders
{
    public class FilterMeanRemoval : FilterDialogBase
    {
        public FilterMeanRemoval()
            : base(FilterNames.MeanRemoval)
        {
        }

        static internal DialogDefinition GetDefinition()
        {
            return new DialogDefinition("Mean removal",
                FilterNames.MeanRemoval);
        }
    }
}
