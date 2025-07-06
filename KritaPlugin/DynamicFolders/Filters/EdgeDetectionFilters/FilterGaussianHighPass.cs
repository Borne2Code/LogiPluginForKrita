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
                true,
                "Loupedeck.KritaPlugin.images.Filters.filters-GaussianHighpass.png",
                [
                    new AdjustmentDefinition("Radius", (dialog, delta) => (dialog.Dialog as KritaFilterGaussianHighPass).AdjustRadius(delta).Result, 1),
                ]);
        }
    }
}
