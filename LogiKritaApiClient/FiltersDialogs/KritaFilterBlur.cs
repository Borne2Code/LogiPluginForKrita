using LogiKritaApiClient.ClientBase;

namespace LogiKritaApiClient.FiltersDialogs
{
    public class KritaFilterBlur(Client client, bool isModal) : FilterDialogBase(client, isModal)
    {
        public enum ShapeEnum
        {
            Circle = 0,
            Rectangle
        }

        public override string ActionName => "krita_filter_blur";

        public Task<int> AdjustHorizontalRadiusValue(int value)
        {
            return AdjustIntSpinBoxValue(value, "intHalfWidth");
        }

        public Task<int> AdjustVerticalRadiusValue(int value)
        {
            return AdjustIntSpinBoxValue(value, "intHalfHeight");
        }

        public Task ToggleLockAspect()
        {
            return ClickPushButton("aspectButton");
        }

        public Task<int> AdjustStrengthValue(int value)
        {
            return AdjustIntSpinBoxValue(value, "intStrength");
        }

        public Task<float> AdjustAngle(int value)
        {
            return AdjustAngleSelectorValue(value, "angleSelector");
        }

        public Task SetShape(ShapeEnum value)
        {
            return SetComboBoxSelectedIndex((int)value, "cbShape");
        }
    }
}
