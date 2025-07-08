using Logi.KritaPlugin.Actions;
using LogiKritaApiClient.ClientBase;

namespace Logi.KritaPlugin.Constants
{
    public class SelectionToolsConstants
    {
        public static DynamicFolderActionDefinition Rectangle => new DynamicFolderActionDefinition("Rectangular selection", "Logi.KritaPlugin.images.Selection.ToolSelectRectangular.png", ActionsNames.KisToolSelectRectangular);
        public static DynamicFolderActionDefinition Elipse => new DynamicFolderActionDefinition("Eliptical selection", "Logi.KritaPlugin.images.Selection.ToolSelectEliptical.png", ActionsNames.KisToolSelectElliptical);
        public static DynamicFolderActionDefinition Polygone => new DynamicFolderActionDefinition("Polygonal selection", "Logi.KritaPlugin.images.Selection.ToolSelectPolygonal.png", ActionsNames.KisToolSelectPolygonal);
        public static DynamicFolderActionDefinition Freehand => new DynamicFolderActionDefinition("Freehand selection", "Logi.KritaPlugin.images.Selection.ToolSelectFreehand.png", ActionsNames.KisToolSelectOutline);
        public static DynamicFolderActionDefinition SelectAll => new DynamicFolderActionDefinition("Select all", "Logi.KritaPlugin.images.Selection.SelectAll.png", ActionsNames.Select_all);
        public static DynamicFolderActionDefinition Invert => new DynamicFolderActionDefinition("Invert selection", "Logi.KritaPlugin.images.Selection.Invert.png", ActionsNames.Invert_selection);
        public static DynamicFolderActionDefinition Delete => new DynamicFolderActionDefinition("Delete selection", "Logi.KritaPlugin.images.Selection.Delete.png", ActionsNames.Deselect);
        public static DynamicFolderActionDefinition Contiguous => new DynamicFolderActionDefinition("Contiguous selection", "Logi.KritaPlugin.images.Selection.ToolSelectContiguous.png", ActionsNames.KisToolSelectContiguous);
        public static DynamicFolderActionDefinition SimilarColor => new DynamicFolderActionDefinition("SimilarColors selection", "Logi.KritaPlugin.images.Selection.ToolSelectSimilarColors.png", ActionsNames.KisToolSelectSimilar);
        public static DynamicFolderActionDefinition Bezier => new DynamicFolderActionDefinition("Bezier selection", "Logi.KritaPlugin.images.Selection.ToolSelectBezier.png", ActionsNames.KisToolSelectPath);
        public static DynamicFolderActionDefinition Magnetic => new DynamicFolderActionDefinition("Magnetic selection", "Logi.KritaPlugin.images.Selection.ToolSelectMagnetic.png", ActionsNames.KisToolSelectMagnetic);
        public static DynamicFolderActionDefinition GrowShrink => new DynamicFolderActionDefinition("Selection Grow/Shrink", "Logi.KritaPlugin.images.Selection.GrowShrink.png", SelectionGrowShrinkAdjustment.AdjustSelectionSize);

        public static IDictionary<string, DynamicFolderActionDefinition> Tools => new Dictionary<string, DynamicFolderActionDefinition>
        {
            { Rectangle.Name, Rectangle },
            { Elipse.Name, Elipse },
            { Polygone.Name, Polygone },
            { Freehand.Name, Freehand },
            { SelectAll.Name, SelectAll },
            { Invert.Name, Invert },
            { Delete.Name, Delete },
            { Contiguous.Name, Contiguous },
            { SimilarColor.Name, SimilarColor },
            { Bezier.Name, Bezier },
            { Magnetic.Name, Magnetic },
            { GrowShrink.Name, GrowShrink }
        };
    }
}
