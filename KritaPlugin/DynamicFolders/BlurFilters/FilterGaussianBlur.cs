using System.Reflection;
using LoupedeckKritaApiClient.FiltersDialogs;

namespace Loupedeck.KritaPlugin.DynamicFolders
{
    public class FilterGaussianBlur : FilterDialogBase
    {
        public FilterGaussianBlur()
            : base(FilterNames.GaussianBlur)
        {
        }

        public override BitmapImage GetButtonImage(PluginImageSize imageSize)
        {
            return BitmapImage.FromResource(Assembly.GetExecutingAssembly(), "Loupedeck.KritaPlugin.images.filters-GaussianBlur.png");
        }

        static internal DialogDefinition GetDefinition()
        {
            return new DialogDefinition("Gaussian Blur",
                FilterNames.GaussianBlur,
                [
                    new CommandDefinition("Lock aspect", (dialog) => (dialog.Dialog as KritaFilterGaussianBlur).ToggleLockHorizontalVertical()),
                ],
                [
                    new AdjustmentDefinition("Horizontal radius", (dialog, delta) => (dialog.Dialog as KritaFilterGaussianBlur).AdjustHorizontalRadius(delta).Result, 5),
                    new AdjustmentDefinition("Vertical radius", (dialog, delta) => (dialog.Dialog as KritaFilterGaussianBlur).AdjustVerticalRadius(delta).Result, 5),
                ]);
        }
    }
}
