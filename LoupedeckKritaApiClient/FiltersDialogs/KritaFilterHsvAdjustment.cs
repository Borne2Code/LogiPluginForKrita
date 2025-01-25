using LoupedeckKritaApiClient.ClientBase;

namespace LoupedeckKritaApiClient.FiltersDialogs
{
    public class KritaFilterHsvAdjustment(Client client) : FilterDialog(client)
    {
        protected override string ActionName => "krita_filter_hsvadjustment";

        public enum Type
        {
            HueSaturationValue = 0,
            HueStaturationLightness,
            HueSaturationIntensity,
            HueSaturationLuma,
            BlueChromaRedChromaLuma
        }

        public Task SetType(Type type)
        {
            return SetComboBoxSelectedIndex((int)type, "cmbType");
        }

        public Task SetHue(int value)
        {
            return SetSpinBoxValue(value, "hSpinBox");
        }

        public Task SetSaturation(int value)
        {
            return SetSpinBoxValue(value, "sSpinBox");
        }

        public Task SetValue(int value)
        {
            return SetSpinBoxValue(value, "vSpinBox");
        }

        public Task ToggleColorize()
        {
            return ClickCheckBox("chkColorize");
        }

        public Task ToggleLegacyMode()
        {
            return ClickCheckBox("chkCompatibilityMode");
        }
    }
}
