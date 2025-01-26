using LoupedeckKritaApiClient.ClientBase;

namespace LoupedeckKritaApiClient.FiltersDialogs
{
    public class KritaFilterRainDrops(Client client) : FilterDialog(client)
    {
        protected override string ActionName => "krita_filter_raindrops";

        public Task SetDropSize(int size)
        {
            return SetSpinBoxValue(size, "dropsize");
        }

        public Task SetNumberOfDrops(int number)
        {
            return SetSpinBoxValue(number, "number");
        }

        public Task SetFishEyes(int value)
        {
            return SetSpinBoxValue(value, "fishEyes");
        }
    }
}
