using System.Reflection;
using LoupedeckKritaApiClient.FiltersDialogs;

namespace Loupedeck.KritaPlugin.DynamicFolders
{
    public class FilterGaussianHighPass : FilterDialogBase
    {
        public FilterGaussianHighPass()
            : base(FilterNames.GaussianHighPass)
        {
        }

        public override BitmapImage GetButtonImage(PluginImageSize imageSize)
        {
            return BitmapImage.FromResource(Assembly.GetExecutingAssembly(), "Loupedeck.KritaPlugin.images.filters-GaussianHighpass.png");
        }

        static internal DialogDefinition GetDefinition()
        {
            return new DialogDefinition("Gaussian High-Pass",
                FilterNames.GaussianHighPass,
                [],
                [
                    new AdjustmentDefinition("Radius", (dialog, delta) => (dialog.Dialog as KritaFilterGaussianHighPass).AdjustRadius(delta).Result, 1),
                ]);
        }
    }
}
