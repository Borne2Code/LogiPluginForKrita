using Loupedeck.KritaPlugin.DynamicFolders.FilterDefinitions;
using LoupedeckKritaApiClient.FiltersDialogs;

namespace Loupedeck.KritaPlugin.DynamicFolders
{
    public class FilterBlur : FilterDialogBase
    {
        public FilterBlur()
            : base(GetDefinition())
        {
        }

        static internal FilterDialogDefinition GetDefinition()
        {
            return new FilterDialogDefinition("Blur",
                FiltersEnum.Blur,
                [
                    new FilterCommandDefinition("Lock Hor./Vert.", (dialog) => ((KritaFilterBlur)dialog.Dialog).ToggleLockAspect()),
                    new FilterCommandDefinition("Shape Circle", (dialog) => ((KritaFilterBlur)dialog.Dialog).SetShape(KritaFilterBlur.ShapeEnum.Circle)),
                    new FilterCommandDefinition("Shape Rectangle", (dialog) => ((KritaFilterBlur)dialog.Dialog).SetShape(KritaFilterBlur.ShapeEnum.Rectangle)),
                ],
                [
                    new FilterAdjustmentDefinition("Horizontal radius", (dialog, _, delta) => ((KritaFilterBlur)dialog.Dialog).AdjustHorizontalRadiusValue(delta).Result),
                    new FilterAdjustmentDefinition("Vertical radius", (dialog, _, delta) => ((KritaFilterBlur)dialog.Dialog).AdjustVerticalRadiusValue(delta).Result),
                    new FilterAdjustmentDefinition("Strength", (dialog, _, delta) => ((KritaFilterBlur)dialog.Dialog).AdjustStrengthValue(delta).Result),
                    new FilterAdjustmentDefinition("Angle", (dialog, _, delta) => ((KritaFilterBlur)dialog.Dialog).AdjustAngle(-delta).Result, 0, displayDecimals: 0, displayUnit: "°"),
                ]);
        }
    }
}
