using LoupedeckKritaApiClient.ClientBase;

namespace LoupedeckKritaApiClient.FiltersDialogs
{
    public class KritaFilterAutoConstrast(Client client) : FilterDialog(client)
    {
        protected override string ActionName => "krita_filter_autocontrast";

        // No parameters
    }
}
