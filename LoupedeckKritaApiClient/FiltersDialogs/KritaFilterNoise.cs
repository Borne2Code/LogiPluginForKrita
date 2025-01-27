using LoupedeckKritaApiClient.ClientBase;

namespace LoupedeckKritaApiClient.FiltersDialogs
{
    public class KritaFilterNoise(Client client) : FilterDialog(client)
    {
        protected override string ActionName => "krita_filter_noise";

        public Task<int> AdjustLevel(int value)
        {
            return AdjustIntSpinBoxValue(value, "intLevel");
        }

        public Task<int> AdjustOpacity(int value)
        {
            return AdjustIntSpinBoxValue(value, "intOpacity");
        }
    }
}
