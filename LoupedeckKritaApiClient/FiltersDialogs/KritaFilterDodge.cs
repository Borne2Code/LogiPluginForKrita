using System.Runtime.CompilerServices;
using LoupedeckKritaApiClient.ClientBase;

namespace LoupedeckKritaApiClient.FiltersDialogs
{
    public class KritaFilterDodge(Client client) : FilterDialog(client)
    {
        protected override string ActionName => "krita_filter_dodge";

        public Task SelectShadows()
        {
            return ClickRadio("buttonGroup1", "radioButtonShadows");
        }

        public Task SelectMidTones()
        {
            return ClickRadio("buttonGroup1", "radioButtonMidtones");
        }

        public Task SelectHighLights()
        {
            return ClickRadio("buttonGroup1", "radioButtonHighlights");
        }

        public Task SetExposureValue(int value)
        {
            return SetSpinBoxValue(value, "sliderExposure");
        }
    }
}
