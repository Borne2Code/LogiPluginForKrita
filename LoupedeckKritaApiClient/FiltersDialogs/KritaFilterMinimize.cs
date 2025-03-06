using LoupedeckKritaApiClient.ClientBase;

namespace LoupedeckKritaApiClient.FiltersDialogs
{
    public class KritaFilterMinimize(Client client) : FilterDialogBase(client)
    {
        protected override string ActionName => "krita_filter_minimize";

        // No parameters
    }
}
