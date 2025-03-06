using LoupedeckKritaApiClient.FiltersDialogs;

namespace Loupedeck.KritaPlugin.DynamicFolders
{
    public class FilterWaveletNoiseReducer : FilterDialogBase
    {
        public FilterWaveletNoiseReducer()
            : base(FilterNames.WaveletNoiseReducer)
        {
        }

        static internal FilterDialogDefinition GetDefinition()
        {
            return new FilterDialogDefinition("Wavelet Noise Reducer",
                FilterNames.WaveletNoiseReducer,
                [],
                [
                    new FilterAdjustmentDefinition("Threshold", (dialog, delta) => ((KritaFilterWaveletNoiseReducer)dialog.Dialog).AdjustThreshold(delta).Result, 7),
                ]);
        }
    }
}
