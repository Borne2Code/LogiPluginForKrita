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
                "Loupedeck.KritaPlugin.images.Filters.filters-MotionBlur.png",
                [],
                [
                    new AdjustmentDefinition("Angle", (dialog, delta) => (dialog.Dialog as KritaFilterMotionBlur).AdjustBlurAngle((int)delta).Result),
                    new AdjustmentDefinition("Length", (dialog, delta) => (dialog.Dialog as KritaFilterMotionBlur).AdjustLength((int)delta).Result, 5),
                ]);
        }
    }
}
