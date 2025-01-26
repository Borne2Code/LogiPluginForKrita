using LoupedeckKritaApiClient.ClientBase;

namespace LoupedeckKritaApiClient.FiltersDialogs
{
    public class KritaFilterSmallTiles(Client client) : FilterDialog(client)
    {
        protected override string ActionName => "krita_filter_smalltiles";

        public Task SetNumberOfTiles(int value)
        {
            return SetSpinBoxValue(value, "numberOfTiles");
        }
    }
}
