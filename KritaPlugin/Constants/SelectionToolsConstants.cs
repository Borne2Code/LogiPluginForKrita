using Logi.KritaPlugin.Actions;
using LogiKritaApiClient.ClientBase;

namespace Logi.KritaPlugin.Constants
{
    internal class SelectionToolsConstants
    {
        public DynamicFolderActionType ActionType { get; }
        public string Name { get; }
        public string BitMapImageName { get; }
        public string ActionName { get; }
        public Action<Client, Int32> AdjustMethod { get; }

        public SelectionToolsConstants(string name, string bitmapImageName, string actionName)
        {
            Name = name;
            BitMapImageName = bitmapImageName;
            ActionName = actionName;
            AdjustMethod = null;
            ActionType = DynamicFolderActionType.Command;
        }

        public SelectionToolsConstants(string name, string bitmapImageName, Action<Client, Int32> adjustMethod)
        {
            Name = name;
            BitMapImageName = bitmapImageName;
            ActionName = null;
            AdjustMethod = adjustMethod;
            ActionType = DynamicFolderActionType.Encoder;
        }

        public static SelectionToolsConstants Rectangle => new SelectionToolsConstants("Rectangular selection", "Logi.KritaPlugin.images.Selection.ToolSelectRectangular.png", ActionsNames.KisToolSelectRectangular);
        public static SelectionToolsConstants Elipse => new SelectionToolsConstants("Eliptical selection", "Logi.KritaPlugin.images.Selection.ToolSelectEliptical.png", ActionsNames.KisToolSelectElliptical);
        public static SelectionToolsConstants Polygone => new SelectionToolsConstants("Polygonal selection", "Logi.KritaPlugin.images.Selection.ToolSelectPolygonal.png", ActionsNames.KisToolSelectPolygonal);
        public static SelectionToolsConstants Freehand => new SelectionToolsConstants("Freehand selection", "Logi.KritaPlugin.images.Selection.ToolSelectFreehand.png", ActionsNames.KisToolSelectOutline);
        public static SelectionToolsConstants SelectAll => new SelectionToolsConstants("Select all", "Logi.KritaPlugin.images.Selection.SelectAll.png", ActionsNames.Select_all);
        public static SelectionToolsConstants Invert => new SelectionToolsConstants("Invert selection", "Logi.KritaPlugin.images.Selection.Invert.png", ActionsNames.Invert_selection);
        public static SelectionToolsConstants Delete => new SelectionToolsConstants("Delete selection", "Logi.KritaPlugin.images.Selection.Delete.png", ActionsNames.Deselect);
        public static SelectionToolsConstants Contiguous => new SelectionToolsConstants("Contiguous selection", "Logi.KritaPlugin.images.Selection.ToolSelectContiguous.png", ActionsNames.KisToolSelectContiguous);
        public static SelectionToolsConstants SimilarColor => new SelectionToolsConstants("SimilarColors selection", "Logi.KritaPlugin.images.Selection.ToolSelectSimilarColors.png", ActionsNames.KisToolSelectSimilar);
        public static SelectionToolsConstants Bezier => new SelectionToolsConstants("Bezier selection", "Logi.KritaPlugin.images.Selection.ToolSelectBezier.png", ActionsNames.KisToolSelectPath);
        public static SelectionToolsConstants Magnetic => new SelectionToolsConstants("Magnetic selection", "Logi.KritaPlugin.images.Selection.ToolSelectMagnetic.png", ActionsNames.KisToolSelectMagnetic);
        public static SelectionToolsConstants GrowShrink => new SelectionToolsConstants("Selection Grow/Shrink", "Logi.KritaPlugin.images.Selection.GrowShrink.png", SelectionGrowShrinkAdjustment.AdjustSelectionSize);

        public static IDictionary<string, SelectionToolsConstants> Tools => new Dictionary<string, SelectionToolsConstants>
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
