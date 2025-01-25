using LoupedeckKritaApiClient.ClientBase;

namespace LoupedeckKritaApiClient.FiltersDialogs
{
    public class KritaFilterNoise(Client client) : FilterDialog(client)
    {
        protected override string ActionName => "krita_filter_noise";

        public Task SetLevel(int value)
        {
            return SetSpinBoxValue(value, "intLevel");
        }

        public Task SetOpacity(int value)
        {
            return SetSpinBoxValue(value, "intOpacity");
        }
    }
}
