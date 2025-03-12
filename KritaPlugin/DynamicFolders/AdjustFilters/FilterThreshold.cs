using System.Reflection;
using LoupedeckKritaApiClient.FiltersDialogs;

namespace Loupedeck.KritaPlugin.DynamicFolders
{
    public class FilterThreshold : FilterDialogBase
    {
        public FilterThreshold()
            : base(FilterNames.Threshold)
        {
        }

        public override BitmapImage GetButtonImage(PluginImageSize imageSize)
        {
            return BitmapImage.FromResource(Assembly.GetExecutingAssembly(), "Loupedeck.KritaPlugin.images.filters-Threshold.png");
        }

        static internal DialogDefinition GetDefinition()
        {
            return new DialogDefinition("Threshold",
                FilterNames.Threshold,
                [],
                [
                    new AdjustmentDefinition("Threshold", (dialog, delta) => (dialog.Dialog as KritaFilterThreshold).AdjustThreshold((int)delta).Result, 128)
                ]);
        }
    }
}
