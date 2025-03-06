using LoupedeckKritaApiClient.ClientBase;

namespace LoupedeckKritaApiClient.FiltersDialogs
{
    public class KritaFilterSharpen(Client client) : FilterDialogBase(client)
    {
        protected override string ActionName => "krita_filter_sharpen";

        // No parameters
    }
}
