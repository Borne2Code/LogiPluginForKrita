using LoupedeckKritaApiClient.ClientBase;

namespace LoupedeckKritaApiClient.FiltersDialogs
{
    public class KritaFilterHsvAdjustment(Client client) : FilterDialog(client)
    {
        protected override string ActionName => "krita_filter_hsvadjustment";

        public enum Type
        {
            HueSaturationValue = 0,
            HueSaturationLightness,
            HueSaturationIntensity,
            HueSaturationLuma,
            BlueChromaRedChromaLuma
        }

        public Task SetType(Type type)
        {
            return SetComboBoxSelectedIndex((int)type, "cmbType");
        }

        public Task<int> AdjustHue(int value)
        {
            return AdjustIntSpinBoxValue(value, "hSpinBox");
        }

        public Task<int> AdjustSaturation(int value)
        {
            return AdjustIntSpinBoxValue(value, "sSpinBox");
        }

        public Task<int> AdjustValue(int value)
        {
            return AdjustIntSpinBoxValue(value, "vSpinBox");
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
