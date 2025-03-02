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
                    new FilterAdjustmentDefinition("Threshold", (dialog, delta) => ((KritaFilterThreshold)dialog.Dialog).AdjustThreshold((int)delta).Result, 128)
                ]);
        }
    }
}
