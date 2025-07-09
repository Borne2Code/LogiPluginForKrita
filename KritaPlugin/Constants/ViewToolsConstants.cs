using Logi.KritaPlugin.Actions;
using Logi.KritaPlugin.DynamicFolders;
using LogiKritaApiClient.ClientBase;

namespace Logi.KritaPlugin.Constants
{
    public class ViewToolsConstants
    {
        public static DynamicFolderActionDefinition Mirror => new DynamicFolderActionDefinition("Mirror", "Logi.KritaPlugin.images.View.ToggleMirrorView.png", ActionsNames.Mirror_canvas);
        public static DynamicFolderActionDefinition BrushSize => new DynamicFolderActionDefinition("Brush size",
            "Logi.KritaPlugin.images.View.BrushSize.png",
            ViewBrushSizeAdjustment.AdjustBrushSize,
            ViewBrushSizeAdjustment.GetBrushSize);
        public static DynamicFolderActionDefinition BrushOpacity => new DynamicFolderActionDefinition("Brush opacity",
            "Logi.KritaPlugin.images.View.BrushOpacity.png",
            ViewBrushOpacityAdjustment.AdjustBrushOpacity,
            ViewBrushOpacityAdjustment.GetBrushOpacity);

        public static IDictionary<string, DynamicFolderActionDefinition> Tools => new Dictionary<string, DynamicFolderActionDefinition>
        {
            { Mirror.Name, Mirror },
            { BrushSize.Name, BrushSize },
            { BrushOpacity.Name, BrushOpacity },
        };
    }
}
