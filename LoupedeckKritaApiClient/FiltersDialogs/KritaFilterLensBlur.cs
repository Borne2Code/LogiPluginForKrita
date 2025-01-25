using LoupedeckKritaApiClient.ClientBase;

namespace LoupedeckKritaApiClient.FiltersDialogs
{
    public class KritaFilterLensBlur(Client client) : FilterDialog(client)
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

        public Task SetRadius(int radius)
        {
            return SetSpinBoxValue(radius, "groupBox", "irisRadiusSlider");
        }

        public Task SetIrisRotation(int angle)
        {
            return SetAngleSelectorValue(angle, "groupBox", "irisRotationSelector");
        }
    }
}
