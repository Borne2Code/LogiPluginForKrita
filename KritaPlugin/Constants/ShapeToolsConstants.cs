using Logi.KritaPlugin.DynamicFolders;
using LogiKritaApiClient.ClientBase;

namespace Logi.KritaPlugin.Constants
{
    public class ShapeToolsConstants
    {
        public static DynamicFolderCommandDefinition SelectShape => new DynamicFolderCommandDefinition("Select shape", "Logi.KritaPlugin.images.Tools.ShapeSelect.png", ActionsNames.InteractionTool);
        public static DynamicFolderCommandDefinition Text => new DynamicFolderCommandDefinition("Text", "Logi.KritaPlugin.images.Tools.ShapeText.png", ActionsNames.SvgTextTool);
        public static DynamicFolderCommandDefinition EditShape => new DynamicFolderCommandDefinition("Edit shape", "Logi.KritaPlugin.images.Tools.ShapeEdit.png", ActionsNames.PathTool);
        public static DynamicFolderCommandDefinition Calligraphy => new DynamicFolderCommandDefinition("Calligraphy", "Logi.KritaPlugin.images.Tools.ShapeCalligraphy.png", ActionsNames.KarbonCalligraphyTool);
        public static DynamicFolderCommandDefinition Line => new DynamicFolderCommandDefinition("Line", "Logi.KritaPlugin.images.Tools.ShapeLine.png", ActionsNames.KritaShape_KisToolLine);
        public static DynamicFolderCommandDefinition Ellipse => new DynamicFolderCommandDefinition("Ellipse", "Logi.KritaPlugin.images.Tools.ShapeEllipse.png", ActionsNames.KritaShape_KisToolEllipse);
        public static DynamicFolderCommandDefinition Rectangle => new DynamicFolderCommandDefinition("Rectangle", "Logi.KritaPlugin.images.Tools.ShapeRectangle.png", ActionsNames.KritaShape_KisToolRectangle);
        public static DynamicFolderCommandDefinition Polygone => new DynamicFolderCommandDefinition("Polygon", "Logi.KritaPlugin.images.Tools.ShapePolygon.png", ActionsNames.KisToolPolygon);
        public static DynamicFolderCommandDefinition Polyline => new DynamicFolderCommandDefinition("Polyline", "Logi.KritaPlugin.images.Tools.ShapePolyline.png", ActionsNames.KisToolPolyline);
        public static DynamicFolderCommandDefinition Bezier => new DynamicFolderCommandDefinition("Bezier", "Logi.KritaPlugin.images.Tools.ShapeBezier.png", ActionsNames.KisToolPath);
        public static DynamicFolderCommandDefinition FreeHandPath => new DynamicFolderCommandDefinition("Freehand Path", "Logi.KritaPlugin.images.Tools.ShapeFreehandPath.png", ActionsNames.KisToolPencil);

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
