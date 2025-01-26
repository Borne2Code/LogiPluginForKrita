using LoupedeckKritaApiClient.ClientBase;

namespace LoupedeckKritaApiClient.FiltersDialogs
{
    public class KritaFilterRoundCorners(Client client) : FilterDialog(client)
    {
        protected override string ActionName => "krita_filter_roundcorners";

        public Task SetRadius(int radius)
        {
            return SetSpinBoxValue(radius, "radius");
        }
    }
}
