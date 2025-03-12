using LoupedeckKritaApiClient.FiltersDialogs;

namespace Loupedeck.KritaPlugin.DynamicFolders
{
    public class FilterPosterize : FilterDialogBase
    {
        public FilterPosterize()
            : base(FilterNames.Posterize)
        {
        }

        static internal DialogDefinition GetDefinition()
        {
            return new DialogDefinition("Posterize",
                FilterNames.Posterize,
                [
                ],
                [
                    new AdjustmentDefinition("Steps", (dialog, delta) => (dialog.Dialog as KritaFilterPosterize).AdjustSteps((int)delta).Result, 16),
                ]);
        }
    }
}
