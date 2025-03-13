using System.Reflection;
using LoupedeckKritaApiClient.FiltersDialogs;

namespace Loupedeck.KritaPlugin.DynamicFolders
{
    public class FilterGaussianNoiseReducer : FilterDialogBase
    {
        public FilterGaussianNoiseReducer()
            : base(FilterNames.GaussianNoiseReducer)
        {
        }

        public override BitmapImage GetButtonImage(PluginImageSize imageSize)
        {
            return BitmapImage.FromResource(Assembly.GetExecutingAssembly(), "Loupedeck.KritaPlugin.images.filters-GaussianNoiseReducer.png");
        }

        static internal DialogDefinition GetDefinition()
        {
            return new DialogDefinition("Gaussian Noise Reducer",
                FilterNames.GaussianNoiseReducer,
                [],
                [
                    new AdjustmentDefinition("Threshold", (dialog, delta) => (dialog.Dialog as KritaFilterGaussianNoiseReducer).AdjustThreshold((int)delta).Result, 15),
                    new AdjustmentDefinition("Window Size", (dialog, delta) => (dialog.Dialog as KritaFilterGaussianNoiseReducer).AdjustWindowSize((int)delta).Result, 1),
                ]);
        }
    }
}
