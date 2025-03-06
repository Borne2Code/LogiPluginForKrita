using LoupedeckKritaApiClient.FiltersDialogs;

namespace Loupedeck.KritaPlugin.DynamicFolders
{
    public class FilterPosterize : FilterDialogBase
    {
        public FilterPosterize()
            : base(FilterNames.Posterize)
        {
        }

        static internal FilterDialogDefinition GetDefinition()
        {
            return new FilterDialogDefinition("Posterize",
                FilterNames.Posterize,
                [
                ],
                [
                    new FilterAdjustmentDefinition("Steps", (dialog, delta) => ((KritaFilterPosterize)dialog.Dialog).AdjustSteps((int)delta).Result, 16),
                ]);
        }
    }
}
