using System.Runtime.CompilerServices;
using LoupedeckKritaApiClient.FiltersDialogs;

namespace Loupedeck.KritaPlugin.DynamicFolders
{
    public class FilterHsvHsl : FilterDialogBase
    {
        public FilterHsvHsl()
            : base(FilterNames.HsvAdjustment)
        {
        }

        static internal DialogDefinition GetDefinition()
        {
            return new DialogDefinition("Hsv/Hsl Adjustment",
                FilterNames.HsvAdjustment,
                [
                    new CommandDefinition("Mode Hue/Sat/Value", (dialog) => ((KritaFilterHsvAdjustment)dialog.Dialog).SetType(KritaFilterHsvAdjustment.Type.HueSaturationValue)),
                    new CommandDefinition("Mode Hue/Sat/Lightness", (dialog) => ((KritaFilterHsvAdjustment)dialog.Dialog).SetType(KritaFilterHsvAdjustment.Type.HueSaturationLightness)),
                    new CommandDefinition("Mode Hue/Sat/Intensity", (dialog) => ((KritaFilterHsvAdjustment)dialog.Dialog).SetType(KritaFilterHsvAdjustment.Type.HueSaturationIntensity)),
                    new CommandDefinition("Mode Hue/Sat/Luma", (dialog) => ((KritaFilterHsvAdjustment)dialog.Dialog).SetType(KritaFilterHsvAdjustment.Type.HueSaturationLuma)),
                    new CommandDefinition("Mode Blue Chroma/Red Chroma/Luma", (dialog) => ((KritaFilterHsvAdjustment)dialog.Dialog).SetType(KritaFilterHsvAdjustment.Type.BlueChromaRedChromaLuma)),
                    new CommandDefinition("Colorize", (dialog) => ((KritaFilterHsvAdjustment)dialog.Dialog).ToggleColorize()),
                    new CommandDefinition("Legacy mode", (dialog) => ((KritaFilterHsvAdjustment)dialog.Dialog).ToggleLegacyMode()),
                ],
                [
                    new AdjustmentDefinition("Hue", (dialog, delta) => ((KritaFilterHsvAdjustment)dialog.Dialog).AdjustHue((int)delta).Result),
                    new AdjustmentDefinition("Saturation", (dialog, delta) => ((KritaFilterHsvAdjustment)dialog.Dialog).AdjustSaturation((int)delta).Result),
                    new AdjustmentDefinition("Value", (dialog, delta) => ((KritaFilterHsvAdjustment)dialog.Dialog).AdjustValue((int)delta).Result),
                ]);
        }
    }
}
