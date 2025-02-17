using Loupedeck.KritaPlugin.DynamicFolders.FilterDefinitions;
using LoupedeckKritaApiClient.FiltersDialogs;

namespace Loupedeck.KritaPlugin.DynamicFolders
{
    public class FilterUnsharpMask : FilterDialogBase
    {
        public FilterUnsharpMask()
            : base(GetDefinition())
        {
        }

        static internal FilterDialogDefinition GetDefinition()
        {
            return new FilterDialogDefinition("Unsharp Mask",
                FiltersEnum.Unsharp,
                [
                    new FilterCommandDefinition("Lightness only", (dialog) => ((KritaFilterUnsharp)dialog.Dialog).ToggleLightnessOnly()),
                ],
                [
                    new FilterAdjustmentDefinition("Radius", (dialog, delta) => ((KritaFilterUnsharp)dialog.Dialog).AdjustRadius(delta).Result, 1),
                    new FilterAdjustmentDefinition("Amount", (dialog, delta) => ((KritaFilterUnsharp)dialog.Dialog).AdjustAmount(delta).Result, 0.5f),
                    new FilterAdjustmentDefinition("Threshold", (dialog, delta) => ((KritaFilterUnsharp)dialog.Dialog).AdjustThreshold((int)delta).Result, 0),
                ]);
        }
    }
}
