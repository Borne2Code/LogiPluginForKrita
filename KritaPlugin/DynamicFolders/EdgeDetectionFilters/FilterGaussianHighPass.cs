using LoupedeckKritaApiClient.FiltersDialogs;

namespace Loupedeck.KritaPlugin.DynamicFolders
{
    public class FilterGaussianHighPass : FilterDialogBase
    {
        public FilterGaussianHighPass()
            : base(FilterNames.GaussianHighPass)
        {
        }

        static internal DialogDefinition GetDefinition()
        {
            return new DialogDefinition("Gaussian High-Pass",
                FilterNames.GaussianHighPass,
                [],
                [
                    new AdjustmentDefinition("Radius", (dialog, delta) => (dialog.Dialog as KritaFilterGaussianHighPass).AdjustRadius(delta).Result, 1),
                ]);
        }
    }
}
