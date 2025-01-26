using LoupedeckKritaApiClient.ClientBase;

namespace LoupedeckKritaApiClient.FiltersDialogs
{
    public class KritaFilterSharpen(Client client) : FilterDialog(client)
    {
        protected override string ActionName => "krita_filter_sharpen";

        // No parameters
    }
}
