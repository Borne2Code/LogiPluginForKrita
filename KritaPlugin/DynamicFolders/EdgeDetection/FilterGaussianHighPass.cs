using LoupedeckKritaApiClient.FiltersDialogs;

namespace Loupedeck.KritaPlugin.DynamicFolders
{
    public class FilterGaussianHighPass : FilterDialogBase
    {
        public FilterGaussianHighPass()
            : base(FilterNames.GaussianHighPass)
        {
        }

        static internal FilterDialogDefinition GetDefinition()
        {
            return new FilterDialogDefinition("Gaussian High-Pass",
                FilterNames.GaussianHighPass,
                [],
                [
                    new FilterAdjustmentDefinition("Radius", (dialog, delta) => ((KritaFilterGaussianHighPass)dialog.Dialog).AdjustRadius(delta).Result, 1),
                ]);
        }
    }
}
