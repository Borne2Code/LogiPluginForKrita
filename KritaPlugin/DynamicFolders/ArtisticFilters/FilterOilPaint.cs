using System.Reflection;
using LoupedeckKritaApiClient.FiltersDialogs;

namespace Loupedeck.KritaPlugin.DynamicFolders
{
    public class FilterOilPaint : FilterDialogBase
    {
        public FilterOilPaint()
            : base(FilterNames.OilPaint)
        {
        }

        public override BitmapImage GetButtonImage(PluginImageSize imageSize)
        {
            return BitmapImage.FromResource(Assembly.GetExecutingAssembly(), "Loupedeck.KritaPlugin.images.filters-OilPaint.png");
        }

        static internal DialogDefinition GetDefinition()
        {
            return new DialogDefinition("Oil Paint",
                FilterNames.OilPaint,
                [
                ],
                [
                    new AdjustmentDefinition("Brush size", (dialog, delta) => (dialog.Dialog as KritaFilterOilPaint).AdjustBrushSize((int)delta).Result, 1),
                    new AdjustmentDefinition("Smooth", (dialog, delta) => (dialog.Dialog as KritaFilterOilPaint).AdjustSmooth((int)delta).Result, 30),
                ]);
        }
    }
}
