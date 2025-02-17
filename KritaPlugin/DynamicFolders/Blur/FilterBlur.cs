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
                    new FilterAdjustmentDefinition("Horizontal radius", (dialog, delta) => ((KritaFilterBlur)dialog.Dialog).AdjustHorizontalRadiusValue((int)delta).Result, 5),
                    new FilterAdjustmentDefinition("Vertical radius", (dialog, delta) => ((KritaFilterBlur)dialog.Dialog).AdjustVerticalRadiusValue((int)delta).Result, 5),
                    new FilterAdjustmentDefinition("Strength", (dialog, delta) => ((KritaFilterBlur)dialog.Dialog).AdjustStrengthValue((int)delta).Result),
                    new FilterAdjustmentDefinition("Angle", (dialog, delta) => ((KritaFilterBlur)dialog.Dialog).AdjustAngle((int)delta).Result, 0,
                        (val, delta) => -delta, 0, "°"),
                ]);
        }
    }
}
