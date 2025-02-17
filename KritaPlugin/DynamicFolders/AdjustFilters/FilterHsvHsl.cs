using System.Runtime.CompilerServices;
using Loupedeck.KritaPlugin.DynamicFolders.FilterDefinitions;
using LoupedeckKritaApiClient.FiltersDialogs;

namespace Loupedeck.KritaPlugin.DynamicFolders
{
    public class FilterHsvHsl : FilterDialogBase
    {
        public FilterHsvHsl()
            : base(GetDefinition())
        {
        }

        static internal FilterDialogDefinition GetDefinition()
        {
            return new FilterDialogDefinition("Hsv/Hsl Adjustment",
                FiltersEnum.HsvAdjustment,
                [
                    new FilterCommandDefinition("Mode Hue/Sat/Value", (dialog) => ((KritaFilterHsvAdjustment)dialog.Dialog).SetType(KritaFilterHsvAdjustment.Type.HueSaturationValue)),
                    new FilterCommandDefinition("Mode Hue/Sat/Lightness", (dialog) => ((KritaFilterHsvAdjustment)dialog.Dialog).SetType(KritaFilterHsvAdjustment.Type.HueSaturationLightness)),
                    new FilterCommandDefinition("Mode Hue/Sat/Intensity", (dialog) => ((KritaFilterHsvAdjustment)dialog.Dialog).SetType(KritaFilterHsvAdjustment.Type.HueSaturationIntensity)),
                    new FilterCommandDefinition("Mode Hue/Sat/Luma", (dialog) => ((KritaFilterHsvAdjustment)dialog.Dialog).SetType(KritaFilterHsvAdjustment.Type.HueSaturationLuma)),
                    new FilterCommandDefinition("Mode Blue Chroma/Red Chroma/Luma", (dialog) => ((KritaFilterHsvAdjustment)dialog.Dialog).SetType(KritaFilterHsvAdjustment.Type.BlueChromaRedChromaLuma)),
                    new FilterCommandDefinition("Colorize", (dialog) => ((KritaFilterHsvAdjustment)dialog.Dialog).ToggleColorize()),
                    new FilterCommandDefinition("Legacy mode", (dialog) => ((KritaFilterHsvAdjustment)dialog.Dialog).ToggleLegacyMode()),
                ],
                [
                    new FilterAdjustmentDefinition("Hue", (dialog, delta) => ((KritaFilterHsvAdjustment)dialog.Dialog).AdjustHue((int)delta).Result),
                    new FilterAdjustmentDefinition("Saturation", (dialog, delta) => ((KritaFilterHsvAdjustment)dialog.Dialog).AdjustSaturation((int)delta).Result),
                    new FilterAdjustmentDefinition("Value", (dialog, delta) => ((KritaFilterHsvAdjustment)dialog.Dialog).AdjustValue((int)delta).Result),
                ]);
        }
    }
}
