using LoupedeckKritaApiClient.FiltersDialogs;

namespace Loupedeck.KritaPlugin.DynamicFolders
{
    public class FilterThreshold : FilterDialogBase
    {
        public FilterThreshold()
            : base(FilterNames.Threshold)
        {
        }

        static internal DialogDefinition GetDefinition()
        {
            return new DialogDefinition("Threshold",
                FilterNames.Threshold,
                [],
                [
                    new AdjustmentDefinition("Threshold", (dialog, delta) => (dialog.Dialog as KritaFilterThreshold).AdjustThreshold((int)delta).Result, 128)
                ]);
        }
    }
}
