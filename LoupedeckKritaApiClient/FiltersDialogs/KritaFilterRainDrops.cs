using LoupedeckKritaApiClient.ClientBase;

namespace LoupedeckKritaApiClient.FiltersDialogs
{
    public class KritaFilterRainDrops(Client client) : FilterDialogBase(client)
    {
        protected override string ActionName => "krita_filter_raindrops";

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
