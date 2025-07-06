using LogiKritaApiClient.ClientBase;

namespace LogiKritaApiClient.FiltersDialogs
{
    public class KritaFilterHeightToNormal(Client client, bool isModal) : FilterDialogBase(client, isModal)
    {
        public override string ActionName => "krita_filter_height to normal";

        public enum Type
        {
            Prewitt = 0,
            Sobel,
            Simple
        }

        public enum Channel
        {
            Blue = 0,
            Green,
            Red,
            Alpha
        }

        public enum XYZ
        {
            XPlus = 0,
            XMinus,
            YPlus,
            YMinus,
            ZPlus,
            ZMinus
        }

        public Task SetType(Type type)
        {
            return SetComboBoxSelectedIndex((int)type, "cmbType");
        }

        public Task SetChannel(Channel channel)
        {
            return SetComboBoxSelectedIndex((int)channel, "cmbChannel");
        }

        public Task ClickAspectButton()
        {
            return ClickPushButton("btnAspect");
        }

        public Task<float> AdjustHorizontalRadius(float value)
        {
            return AdjustFloatSpinBoxValue(value, "sldHorizontalRadius");
        }

        public Task<float> AdjustVerticalRadius(float value)
        {
            return AdjustFloatSpinBoxValue(value, "sldVerticalRadius");
        }

        public Task SetXValue(XYZ value)
        {
            return SetComboBoxSelectedIndex((int)value, "cmbRed");
        }

        public Task SetYValue(XYZ value)
        {
            return SetComboBoxSelectedIndex((int)value, "cmbGreen");
        }

        public Task SetZValue(XYZ value)
        {
            return SetComboBoxSelectedIndex((int)value, "cmbBlue");
        }
    }
}
