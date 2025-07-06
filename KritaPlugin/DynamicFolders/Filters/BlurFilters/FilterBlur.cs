using LoupedeckKritaApiClient.FiltersDialogs;

namespace Loupedeck.KritaPlugin.DynamicFolders
{
    public class FilterBlur : FilterDialogBase
    {
        public FilterBlur()
            : base(FilterNames.Blur)
        {
        }

        static internal FilterDialogDefinition GetDefinition()
        {
            return new FilterDialogDefinition("Blur",
                FilterNames.Blur,
                true,
                "Loupedeck.KritaPlugin.images.Filters.filters-Blur.png",
                [
                    new AdjustmentDefinition("Horizontal radius", (dialog, delta) => (dialog.Dialog as KritaFilterBlur).AdjustHorizontalRadiusValue((int)delta).Result, 5),
                    new AdjustmentDefinition("Vertical radius", (dialog, delta) => (dialog.Dialog as KritaFilterBlur).AdjustVerticalRadiusValue((int)delta).Result, 5),
                    new AdjustmentDefinition("Strength", (dialog, delta) => (dialog.Dialog as KritaFilterBlur).AdjustStrengthValue((int)delta).Result),
                    new AdjustmentDefinition("Angle", (dialog, delta) => (dialog.Dialog as KritaFilterBlur).AdjustAngle((int)delta).Result, 0,
                        (val, delta) => -delta, 0, "°"),

                    new CommandDefinition("Lock Hor./Vert.", (dialog) => (dialog.Dialog as KritaFilterBlur).ToggleLockAspect()),
                    new CommandDefinition("Shape Circle", (dialog) => (dialog.Dialog as KritaFilterBlur).SetShape(KritaFilterBlur.ShapeEnum.Circle)),
                    new CommandDefinition("Shape Rectangle", (dialog) => (dialog.Dialog as KritaFilterBlur).SetShape(KritaFilterBlur.ShapeEnum.Rectangle)),
                ]);
        }
    }
}
