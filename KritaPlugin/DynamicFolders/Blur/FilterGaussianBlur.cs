using Loupedeck.KritaPlugin.DynamicFolders.FilterDefinitions;
using LoupedeckKritaApiClient.FiltersDialogs;

namespace Loupedeck.KritaPlugin.DynamicFolders
{
    public class FilterGaussianBlur : FilterDialogBase
    {
        public FilterGaussianBlur()
            : base(GetDefinition())
        {
        }

        static internal FilterDialogDefinition GetDefinition()
        {
            return new FilterDialogDefinition("Gaussian Blur",
                FiltersEnum.GaussianBlur,
                [
                ],
                [
                    new FilterAdjustmentDefinition("Horizontal radius", (dialog, _, delta) => ((KritaFilterGaussianBlur)dialog.Dialog).AdjustHorizontalRadius(delta).Result),
                    new FilterAdjustmentDefinition("Vertical radius", (dialog, _, delta) => ((KritaFilterGaussianBlur)dialog.Dialog).AdjustVerticalRadius(delta).Result),
                ]);
        }
    }
}
