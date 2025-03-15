using System.Reflection;
using LoupedeckKritaApiClient.FiltersDialogs;

namespace Loupedeck.KritaPlugin.DynamicFolders
{
    public class FilterUnsharpMask : FilterDialogBase
    {
        public FilterUnsharpMask()
            : base(FilterNames.Unsharp)
        {
        }

        public override BitmapImage GetButtonImage(PluginImageSize imageSize)
        {
            return BitmapImage.FromResource(Assembly.GetExecutingAssembly(), "Loupedeck.KritaPlugin.images.Filters.filters-Unsharp.png");
        }

        static internal DialogDefinition GetDefinition()
        {
            return new DialogDefinition("Unsharp Mask",
                FilterNames.Unsharp,
                [
                    new CommandDefinition("Lightness only", (dialog) => (dialog.Dialog as KritaFilterUnsharp).ToggleLightnessOnly()),
                ],
                [
                    new AdjustmentDefinition("Radius", (dialog, delta) => (dialog.Dialog as KritaFilterUnsharp).AdjustRadius(delta).Result, 1),
                    new AdjustmentDefinition("Amount", (dialog, delta) => (dialog.Dialog as KritaFilterUnsharp).AdjustAmount(delta).Result, 0.5f),
                    new AdjustmentDefinition("Threshold", (dialog, delta) => (dialog.Dialog as KritaFilterUnsharp).AdjustThreshold((int)delta).Result, 0),
                ]);
        }
    }
}
