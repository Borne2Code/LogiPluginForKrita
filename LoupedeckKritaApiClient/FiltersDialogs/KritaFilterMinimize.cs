using LoupedeckKritaApiClient.ClientBase;

namespace LoupedeckKritaApiClient.FiltersDialogs
{
    public class KritaFilterMinimize(Client client) : FilterDialogBase(client)
    {
        internal override string ActionName => "krita_filter_minimize";

        // No parameters
    }
}
