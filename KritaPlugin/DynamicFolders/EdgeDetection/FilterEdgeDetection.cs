using Loupedeck.KritaPlugin.DynamicFolders.FilterDefinitions;
using LoupedeckKritaApiClient.FiltersDialogs;

namespace Loupedeck.KritaPlugin.DynamicFolders
{
    public class FilterEdgeDetection : FilterDialogBase
    {
        public FilterEdgeDetection()
            : base(GetDefinition())
        {
        }

        static internal FilterDialogDefinition GetDefinition()
        {
            return new FilterDialogDefinition("Edge detection",
                FiltersEnum.EdgeDetection,
                [
                    new FilterCommandDefinition("Formula Prewitt", (dialog) => ((KritaFilterEdgeDetecttion)dialog.Dialog).SelectFormula(KritaFilterEdgeDetecttion.Formula.Prewitt)),
                    new FilterCommandDefinition("Formula Sobel", (dialog) => ((KritaFilterEdgeDetecttion)dialog.Dialog).SelectFormula(KritaFilterEdgeDetecttion.Formula.Sobel)),
                    new FilterCommandDefinition("Formula Simple", (dialog) => ((KritaFilterEdgeDetecttion)dialog.Dialog).SelectFormula(KritaFilterEdgeDetecttion.Formula.Simple)),
                    new FilterCommandDefinition("Lock aspect", (dialog) => ((KritaFilterEdgeDetecttion)dialog.Dialog).ToggleLockAspect()),
                    new FilterCommandDefinition("Output aLl sides", (dialog) => ((KritaFilterEdgeDetecttion)dialog.Dialog).SelectOutput(KritaFilterEdgeDetecttion.Output.AllSides)),
                    new FilterCommandDefinition("Output Top Edge", (dialog) => ((KritaFilterEdgeDetecttion)dialog.Dialog).SelectOutput(KritaFilterEdgeDetecttion.Output.TopEdge)),
                    new FilterCommandDefinition("Output Bottom Edge", (dialog) => ((KritaFilterEdgeDetecttion)dialog.Dialog).SelectOutput(KritaFilterEdgeDetecttion.Output.BottomEdge)),
                    new FilterCommandDefinition("Output Right Edge", (dialog) => ((KritaFilterEdgeDetecttion)dialog.Dialog).SelectOutput(KritaFilterEdgeDetecttion.Output.RightEdge)),
                    new FilterCommandDefinition("Output Left Edge", (dialog) => ((KritaFilterEdgeDetecttion)dialog.Dialog).SelectOutput(KritaFilterEdgeDetecttion.Output.LeftEdge)),
                    new FilterCommandDefinition("Output Direction In Radians", (dialog) => ((KritaFilterEdgeDetecttion)dialog.Dialog).SelectOutput(KritaFilterEdgeDetecttion.Output.DirectionInRadians)),
                    new FilterCommandDefinition("Apply to alpha", (dialog) => ((KritaFilterEdgeDetecttion)dialog.Dialog).ToggleApplyResultToAlphaChannel()),
                ],
                [
                    new FilterAdjustmentDefinition("Horizontal radius", (dialog, delta) => ((KritaFilterEdgeDetecttion)dialog.Dialog).AdjustHorizontalRadius(delta).Result, 1),
                    new FilterAdjustmentDefinition("Vertical radius", (dialog, delta) => ((KritaFilterEdgeDetecttion)dialog.Dialog).AdjustVerticalRadius(delta).Result, 1),
                ]);
        }
    }
}
