using System.Runtime.CompilerServices;
using LoupedeckKritaApiClient.ClientBase;

namespace LoupedeckKritaApiClient.FiltersDialogs
{
    public class KritaFilterBurn(Client client) : FilterDialogBase(client)
    {
        protected override string ActionName => "krita_filter_burn";

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

        public Task<int> AdjustExposureValue(int value)
        {
            return AdjustIntSpinBoxValue(value, "sliderExposure");
        }
    }
}
