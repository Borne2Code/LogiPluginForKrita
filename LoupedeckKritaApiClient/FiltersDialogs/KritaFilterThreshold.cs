using LoupedeckKritaApiClient.ClientBase;

namespace LoupedeckKritaApiClient.FiltersDialogs
{
    public class KritaFilterThreshold(Client client) : FilterDialog(client)
    {
        protected override string ActionName => "krita_filter_threshold";

        public Task SetThreshold(int value)
        {
            return SetSpinBoxValue(value, "intThreshold");
        }
    }
}
