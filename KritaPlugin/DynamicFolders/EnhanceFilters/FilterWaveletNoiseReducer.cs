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
                true,
                "Loupedeck.KritaPlugin.images.Filters.filters-WaveletNoiseReducer.png",
                [],
                [
                    new AdjustmentDefinition("Threshold", (dialog, delta) => (dialog.Dialog as KritaFilterWaveletNoiseReducer).AdjustThreshold(delta).Result, 7),
                ]);
        }
    }
}
