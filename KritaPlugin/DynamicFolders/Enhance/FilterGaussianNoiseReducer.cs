using LoupedeckKritaApiClient.FiltersDialogs;

namespace Loupedeck.KritaPlugin.DynamicFolders
{
    public class FilterGaussianNoiseReducer : FilterDialogBase
    {
        public FilterGaussianNoiseReducer()
            : base(GetDefinition())
        {
        }

        static internal FilterDialogDefinition GetDefinition()
        {
            return new FilterDialogDefinition("Gaussian Noise Reducer",
                FiltersEnum.GaussianNoiseReducer,
                [],
                [
                    new FilterAdjustmentDefinition("Threshold", (dialog, delta) => ((KritaFilterGaussianNoiseReducer)dialog.Dialog).AdjustThreshold((int)delta).Result, 15),
                    new FilterAdjustmentDefinition("Window Size", (dialog, delta) => ((KritaFilterGaussianNoiseReducer)dialog.Dialog).AdjustWindowSize((int)delta).Result, 1),
                ]);
        }
    }
}
