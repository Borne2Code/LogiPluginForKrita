using LoupedeckKritaApiClient.ClientBase;

namespace LoupedeckKritaApiClient.FiltersDialogs
{
    public class KritaFilterPhongBumpMap(Client client) : FilterDialog(client)
    {
        protected override string ActionName => "krita_filter_phongbumpmap";

        // TODO: complex filter widget
    }
}
