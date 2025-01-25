using LoupedeckKritaApiClient.ClientBase;

namespace LoupedeckKritaApiClient.FiltersDialogs
{
    public class KritaFilterBlur(Client client) : FilterDialog(client)
    {
        public enum ShapeEnum
        {
            Circle = 0,
            Rectangle
        }

        protected override string ActionName => "krita_filter_blur";

        public Task SetHorizontalRadiusValue(int value)
        {
            return SetSpinBoxValue(value, "intHalfWidth");
        }

        public Task SetVerticalRadiusValue(int value)
        {
            return SetSpinBoxValue(value, "intHalfHeight");
        }

        public Task SetStrengthValue(int value)
        {
            return SetSpinBoxValue(value, "intStrength");
        }

        public Task SetAngle(int value)
        {
            return SetAngleSelectorValue(value, "angleSelector");
        }

        public Task SetShape(ShapeEnum value)
        {
            return SetComboBoxSelectedIndex((int)value, "cbShape");
        }
    }
}
