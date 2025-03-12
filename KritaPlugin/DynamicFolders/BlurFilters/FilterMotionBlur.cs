using LoupedeckKritaApiClient.FiltersDialogs;

namespace Loupedeck.KritaPlugin.DynamicFolders
{
    public class FilterMotionBlur : FilterDialogBase
    {
        public FilterMotionBlur()
            : base(FilterNames.MotionBlur)
        {
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
