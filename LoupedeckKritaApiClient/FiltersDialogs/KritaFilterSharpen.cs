using LoupedeckKritaApiClient.ClientBase;

namespace LoupedeckKritaApiClient.FiltersDialogs
{
    public class KritaFilterSharpen(Client client) : FilterDialogBase(client)
    {
        internal override string ActionName => "krita_filter_sharpen";

        // No parameters
    }
}
