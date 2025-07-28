using Logi.KritaPlugin.DynamicFolders;
using LogiKritaApiClient.ClientBase;

namespace Logi.KritaPlugin.Constants
{
    public class PaintToolsConstants
    {
        public static DynamicFolderCommandDefinition Brush => new DynamicFolderCommandDefinition("Brush", "Logi.KritaPlugin.images.Tools.Brush.png", ActionsNames.KritaShape_KisToolBrush);
        public static DynamicFolderCommandDefinition Fill => new DynamicFolderCommandDefinition("Fill", "Logi.KritaPlugin.images.Tools.Fill.png", ActionsNames.KritaFill_KisToolFill);
        public static DynamicFolderCommandDefinition Gradient => new DynamicFolderCommandDefinition("Gradient", "Logi.KritaPlugin.images.Tools.Gradient.png", ActionsNames.KritaFill_KisToolGradient);
        public static DynamicFolderCommandDefinition DynamicBrush => new DynamicFolderCommandDefinition("Dynamic Brush", "Logi.KritaPlugin.images.Tools.PaintDynamic.png", ActionsNames.KritaShape_KisToolDyna);
        public static DynamicFolderCommandDefinition MultiBrush => new DynamicFolderCommandDefinition("Multi Brush", "Logi.KritaPlugin.images.Tools.PaintMultibrush.png", ActionsNames.KritaShape_KisToolMultiBrush);
        public static DynamicFolderCommandDefinition ColorizeMask => new DynamicFolderCommandDefinition("Colorize Mask", "Logi.KritaPlugin.images.Tools.ColorizeMask.png", ActionsNames.KritaShape_KisToolLazyBrush);
        public static DynamicFolderCommandDefinition SmartPatch => new DynamicFolderCommandDefinition("Smart patch", "Logi.KritaPlugin.images.Tools.SmartPatch.png", ActionsNames.KritaShape_KisToolSmartPatch);
        public static DynamicFolderCommandDefinition EncloseAndFill => new DynamicFolderCommandDefinition("Enclose And Fill", "Logi.KritaPlugin.images.Tools.EncloseAndFill.png", ActionsNames.KisToolEncloseAndFill);

        public static IDictionary<string, DynamicFolderActionDefinition> Tools => new Dictionary<string, DynamicFolderActionDefinition>
        {
            { Brush.Name, Brush },
            { Fill.Name, Fill },
            { Gradient.Name, Gradient },
            { DynamicBrush.Name, DynamicBrush },
            { MultiBrush.Name, MultiBrush },
            { ColorizeMask.Name, ColorizeMask },
            { SmartPatch.Name, SmartPatch },
            { EncloseAndFill.Name, EncloseAndFill }
        };
    }
}
