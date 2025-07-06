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
                true,
                "Loupedeck.KritaPlugin.images.Filters.filters-GaussianBlur.png",
                [
                    new AdjustmentDefinition("Horizontal radius", (dialog, delta) => (dialog.Dialog as KritaFilterGaussianBlur).AdjustHorizontalRadius(delta).Result, 5),
                    new AdjustmentDefinition("Vertical radius", (dialog, delta) => (dialog.Dialog as KritaFilterGaussianBlur).AdjustVerticalRadius(delta).Result, 5),

                    new CommandDefinition("Lock aspect", (dialog) => (dialog.Dialog as KritaFilterGaussianBlur).ToggleLockHorizontalVertical()),
                ]);
        }
    }
}
