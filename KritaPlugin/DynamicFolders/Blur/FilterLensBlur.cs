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
                [
                    new FilterCommandDefinition("Shape triangle", (dialog) => ((KritaFilterLensBlur)dialog.Dialog).SetShape(KritaFilterLensBlur.Shape.Triangle)),
                    new FilterCommandDefinition("Shape quadrilateral", (dialog) => ((KritaFilterLensBlur)dialog.Dialog).SetShape(KritaFilterLensBlur.Shape.Quadrilateral)),
                    new FilterCommandDefinition("Shape pentagon", (dialog) => ((KritaFilterLensBlur)dialog.Dialog).SetShape(KritaFilterLensBlur.Shape.Pentagon)),
                    new FilterCommandDefinition("Shape hexagon", (dialog) => ((KritaFilterLensBlur)dialog.Dialog).SetShape(KritaFilterLensBlur.Shape.Hexagon)),
                    new FilterCommandDefinition("Shape heptagon", (dialog) => ((KritaFilterLensBlur)dialog.Dialog).SetShape(KritaFilterLensBlur.Shape.Heptagon)),
                    new FilterCommandDefinition("Shape octagon", (dialog) => ((KritaFilterLensBlur)dialog.Dialog).SetShape(KritaFilterLensBlur.Shape.Octagon)),
                ],
                [
                    new FilterAdjustmentDefinition("Radius", (dialog, delta) => ((KritaFilterLensBlur)dialog.Dialog).AdjustRadius((int)delta).Result, 5),
                    new FilterAdjustmentDefinition("Iris rotation", (dialog, delta) => ((KritaFilterLensBlur)dialog.Dialog).AdjustIrisRotation((int)delta).Result),
                ]);
        }
    }
}
