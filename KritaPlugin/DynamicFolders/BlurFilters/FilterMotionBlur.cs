using System.Reflection;
using LoupedeckKritaApiClient.FiltersDialogs;

namespace Loupedeck.KritaPlugin.DynamicFolders
{
    public class FilterMotionBlur : FilterDialogBase
    {
        public FilterMotionBlur()
            : base(FilterNames.MotionBlur)
        {
        }

        public override BitmapImage GetButtonImage(PluginImageSize imageSize)
        {
            return BitmapImage.FromResource(Assembly.GetExecutingAssembly(), "Loupedeck.KritaPlugin.images.filters-MotionBlur.png");
        }

        static internal DialogDefinition GetDefinition()
        {
            return new DialogDefinition("Motion Blur",
                FilterNames.MotionBlur,
                [],
                [
                    new AdjustmentDefinition("Angle", (dialog, delta) => (dialog.Dialog as KritaFilterMotionBlur).AdjustBlurAngle((int)delta).Result),
                    new AdjustmentDefinition("Length", (dialog, delta) => (dialog.Dialog as KritaFilterMotionBlur).AdjustLength((int)delta).Result, 5),
                ]);
        }
    }
}
