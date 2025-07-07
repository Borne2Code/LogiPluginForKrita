using LogiKritaApiClient.ClientBase;

namespace Logi.KritaPlugin.Constants
{
    internal class ToolsConstants
    {
        public string Name { get; }
        public string BitMapImageName { get; }
        public string ActionName { get; }

        public ToolsConstants(string name, string bitmapImageName, string actionName)
        {
            Name = name;
            BitMapImageName = bitmapImageName;
            ActionName = actionName;
        }

        public static ToolsConstants Brush => new ToolsConstants("Brush", "Logi.KritaPlugin.images.Tools.Brush.png", ActionsNames.KritaShape_KisToolBrush);
        public static ToolsConstants Fill => new ToolsConstants("Fill", "Logi.KritaPlugin.images.Tools.Fill.png", ActionsNames.KritaFill_KisToolFill);
        public static ToolsConstants Gradient => new ToolsConstants("Gradient", "Logi.KritaPlugin.images.Tools.Gradient.png", ActionsNames.KritaFill_KisToolGradient);
        public static ToolsConstants DynamicBrush => new ToolsConstants("Dynamic Brush", "Logi.KritaPlugin.images.Tools.PaintDynamic.png", ActionsNames.KritaShape_KisToolDyna);
        public static ToolsConstants MultiBrush => new ToolsConstants("Multi Brush", "Logi.KritaPlugin.images.Tools.PaintMultibrush.png", ActionsNames.KritaShape_KisToolMultiBrush);
        public static ToolsConstants ColorizeMask => new ToolsConstants("Colorize Mask", "Logi.KritaPlugin.images.Tools.ColorizeMask.png", ActionsNames.KritaShape_KisToolLazyBrush);
        public static ToolsConstants SmartPatch => new ToolsConstants("Smart patch", "Logi.KritaPlugin.images.Tools.SmartPatch.png", ActionsNames.KritaShape_KisToolSmartPatch);
        public static ToolsConstants EncloseAndFill => new ToolsConstants("Enclose And Fill", "Logi.KritaPlugin.images.Tools.EncloseAndFill.png", ActionsNames.KisToolEncloseAndFill);

        public static IDictionary<string, ToolsConstants> PaintTools => new Dictionary<string, ToolsConstants>
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

        public static ToolsConstants SelectShape => new ToolsConstants("Select shape", "Logi.KritaPlugin.images.Tools.ShapeSelect.png", ActionsNames.InteractionTool);
        public static ToolsConstants Text => new ToolsConstants("Text", "Logi.KritaPlugin.images.Tools.ShapeText.png", ActionsNames.SvgTextTool);
        public static ToolsConstants EditShape => new ToolsConstants("Edit shape", "Logi.KritaPlugin.images.Tools.ShapeEdit.png", ActionsNames.PathTool);
        public static ToolsConstants Calligraphy => new ToolsConstants("Calligraphy", "Logi.KritaPlugin.images.Tools.ShapeCalligraphy.png", ActionsNames.KarbonCalligraphyTool);
        public static ToolsConstants Line => new ToolsConstants("Line", "Logi.KritaPlugin.images.Tools.ShapeLine.png", ActionsNames.KritaShape_KisToolLine);
        public static ToolsConstants Ellipse => new ToolsConstants("Ellipse", "Logi.KritaPlugin.images.Tools.ShapeEllipse.png", ActionsNames.KritaShape_KisToolEllipse);
        public static ToolsConstants Rectangle => new ToolsConstants("Rectangle", "Logi.KritaPlugin.images.Tools.ShapeRectangle.png", ActionsNames.KritaShape_KisToolRectangle);
        public static ToolsConstants Polygone => new ToolsConstants("Polygon", "Logi.KritaPlugin.images.Tools.ShapePolygon.png", ActionsNames.KisToolPolygon);
        public static ToolsConstants Polyline => new ToolsConstants("Polyline", "Logi.KritaPlugin.images.Tools.ShapePolyline.png", ActionsNames.KisToolPolyline);
        public static ToolsConstants Bezier => new ToolsConstants("Bezier", "Logi.KritaPlugin.images.Tools.ShapeBezier.png", ActionsNames.KisToolPath);
        public static ToolsConstants FreeHandPath => new ToolsConstants("Freehand Path", "Logi.KritaPlugin.images.Tools.ShapeFreehandPath.png", ActionsNames.KisToolPencil);

        public static IDictionary<string, ToolsConstants> VectorTools => new Dictionary<string, ToolsConstants>
        {
            { SelectShape.Name, SelectShape },
            { Text.Name, Text },
            { EditShape.Name, EditShape },
            { Calligraphy.Name, Calligraphy },
            { Line.Name, Line },
            { Ellipse.Name, Ellipse },
            { Rectangle.Name, Rectangle },
            { Polygone.Name, Polygone },
            { Polyline.Name, Polyline },
            { Bezier.Name, Bezier },
            { FreeHandPath.Name, FreeHandPath },
        };
    }
}
