using System.Reflection;
using LoupedeckKritaApiClient.FiltersDialogs;

namespace Loupedeck.KritaPlugin.DynamicFolders
{
    public class FilterLensBlur : FilterDialogBase
    {
        public FilterLensBlur()
            : base(FilterNames.LensBlur)
        {
        }

        public override BitmapImage GetButtonImage(PluginImageSize imageSize)
        {
            return BitmapImage.FromResource(Assembly.GetExecutingAssembly(), "Loupedeck.KritaPlugin.images.Filters.filters-LensBlur.png");
        }

        static internal DialogDefinition GetDefinition()
        {
            return new DialogDefinition("Lens Blur",
                FilterNames.LensBlur,
                [
                    new CommandDefinition("Shape triangle", (dialog) => (dialog.Dialog as KritaFilterLensBlur).SetShape(KritaFilterLensBlur.Shape.Triangle)),
                    new CommandDefinition("Shape quadrilateral", (dialog) => (dialog.Dialog as KritaFilterLensBlur).SetShape(KritaFilterLensBlur.Shape.Quadrilateral)),
                    new CommandDefinition("Shape pentagon", (dialog) => (dialog.Dialog as KritaFilterLensBlur).SetShape(KritaFilterLensBlur.Shape.Pentagon)),
                    new CommandDefinition("Shape hexagon", (dialog) => (dialog.Dialog as KritaFilterLensBlur).SetShape(KritaFilterLensBlur.Shape.Hexagon)),
                    new CommandDefinition("Shape heptagon", (dialog) => (dialog.Dialog as KritaFilterLensBlur).SetShape(KritaFilterLensBlur.Shape.Heptagon)),
                    new CommandDefinition("Shape octagon", (dialog) => (dialog.Dialog as KritaFilterLensBlur).SetShape(KritaFilterLensBlur.Shape.Octagon)),
                ],
                [
                    new AdjustmentDefinition("Radius", (dialog, delta) => (dialog.Dialog as KritaFilterLensBlur).AdjustRadius((int)delta).Result, 5),
                    new AdjustmentDefinition("Iris rotation", (dialog, delta) => (dialog.Dialog as KritaFilterLensBlur).AdjustIrisRotation((int)delta).Result),
                ]);
        }
    }
}
