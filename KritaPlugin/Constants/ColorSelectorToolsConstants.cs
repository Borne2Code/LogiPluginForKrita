using Logi.KritaPlugin.Actions;
using Logi.KritaPlugin.DynamicFolders;
using LogiKritaApiClient.ClientBase;

namespace Logi.KritaPlugin.Constants
{
    public class ColorSelectorToolsConstants
    {
        public static DynamicFolderAdjustmentDefinition Lightness => new DynamicFolderAdjustmentDefinition("Light",
            "Logi.KritaPlugin.images.Color.Lightness.png",
            ColorSelectorLightnessAdjustment.AdjustLightness);
        public static DynamicFolderAdjustmentDefinition Saturation => new DynamicFolderAdjustmentDefinition("Sat.",
            "Logi.KritaPlugin.images.Color.Saturation.png",
            ColorSelectorSaturationAdjustment.AdjustSaturation);
        public static DynamicFolderAdjustmentDefinition Hue => new DynamicFolderAdjustmentDefinition("Hue",
            "Logi.KritaPlugin.images.Color.Hue.png",
            ColorSelectorHueAdjustment.AdjustHue);
        public static DynamicFolderAdjustmentDefinition YellowBlue => new DynamicFolderAdjustmentDefinition("Y/B",
            "Logi.KritaPlugin.images.Color.YellowBlue.png",
            ColorSelectorYellowBlueAdjustment.AdjustYellowBlue);
        public static DynamicFolderAdjustmentDefinition RedGreen => new DynamicFolderAdjustmentDefinition("R/G",
            "Logi.KritaPlugin.images.Color.RedGreen.png",
            ColorSelectorRedGreenAdjustment.AdjustRedGreen);
        public static DynamicFolderCommandDefinition Swap => new DynamicFolderCommandDefinition("Swap",
            "Logi.KritaPlugin.images.Color.Swap.png",
            ActionsNames.Toggle_fg_bg, false);
        public static DynamicFolderCommandDefinition Sample => new DynamicFolderCommandDefinition("Sample",
            "Logi.KritaPlugin.images.Color.Sample.png",
            ActionsNames.Sample_screen_color);

        public static IDictionary<string, DynamicFolderActionDefinition> Tools => new Dictionary<string, DynamicFolderActionDefinition>
        {
            { Lightness.Name, Lightness },
            { Saturation.Name, Saturation },
            { Hue.Name, Hue },
            { YellowBlue.Name, YellowBlue },
            { RedGreen.Name, RedGreen },
            { Swap.Name, Swap },
            { Sample.Name, Sample },
        };
    }
}
