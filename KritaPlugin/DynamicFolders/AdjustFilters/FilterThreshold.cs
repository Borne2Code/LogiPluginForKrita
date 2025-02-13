using Loupedeck.KritaPlugin.DynamicFolders.FilterDefinitions;
using LoupedeckKritaApiClient.FiltersDialogs;

namespace Loupedeck.KritaPlugin.DynamicFolders
{
    public class FilterThreshold : FilterDialogBase
    {
        public FilterThreshold()
            : base(GetDefinition())
        {
        }

        static internal FilterDialogDefinition GetDefinition()
        {
            return new FilterDialogDefinition("Threshold",
                FiltersEnum.Threshold,
                [],
                [
                    new FilterAdjustmentDefinition("Threshold", (dialog, _, delta) => ((KritaFilterThreshold)dialog.Dialog).AdjustThreshold(delta).Result)
                ]);
        }
    }
}
