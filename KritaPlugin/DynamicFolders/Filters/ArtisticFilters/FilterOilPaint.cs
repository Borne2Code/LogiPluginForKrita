using LoupedeckKritaApiClient.FiltersDialogs;

namespace Loupedeck.KritaPlugin.DynamicFolders
{
    public class FilterOilPaint : FilterDialogBase
    {
        public FilterOilPaint()
            : base(FilterNames.OilPaint)
        {
        }

        static internal FilterDialogDefinition GetDefinition()
        {
            return new FilterDialogDefinition("Oil Paint",
                FilterNames.OilPaint,
                true,
                "Loupedeck.KritaPlugin.images.Filters.filters-OilPaint.png",
                [
                    new AdjustmentDefinition("Brush size", (dialog, delta) => (dialog.Dialog as KritaFilterOilPaint).AdjustBrushSize((int)delta).Result, 1),
                    new AdjustmentDefinition("Smooth", (dialog, delta) => (dialog.Dialog as KritaFilterOilPaint).AdjustSmooth((int)delta).Result, 30),
                ]);
        }
    }
}
