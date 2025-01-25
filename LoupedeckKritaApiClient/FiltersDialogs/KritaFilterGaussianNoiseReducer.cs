using LoupedeckKritaApiClient.ClientBase;

namespace LoupedeckKritaApiClient.FiltersDialogs
{
    public class KritaFilterGaussianNoiseReducer(Client client) : FilterDialog(client)
    {
        protected override string ActionName => "krita_filter_gaussiannoisereducer";

        public Task SetThreshold(int value)
        {
            return SetSpinBoxValue(value, "threshold");
        }

        public Task SetWindowSize(int value)
        {
            return SetSpinBoxValue(value, "windowsize");
        }
    }
}
