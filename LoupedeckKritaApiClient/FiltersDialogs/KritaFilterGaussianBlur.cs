using LoupedeckKritaApiClient.ClientBase;

namespace LoupedeckKritaApiClient.FiltersDialogs
{
    public class KritaFilterGaussianBlur(Client client) : FilterDialogBase(client)
    {
        protected override string ActionName => "krita_filter_gaussian blur";

        public Task<float> AdjustHorizontalRadius(float value)
        {
            return AdjustFloatSpinBoxValue(value, "horizontalRadius");
        }

        public Task<float> AdjustVerticalRadius(float value)
        {
            return AdjustFloatSpinBoxValue(value, "verticalRadius");
        }

        public Task ToggleLockHorizontalVertical()
        {
            return ClickPushButton("aspectButton");
        }
    }
}
