using LoupedeckKritaApiClient.ClientBase;

namespace LoupedeckKritaApiClient.FiltersDialogs
{
    public class KritaFilterSmallTiles(Client client) : FilterDialogBase(client)
    {
        protected override string ActionName => "krita_filter_smalltiles";

        public Task<int> AdjustNumberOfTiles(int value)
        {
            return AdjustIntSpinBoxValue(value, "numberOfTiles");
        }
    }
}
