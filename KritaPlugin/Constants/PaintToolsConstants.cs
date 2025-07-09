using Logi.KritaPlugin.DynamicFolders;
using LogiKritaApiClient.ClientBase;

namespace Logi.KritaPlugin.Constants
{
    public class PaintToolsConstants
    {
        public static DynamicFolderActionDefinition Brush => new DynamicFolderActionDefinition("Brush", "Logi.KritaPlugin.images.Tools.Brush.png", ActionsNames.KritaShape_KisToolBrush);
        public static DynamicFolderActionDefinition Fill => new DynamicFolderActionDefinition("Fill", "Logi.KritaPlugin.images.Tools.Fill.png", ActionsNames.KritaFill_KisToolFill);
        public static DynamicFolderActionDefinition Gradient => new DynamicFolderActionDefinition("Gradient", "Logi.KritaPlugin.images.Tools.Gradient.png", ActionsNames.KritaFill_KisToolGradient);
        public static DynamicFolderActionDefinition DynamicBrush => new DynamicFolderActionDefinition("Dynamic Brush", "Logi.KritaPlugin.images.Tools.PaintDynamic.png", ActionsNames.KritaShape_KisToolDyna);
        public static DynamicFolderActionDefinition MultiBrush => new DynamicFolderActionDefinition("Multi Brush", "Logi.KritaPlugin.images.Tools.PaintMultibrush.png", ActionsNames.KritaShape_KisToolMultiBrush);
        public static DynamicFolderActionDefinition ColorizeMask => new DynamicFolderActionDefinition("Colorize Mask", "Logi.KritaPlugin.images.Tools.ColorizeMask.png", ActionsNames.KritaShape_KisToolLazyBrush);
        public static DynamicFolderActionDefinition SmartPatch => new DynamicFolderActionDefinition("Smart patch", "Logi.KritaPlugin.images.Tools.SmartPatch.png", ActionsNames.KritaShape_KisToolSmartPatch);
        public static DynamicFolderActionDefinition EncloseAndFill => new DynamicFolderActionDefinition("Enclose And Fill", "Logi.KritaPlugin.images.Tools.EncloseAndFill.png", ActionsNames.KisToolEncloseAndFill);

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
