using System.Reflection;
using LoupedeckKritaApiClient.FiltersDialogs;

namespace Loupedeck.KritaPlugin.DynamicFolders
{
    public class FilterBlur : FilterDialogBase
    {
        public FilterBlur()
            : base(FilterNames.Blur)
        {
        }

        public override BitmapImage GetButtonImage(PluginImageSize imageSize)
        {
            return BitmapImage.FromResource(Assembly.GetExecutingAssembly(), "Loupedeck.KritaPlugin.images.Filters.filters-Blur.png");
        }

        static internal DialogDefinition GetDefinition()
        {
            return new DialogDefinition("Blur",
                FilterNames.Blur,
                [
                    new CommandDefinition("Lock Hor./Vert.", (dialog) => (dialog.Dialog as KritaFilterBlur).ToggleLockAspect()),
                    new CommandDefinition("Shape Circle", (dialog) => (dialog.Dialog as KritaFilterBlur).SetShape(KritaFilterBlur.ShapeEnum.Circle)),
                    new CommandDefinition("Shape Rectangle", (dialog) => (dialog.Dialog as KritaFilterBlur).SetShape(KritaFilterBlur.ShapeEnum.Rectangle)),
                ],
                [
                    new AdjustmentDefinition("Horizontal radius", (dialog, delta) => (dialog.Dialog as KritaFilterBlur).AdjustHorizontalRadiusValue((int)delta).Result, 5),
                    new AdjustmentDefinition("Vertical radius", (dialog, delta) => (dialog.Dialog as KritaFilterBlur).AdjustVerticalRadiusValue((int)delta).Result, 5),
                    new AdjustmentDefinition("Strength", (dialog, delta) => (dialog.Dialog as KritaFilterBlur).AdjustStrengthValue((int)delta).Result),
                    new AdjustmentDefinition("Angle", (dialog, delta) => (dialog.Dialog as KritaFilterBlur).AdjustAngle((int)delta).Result, 0,
                        (val, delta) => -delta, 0, "°"),
                ]);
        }
    }
}
