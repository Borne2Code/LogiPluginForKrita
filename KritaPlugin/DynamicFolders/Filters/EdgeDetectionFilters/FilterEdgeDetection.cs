using LogiKritaApiClient.FiltersDialogs;

namespace Logi.KritaPlugin.DynamicFolders
{
    public class FilterEdgeDetection : FilterDialogBase
    {
        public FilterEdgeDetection()
            : base(FilterNames.EdgeDetection)
        {
        }

        static internal FilterDialogDefinition GetDefinition()
        {
            return new FilterDialogDefinition("Edge detection",
                FilterNames.EdgeDetection,
                true,
                "Logi.KritaPlugin.images.Filters.filters-EdgeDetection.png",
                [
                    new AdjustmentDefinition("Horizontal radius", (dialog, delta) => (dialog.Dialog as KritaFilterEdgeDetecttion).AdjustHorizontalRadius(delta).Result, 1),
                    new AdjustmentDefinition("Vertical radius", (dialog, delta) => (dialog.Dialog as KritaFilterEdgeDetecttion).AdjustVerticalRadius(delta).Result, 1),

                    new CommandDefinition("Formula Prewitt", (dialog) => (dialog.Dialog as KritaFilterEdgeDetecttion).SelectFormula(KritaFilterEdgeDetecttion.Formula.Prewitt)),
                    new CommandDefinition("Formula Sobel", (dialog) => (dialog.Dialog as KritaFilterEdgeDetecttion).SelectFormula(KritaFilterEdgeDetecttion.Formula.Sobel)),
                    new CommandDefinition("Formula Simple", (dialog) => (dialog.Dialog as KritaFilterEdgeDetecttion).SelectFormula(KritaFilterEdgeDetecttion.Formula.Simple)),
                    new CommandDefinition("Lock aspect", (dialog) => (dialog.Dialog as KritaFilterEdgeDetecttion).ToggleLockAspect()),
                    new CommandDefinition("Output aLl sides", (dialog) => (dialog.Dialog as KritaFilterEdgeDetecttion).SelectOutput(KritaFilterEdgeDetecttion.Output.AllSides)),
                    new CommandDefinition("Output Top Edge", (dialog) => (dialog.Dialog as KritaFilterEdgeDetecttion).SelectOutput(KritaFilterEdgeDetecttion.Output.TopEdge)),
                    new CommandDefinition("Output Bottom Edge", (dialog) => (dialog.Dialog as KritaFilterEdgeDetecttion).SelectOutput(KritaFilterEdgeDetecttion.Output.BottomEdge)),
                    new CommandDefinition("Output Right Edge", (dialog) => (dialog.Dialog as KritaFilterEdgeDetecttion).SelectOutput(KritaFilterEdgeDetecttion.Output.RightEdge)),
                    new CommandDefinition("Output Left Edge", (dialog) => (dialog.Dialog as KritaFilterEdgeDetecttion).SelectOutput(KritaFilterEdgeDetecttion.Output.LeftEdge)),
                    new CommandDefinition("Output Direction In Radians", (dialog) => (dialog.Dialog as KritaFilterEdgeDetecttion).SelectOutput(KritaFilterEdgeDetecttion.Output.DirectionInRadians)),
                    new CommandDefinition("Apply to alpha", (dialog) => (dialog.Dialog as KritaFilterEdgeDetecttion).ToggleApplyResultToAlphaChannel()),
                ]);
        }
    }
}
