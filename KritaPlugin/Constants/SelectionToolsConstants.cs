using Logi.KritaPlugin.Actions;
using Logi.KritaPlugin.DynamicFolders;
using LogiKritaApiClient.ClientBase;

namespace Logi.KritaPlugin.Constants
{
    public class SelectionToolsConstants
    {
        public static DynamicFolderCommandDefinition Rectangle => new DynamicFolderCommandDefinition("Rectangular", "Logi.KritaPlugin.images.Selection.ToolSelectRectangular.png", ActionsNames.KisToolSelectRectangular);
        public static DynamicFolderCommandDefinition Elipse => new DynamicFolderCommandDefinition("Eliptical", "Logi.KritaPlugin.images.Selection.ToolSelectEliptical.png", ActionsNames.KisToolSelectElliptical);
        public static DynamicFolderCommandDefinition Polygone => new DynamicFolderCommandDefinition("Polygonal", "Logi.KritaPlugin.images.Selection.ToolSelectPolygonal.png", ActionsNames.KisToolSelectPolygonal);
        public static DynamicFolderCommandDefinition Freehand => new DynamicFolderCommandDefinition("Freehand", "Logi.KritaPlugin.images.Selection.ToolSelectFreehand.png", ActionsNames.KisToolSelectOutline);
        public static DynamicFolderCommandDefinition SelectAll => new DynamicFolderCommandDefinition("Select all", "Logi.KritaPlugin.images.Selection.SelectAll.png", ActionsNames.Select_all);
        public static DynamicFolderCommandDefinition Invert => new DynamicFolderCommandDefinition("Invert selection", "Logi.KritaPlugin.images.Selection.Invert.png", ActionsNames.Invert_selection);
        public static DynamicFolderCommandDefinition Delete => new DynamicFolderCommandDefinition("Delete selection", "Logi.KritaPlugin.images.Selection.Delete.png", ActionsNames.Deselect);
        public static DynamicFolderCommandDefinition Contiguous => new DynamicFolderCommandDefinition("Contiguous", "Logi.KritaPlugin.images.Selection.ToolSelectContiguous.png", ActionsNames.KisToolSelectContiguous);
        public static DynamicFolderCommandDefinition SimilarColor => new DynamicFolderCommandDefinition("SimilarColors", "Logi.KritaPlugin.images.Selection.ToolSelectSimilarColors.png", ActionsNames.KisToolSelectSimilar);
        public static DynamicFolderCommandDefinition Bezier => new DynamicFolderCommandDefinition("Bezier", "Logi.KritaPlugin.images.Selection.ToolSelectBezier.png", ActionsNames.KisToolSelectPath);
        public static DynamicFolderCommandDefinition Magnetic => new DynamicFolderCommandDefinition("Magnetic", "Logi.KritaPlugin.images.Selection.ToolSelectMagnetic.png", ActionsNames.KisToolSelectMagnetic);
        public static DynamicFolderAdjustmentDefinition GrowShrink => new DynamicFolderAdjustmentDefinition("Grow/Shrink", "Logi.KritaPlugin.images.Selection.GrowShrink.png", SelectionGrowShrinkAdjustment.AdjustSelectionSize);

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
