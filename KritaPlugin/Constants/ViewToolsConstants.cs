using Logi.KritaPlugin.Actions;
using Logi.KritaPlugin.DynamicFolders;
using LogiKritaApiClient.ClientBase;

namespace Logi.KritaPlugin.Constants
{
    public class ViewToolsConstants
    {
        public static DynamicFolderCommandDefinition Mirror => new DynamicFolderCommandDefinition("Mirror view", "Logi.KritaPlugin.images.View.ToggleMirrorView.png", ActionsNames.Mirror_canvas, false);
        public static DynamicFolderAdjustmentWithValueDefinition CanvasZoom => new DynamicFolderAdjustmentWithValueDefinition("Canvas zoom",
            "Logi.KritaPlugin.images.Canvas.Zoom.png",
            CanvasZoomAdjustment.AdjustCanvasZoom,
            CanvasZoomAdjustment.GetCanvasZoom,
            CanvasZoomAdjustment.ResetZoom);
        public static DynamicFolderAdjustmentWithValueDefinition CanvasRotation => new DynamicFolderAdjustmentWithValueDefinition("Canvas rotation",
            "Logi.KritaPlugin.images.Canvas.Rotation.png",
            CanvasRotationAdjustment.AdjustCanvasRotation,
            CanvasRotationAdjustment.GetCanvasRotation,
            CanvasRotationAdjustment.ResetCanvasRotation);
        public static DynamicFolderAdjustmentWithValueDefinition BrushSize => new DynamicFolderAdjustmentWithValueDefinition("Brush size",
            "Logi.KritaPlugin.images.View.BrushSize.png",
            ViewBrushSizeAdjustment.AdjustBrushSize,
            ViewBrushSizeAdjustment.GetBrushSize);
        public static DynamicFolderAdjustmentWithValueDefinition BrushOpacity => new DynamicFolderAdjustmentWithValueDefinition("Brush opacity",
            "Logi.KritaPlugin.images.View.BrushOpacity.png",
            ViewBrushOpacityAdjustment.AdjustBrushOpacity,
            ViewBrushOpacityAdjustment.GetBrushOpacity,
            ViewBrushOpacityAdjustment.ResetBrushOpacity);
        public static DynamicFolderAdjustmentWithValueDefinition BrushFlow => new DynamicFolderAdjustmentWithValueDefinition("Brush flow",
            "Logi.KritaPlugin.images.View.BrushFlow.png",
            ViewBrushFlowAdjustment.AdjustBrushFlow,
            ViewBrushFlowAdjustment.GetBrushFlow,
            ViewBrushFlowAdjustment.ResetBrushFlow);
        public static DynamicFolderAdjustmentDefinition BrushFade => new DynamicFolderAdjustmentDefinition("Brush fade",
            "Logi.KritaPlugin.images.View.BrushFade.png",
            ViewBrushFadeAdjustment.AdjustBrushFade);
        public static DynamicFolderAdjustmentWithValueDefinition BrushRotation => new DynamicFolderAdjustmentWithValueDefinition("Brush rotation",
            "Logi.KritaPlugin.images.View.BrushRotation.png",
            ViewBrushRotationAdjustment.AdjustBrushRotation,
            ViewBrushRotationAdjustment.GetRotation,
            ViewBrushRotationAdjustment.ResetBrushRotation);
        public static DynamicFolderAdjustmentWithValueDefinition BrushPatternSize => new DynamicFolderAdjustmentWithValueDefinition("Brush pattern size",
            "Logi.KritaPlugin.images.View.BrushPatternSize.png",
            ViewBrushPatternSizeAdjustment.AdjustBrushPatternSize,
            ViewBrushPatternSizeAdjustment.GetBrushPatternSize,
            ViewBrushPatternSizeAdjustment.ResetBrushPatternSize);
        public static DynamicFolderCommandDefinition PenPressure => new DynamicFolderCommandDefinition("Pen pressure", "Logi.KritaPlugin.images.View.TogglePenPressure.png", ActionsNames.Disable_pressure, false);

        public static IDictionary<string, DynamicFolderActionDefinition> Tools => new Dictionary<string, DynamicFolderActionDefinition>
        {
            { Mirror.Name, Mirror },
            { CanvasZoom.Name, CanvasZoom },
            { CanvasRotation.Name, CanvasRotation },
            { BrushSize.Name, BrushSize },
            { BrushOpacity.Name, BrushOpacity },
            { BrushFlow.Name, BrushFlow },
            { BrushFade.Name, BrushFade },
            { BrushRotation.Name, BrushRotation },
            { BrushPatternSize.Name, BrushPatternSize },
            { PenPressure.Name, PenPressure },
        };
    }
}
