using Logi.KritaPlugin.Actions;
using Logi.KritaPlugin.DynamicFolders;
using LogiKritaApiClient.ClientBase;

namespace Logi.KritaPlugin.Constants
{
    public class ViewToolsConstants
    {
        public static DynamicFolderActionDefinition Mirror => new DynamicFolderActionDefinition("Mirror", "Logi.KritaPlugin.images.View.ToggleMirrorView.png", ActionsNames.Mirror_canvas, false);
        public static DynamicFolderActionDefinition CanvasZoom => new DynamicFolderActionDefinition("Canvas zoom",
            "Logi.KritaPlugin.images.Canvas.Zoom.png",
            CanvasZoomAdjustment.AdjustCanvasZoom,
            CanvasZoomAdjustment.GetCanvasZoom);
        public static DynamicFolderActionDefinition CanvasRotation => new DynamicFolderActionDefinition("Canvas rotation",
            "Logi.KritaPlugin.images.Canvas.Rotation.png",
            CanvasRotationAdjustment.AdjustCanvasRotation,
            CanvasRotationAdjustment.GetCanvasRotation);
        public static DynamicFolderActionDefinition BrushSize => new DynamicFolderActionDefinition("Brush size",
            "Logi.KritaPlugin.images.View.BrushSize.png",
            ViewBrushSizeAdjustment.AdjustBrushSize,
            ViewBrushSizeAdjustment.GetBrushSize);
        public static DynamicFolderActionDefinition BrushFlow => new DynamicFolderActionDefinition("Brush flow",
            "Logi.KritaPlugin.images.View.BrushFlow.png",
            ViewBrushFlowAdjustment.AdjustBrushFlow,
            ViewBrushFlowAdjustment.GetBrushFlow);
        public static DynamicFolderActionDefinition BrushOpacity => new DynamicFolderActionDefinition("Brush opacity",
            "Logi.KritaPlugin.images.View.BrushOpacity.png",
            ViewBrushOpacityAdjustment.AdjustBrushOpacity,
            ViewBrushOpacityAdjustment.GetBrushOpacity);
        public static DynamicFolderActionDefinition BrushRotation => new DynamicFolderActionDefinition("Brush rotation",
            "Logi.KritaPlugin.images.View.BrushRotation.png",
            ViewBrushRotationAdjustment.AdjustBrushRotation,
            ViewBrushRotationAdjustment.GetRotation);
        public static DynamicFolderActionDefinition BrushPatternSize => new DynamicFolderActionDefinition("Brush pattern size",
            "Logi.KritaPlugin.images.View.BrushPatternSize.png",
            ViewBrushPatternSizeAdjustment.AdjustBrushPatternSize,
            ViewBrushPatternSizeAdjustment.GetBrushPatternSize);

        public static IDictionary<string, DynamicFolderActionDefinition> Tools => new Dictionary<string, DynamicFolderActionDefinition>
        {
            { Mirror.Name, Mirror },
            { CanvasZoom.Name, CanvasZoom },
            { CanvasRotation.Name, CanvasRotation },
            { BrushSize.Name, BrushSize },
            { BrushFlow.Name, BrushFlow },
            { BrushOpacity.Name, BrushOpacity },
            { BrushRotation.Name, BrushRotation },
            { BrushPatternSize.Name, BrushPatternSize },
        };
    }
}
