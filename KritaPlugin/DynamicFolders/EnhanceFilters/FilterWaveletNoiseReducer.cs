using System.Reflection;
using LoupedeckKritaApiClient.FiltersDialogs;

namespace Loupedeck.KritaPlugin.DynamicFolders
{
    public class FilterWaveletNoiseReducer : FilterDialogBase
    {
        public FilterWaveletNoiseReducer()
            : base(FilterNames.WaveletNoiseReducer)
        {
        }

        public override BitmapImage GetButtonImage(PluginImageSize imageSize)
        {
            return BitmapImage.FromResource(Assembly.GetExecutingAssembly(), "Loupedeck.KritaPlugin.images.Filters.filters-WaveletNoiseReducer.png");
        }

        static internal DialogDefinition GetDefinition()
        {
            return new DialogDefinition("Wavelet Noise Reducer",
                FilterNames.WaveletNoiseReducer,
                [],
                [
                    new AdjustmentDefinition("Threshold", (dialog, delta) => (dialog.Dialog as KritaFilterWaveletNoiseReducer).AdjustThreshold(delta).Result, 7),
                ]);
        }
    }
}
