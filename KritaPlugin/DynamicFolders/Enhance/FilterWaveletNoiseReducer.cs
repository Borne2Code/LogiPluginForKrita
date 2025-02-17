using Loupedeck.KritaPlugin.DynamicFolders.FilterDefinitions;
using LoupedeckKritaApiClient.FiltersDialogs;

namespace Loupedeck.KritaPlugin.DynamicFolders
{
    public class FilterWaveletNoiseReducer : FilterDialogBase
    {
        public FilterWaveletNoiseReducer()
            : base(GetDefinition())
        {
        }

        static internal FilterDialogDefinition GetDefinition()
        {
            return new FilterDialogDefinition("Wavelet Noise Reducer",
                FiltersEnum.WaveletNoiseReducer,
                [],
                [
                    new FilterAdjustmentDefinition("Threshold", (dialog, delta) => ((KritaFilterWaveletNoiseReducer)dialog.Dialog).AdjustThreshold(delta).Result, 7),
                ]);
        }
    }
}
