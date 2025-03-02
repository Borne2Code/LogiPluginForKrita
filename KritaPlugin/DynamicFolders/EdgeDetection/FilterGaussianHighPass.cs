using LoupedeckKritaApiClient.FiltersDialogs;

namespace Loupedeck.KritaPlugin.DynamicFolders
{
    public class FilterGaussianHighPass : FilterDialogBase
    {
        public FilterGaussianHighPass()
            : base(GetDefinition())
        {
        }

        static internal FilterDialogDefinition GetDefinition()
        {
            return new FilterDialogDefinition("Gaussian High-Pass",
                FiltersEnum.GaussianHighPass,
                [],
                [
                    new FilterAdjustmentDefinition("Radius", (dialog, delta) => ((KritaFilterGaussianHighPass)dialog.Dialog).AdjustRadius(delta).Result, 1),
                ]);
        }
    }
}
