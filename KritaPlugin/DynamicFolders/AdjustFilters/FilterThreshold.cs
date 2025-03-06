using LoupedeckKritaApiClient.FiltersDialogs;

namespace Loupedeck.KritaPlugin.DynamicFolders
{
    public class FilterThreshold : FilterDialogBase
    {
        public FilterThreshold()
            : base(FilterNames.Threshold)
        {
        }

        static internal FilterDialogDefinition GetDefinition()
        {
            return new FilterDialogDefinition("Threshold",
                FilterNames.Threshold,
                [],
                [
                    new FilterAdjustmentDefinition("Threshold", (dialog, delta) => ((KritaFilterThreshold)dialog.Dialog).AdjustThreshold((int)delta).Result, 128)
                ]);
        }
    }
}
