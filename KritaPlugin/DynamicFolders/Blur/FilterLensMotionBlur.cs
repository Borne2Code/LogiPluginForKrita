using Loupedeck.KritaPlugin.DynamicFolders.FilterDefinitions;
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
                    new FilterAdjustmentDefinition("Angle", (dialog, _, delta) => ((KritaFilterMotionBlur)dialog.Dialog).AdjustBlurAngle(delta).Result),
                    new FilterAdjustmentDefinition("Length", (dialog, _, delta) => ((KritaFilterMotionBlur)dialog.Dialog).AdjustLength(delta).Result),
                ]);
        }
    }
}
