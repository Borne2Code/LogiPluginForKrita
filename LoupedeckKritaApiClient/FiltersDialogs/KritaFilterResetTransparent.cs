using LoupedeckKritaApiClient.ClientBase;

namespace LoupedeckKritaApiClient.FiltersDialogs
{
    public class KritaFilterResetTransparent(Client client) : FilterDialogBase(client)
    {
        protected override string ActionName => "krita_filter_resettransparent";

        // No parameters
    }
}
