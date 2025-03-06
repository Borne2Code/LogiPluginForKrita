using LoupedeckKritaApiClient.ClientBase;

namespace LoupedeckKritaApiClient.FiltersDialogs
{
    public class KritaFilterLensBlur(Client client) : FilterDialogBase(client)
    {
        protected override string ActionName => "krita_filter_lens blur";

        public enum Shape
        {
            Triangle = 0,
            Quadrilateral,
            Pentagon,
            Hexagon,
            Heptagon,
            Octagon
        }

        public Task SetShape(Shape shape)
        {
            return SetComboBoxSelectedIndex((int)shape, "groupBox", "irisShapeCombo");
        }

        public Task<int> AdjustRadius(int radius)
        {
            return AdjustIntSpinBoxValue(radius, "groupBox", "irisRadiusSlider");
        }

        public Task<float> AdjustIrisRotation(int angle)
        {
            return AdjustAngleSelectorValue(angle, "groupBox", "irisRotationSelector");
        }
    }
}
