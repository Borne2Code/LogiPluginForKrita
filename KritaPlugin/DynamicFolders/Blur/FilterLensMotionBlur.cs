using LoupedeckKritaApiClient.FiltersDialogs;

namespace Loupedeck.KritaPlugin.DynamicFolders
{
    public class FilterLensMotionBlur : FilterDialogBase
    {
        public FilterLensMotionBlur()
            : base(GetDefinition())
        {
        }

        static internal FilterDialogDefinition GetDefinition()
        {
            return new FilterDialogDefinition("Motion Blur",
                FiltersEnum.MotionBlur,
                [],
                [
                    new FilterAdjustmentDefinition("Angle", (dialog, delta) => ((KritaFilterMotionBlur)dialog.Dialog).AdjustBlurAngle((int)delta).Result),
                    new FilterAdjustmentDefinition("Length", (dialog, delta) => ((KritaFilterMotionBlur)dialog.Dialog).AdjustLength((int)delta).Result, 5),
                ]);
        }
    }
}
