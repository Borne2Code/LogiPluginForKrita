using LogiKritaApiClient.FiltersDialogs;

namespace Logi.KritaPlugin.DynamicFolders
{
    public class FilterGaussianNoiseReducer : FilterDialogBase
    {
        public FilterGaussianNoiseReducer()
            : base(FilterNames.GaussianNoiseReducer)
        {
        }

        static internal FilterDialogDefinition GetDefinition()
        {
            return new FilterDialogDefinition("Gaussian Noise Reducer",
                FilterNames.GaussianNoiseReducer,
                true,
                "Logi.KritaPlugin.images.Filters.filters-GaussianNoiseReducer.png",
                [
                    new AdjustmentDefinition("Threshold", (dialog, delta) => (dialog.Dialog as KritaFilterGaussianNoiseReducer).AdjustThreshold((int)delta).Result, 15),
                    new AdjustmentDefinition("Window Size", (dialog, delta) => (dialog.Dialog as KritaFilterGaussianNoiseReducer).AdjustWindowSize((int)delta).Result, 1),
                ]);
        }
    }
}
