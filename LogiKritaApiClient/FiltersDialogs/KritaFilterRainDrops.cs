using LogiKritaApiClient.ClientBase;

namespace LogiKritaApiClient.FiltersDialogs
{
    public class KritaFilterRainDrops(Client client, bool isModal) : FilterDialogBase(client, isModal)
    {
        public override string ActionName => "krita_filter_raindrops";

        public Task<int> AdjustDropSize(int size)
        {
            return AdjustIntSpinBoxValue(size, "dropsize");
        }

        public Task<int> AdjustNumberOfDrops(int number)
        {
            return AdjustIntSpinBoxValue(number, "number");
        }

        public Task<int> AdjustFishEyes(int value)
        {
            return AdjustIntSpinBoxValue(value, "fishEyes");
        }
    }
}
