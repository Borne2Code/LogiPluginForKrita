using LoupedeckKritaApiClient.FiltersDialogs;

namespace Loupedeck.KritaPlugin.DynamicFolders
{
    public class FilterLensBlur : FilterDialogBase
    {
        public FilterLensBlur()
            : base(FilterNames.LensBlur)
        {
        }

        static internal FilterDialogDefinition GetDefinition()
        {
            return new FilterDialogDefinition("Lens Blur",
                FilterNames.LensBlur,
                "Loupedeck.KritaPlugin.images.Filters.filters-LensBlur.png",
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
