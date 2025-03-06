using LoupedeckKritaApiClient.FiltersDialogs;

namespace Loupedeck.KritaPlugin.DynamicFolders
{
    public class FilterMotionBlur : FilterDialogBase
    {
        public FilterMotionBlur()
            : base(FilterNames.MotionBlur)
        {
        }

        static internal FilterDialogDefinition GetDefinition()
        {
            return new FilterDialogDefinition("Motion Blur",
                FilterNames.MotionBlur,
                [],
                [
                    new FilterAdjustmentDefinition("Angle", (dialog, delta) => ((KritaFilterMotionBlur)dialog.Dialog).AdjustBlurAngle((int)delta).Result),
                    new FilterAdjustmentDefinition("Length", (dialog, delta) => ((KritaFilterMotionBlur)dialog.Dialog).AdjustLength((int)delta).Result, 5),
                ]);
        }
    }
}
