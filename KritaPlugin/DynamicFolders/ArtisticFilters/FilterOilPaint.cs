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
                    new FilterAdjustmentDefinition("Brush size", (dialog, _, delta) => ((KritaFilterOilPaint)dialog.Dialog).AdjustBrushSize(delta).Result),
                    new FilterAdjustmentDefinition("Smooth", (dialog, _, delta) => ((KritaFilterOilPaint)dialog.Dialog).AdjustSmooth(delta).Result),
                ]);
        }
    }
}
