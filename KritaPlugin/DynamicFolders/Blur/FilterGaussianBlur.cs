using LoupedeckKritaApiClient.FiltersDialogs;

namespace Loupedeck.KritaPlugin.DynamicFolders
{
    public class FilterGaussianBlur : FilterDialogBase
    {
        public FilterGaussianBlur()
            : base(FilterNames.GaussianBlur)
        {
        }

        static internal FilterDialogDefinition GetDefinition()
        {
            return new FilterDialogDefinition("Gaussian Blur",
                FilterNames.GaussianBlur,
                [
                    new FilterCommandDefinition("Lock aspect", (dialog) => ((KritaFilterGaussianBlur)dialog.Dialog).ToggleLockHorizontalVertical()),
                ],
                [
                    new FilterAdjustmentDefinition("Horizontal radius", (dialog, delta) => ((KritaFilterGaussianBlur)dialog.Dialog).AdjustHorizontalRadius(delta).Result, 5),
                    new FilterAdjustmentDefinition("Vertical radius", (dialog, delta) => ((KritaFilterGaussianBlur)dialog.Dialog).AdjustVerticalRadius(delta).Result, 5),
                ]);
        }
    }
}
