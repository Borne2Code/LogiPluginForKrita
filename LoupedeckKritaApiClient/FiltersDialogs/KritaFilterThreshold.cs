using LoupedeckKritaApiClient.ClientBase;

namespace LoupedeckKritaApiClient.FiltersDialogs
{
    public class KritaFilterThreshold(Client client) : FilterDialogBase(client)
    {
        internal override string ActionName => "krita_filter_threshold";

        public Task<int> AdjustThreshold(int value)
        {
            return AdjustIntSpinBoxValue(value, "intThreshold");
        }
    }
}
