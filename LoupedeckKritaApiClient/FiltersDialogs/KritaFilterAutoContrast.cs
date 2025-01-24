using LoupedeckKritaApiClient.ClientBase;

namespace LoupedeckKritaApiClient.FiltersDialogs
{
    public class KritaFilterAutoConstrast(Client client) : FilterDialog(client)
    {
        public override string ActionName => "krita_filter_autocontrast";
    }
}
