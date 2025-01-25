using LoupedeckKritaApiClient.ClientBase;

namespace LoupedeckKritaApiClient.FiltersDialogs
{
    public class KritaFilterInvert(Client client) : FilterDialog(client)
    {
        protected override string ActionName => "krita_filter_invert";

        // No parameters
    }
}
