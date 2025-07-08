using LogiKritaApiClient.ClientBase;

namespace Logi.KritaPlugin.Constants
{
    public class ShapeToolsConstants
    {
        public static DynamicFolderActionDefinition SelectShape => new DynamicFolderActionDefinition("Select shape", "Logi.KritaPlugin.images.Tools.ShapeSelect.png", ActionsNames.InteractionTool);
        public static DynamicFolderActionDefinition Text => new DynamicFolderActionDefinition("Text", "Logi.KritaPlugin.images.Tools.ShapeText.png", ActionsNames.SvgTextTool);
        public static DynamicFolderActionDefinition EditShape => new DynamicFolderActionDefinition("Edit shape", "Logi.KritaPlugin.images.Tools.ShapeEdit.png", ActionsNames.PathTool);
        public static DynamicFolderActionDefinition Calligraphy => new DynamicFolderActionDefinition("Calligraphy", "Logi.KritaPlugin.images.Tools.ShapeCalligraphy.png", ActionsNames.KarbonCalligraphyTool);
        public static DynamicFolderActionDefinition Line => new DynamicFolderActionDefinition("Line", "Logi.KritaPlugin.images.Tools.ShapeLine.png", ActionsNames.KritaShape_KisToolLine);
        public static DynamicFolderActionDefinition Ellipse => new DynamicFolderActionDefinition("Ellipse", "Logi.KritaPlugin.images.Tools.ShapeEllipse.png", ActionsNames.KritaShape_KisToolEllipse);
        public static DynamicFolderActionDefinition Rectangle => new DynamicFolderActionDefinition("Rectangle", "Logi.KritaPlugin.images.Tools.ShapeRectangle.png", ActionsNames.KritaShape_KisToolRectangle);
        public static DynamicFolderActionDefinition Polygone => new DynamicFolderActionDefinition("Polygon", "Logi.KritaPlugin.images.Tools.ShapePolygon.png", ActionsNames.KisToolPolygon);
        public static DynamicFolderActionDefinition Polyline => new DynamicFolderActionDefinition("Polyline", "Logi.KritaPlugin.images.Tools.ShapePolyline.png", ActionsNames.KisToolPolyline);
        public static DynamicFolderActionDefinition Bezier => new DynamicFolderActionDefinition("Bezier", "Logi.KritaPlugin.images.Tools.ShapeBezier.png", ActionsNames.KisToolPath);
        public static DynamicFolderActionDefinition FreeHandPath => new DynamicFolderActionDefinition("Freehand Path", "Logi.KritaPlugin.images.Tools.ShapeFreehandPath.png", ActionsNames.KisToolPencil);

        public static IDictionary<string, DynamicFolderActionDefinition> Tools => new Dictionary<string, DynamicFolderActionDefinition>
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
