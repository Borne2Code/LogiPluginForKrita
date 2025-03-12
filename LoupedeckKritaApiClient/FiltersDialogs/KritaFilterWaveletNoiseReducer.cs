using LoupedeckKritaApiClient.ClientBase;

namespace LoupedeckKritaApiClient.FiltersDialogs
{
    public class KritaFilterWaveletNoiseReducer(Client client) : FilterDialogBase(client)
    {
        internal override string ActionName => "krita_filter_waveletnoisereducer";

        public Task<float> AdjustThreshold(float value)
        {
            return AdjustFloatSpinBoxValue(value, "threshold");
        }
    }
}
