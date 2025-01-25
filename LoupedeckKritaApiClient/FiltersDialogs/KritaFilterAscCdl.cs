using LoupedeckKritaApiClient.ClientBase;

namespace LoupedeckKritaApiClient.FiltersDialogs
{
    public class KritaFilterAscCdl(Client client) : FilterDialog(client)
    {
        protected override string ActionName => "krita_filter_asc-cdl";

        // TODO: Slope, Offset, Power color selection
    }
}
