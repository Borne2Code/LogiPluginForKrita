using LoupedeckKritaApiClient.ClientBase;

namespace LoupedeckKritaApiClient.FiltersDialogs
{
    public class KritaFilterMaximize(Client client) : FilterDialogBase(client)
    {
        internal override string ActionName => "krita_filter_maximize";

        // No parameters
    }
}
