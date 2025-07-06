using LogiKritaApiClient.ClientBase;

namespace LogiKritaApiClient.FiltersDialogs
{
    public class KritaFilterGaussianBlur(Client client, bool isModal) : FilterDialogBase(client, isModal)
    {
        public override string ActionName => "krita_filter_gaussian blur";

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
