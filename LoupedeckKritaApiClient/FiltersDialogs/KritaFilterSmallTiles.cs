using LoupedeckKritaApiClient.ClientBase;

namespace LoupedeckKritaApiClient.FiltersDialogs
{
    public class KritaFilterSmallTiles(Client client, bool isModal) : FilterDialogBase(client, isModal)
    {
        public override string ActionName => "krita_filter_smalltiles";

        public Task<int> AdjustNumberOfTiles(int value)
        {
            return AdjustIntSpinBoxValue(value, "numberOfTiles");
        }
    }
}
