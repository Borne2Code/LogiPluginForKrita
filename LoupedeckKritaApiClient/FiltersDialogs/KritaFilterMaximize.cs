using LoupedeckKritaApiClient.ClientBase;

namespace LoupedeckKritaApiClient.FiltersDialogs
{
    public class KritaFilterMaximize(Client client) : FilterDialogBase(client)
    {
        protected override string ActionName => "krita_filter_maximize";

        // No parameters
    }
}
