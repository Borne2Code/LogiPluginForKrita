using LoupedeckKritaApiClient.ClientBase;

namespace LoupedeckKritaApiClient.FiltersDialogs
{
    public class KritaFilterNormalize(Client client) : FilterDialog(client)
    {
        protected override string ActionName => "krita_filter_normalize";

        // No parameters
    }
}
