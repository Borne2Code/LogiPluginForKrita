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
                "Loupedeck.KritaPlugin.images.Filters.filters-Posterize.png",
                [],
                [
                    new AdjustmentDefinition("Steps", (dialog, delta) => (dialog.Dialog as KritaFilterPosterize).AdjustSteps((int)delta).Result, 16),
                ]);
        }
    }
}
