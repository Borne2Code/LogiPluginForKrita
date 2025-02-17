using Loupedeck.KritaPlugin.DynamicFolders.FilterDefinitions;
using LoupedeckKritaApiClient.FiltersDialogs;

namespace Loupedeck.KritaPlugin.DynamicFolders
{
    public class FilterOilPaint : FilterDialogBase
    {
        public FilterOilPaint()
            : base(GetDefinition())
        {
        }

        static internal FilterDialogDefinition GetDefinition()
        {
            return new FilterDialogDefinition("Oil Paint",
                FiltersEnum.OilPaint,
                [
                ],
                [
                    new FilterAdjustmentDefinition("Brush size", (dialog, delta) => ((KritaFilterOilPaint)dialog.Dialog).AdjustBrushSize((int)delta).Result, 1),
                    new FilterAdjustmentDefinition("Smooth", (dialog, delta) => ((KritaFilterOilPaint)dialog.Dialog).AdjustSmooth((int)delta).Result, 30),
                ]);
        }
    }
}
