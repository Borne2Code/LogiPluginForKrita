using System.Runtime.CompilerServices;
using LoupedeckKritaApiClient.ClientBase;

namespace LoupedeckKritaApiClient.FiltersDialogs
{
    public class KritaFilterBurn(Client client) : FilterDialog(client)
    {
        public override string ActionName => "krita_filter_burn";

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
