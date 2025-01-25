using LoupedeckKritaApiClient.ClientBase;

namespace LoupedeckKritaApiClient.FiltersDialogs
{
    public class KritaFilterGaussianBlur(Client client) : FilterDialog(client)
    {
        protected override string ActionName => "krita_filter_gaussian blur";

        public Task SetHorizontalRadius(float value)
        {
            return SetSpinBoxValue(value, "horizontalRadius");
        }

        public Task SetVerticalRadius(float value)
        {
            return SetSpinBoxValue(value, "verticalRadius");
        }
    }
}
