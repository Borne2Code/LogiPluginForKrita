using LogiKritaApiClient.ClientBase;

namespace LogiKritaApiClient.FiltersDialogs
{
    public class KritaFilterWaveletNoiseReducer(Client client, bool isModal) : FilterDialogBase(client, isModal)
    {
        public override string ActionName => "krita_filter_waveletnoisereducer";

        public Task<float> AdjustThreshold(float value)
        {
            return AdjustFloatSpinBoxValue(value, "threshold");
        }
    }
}
