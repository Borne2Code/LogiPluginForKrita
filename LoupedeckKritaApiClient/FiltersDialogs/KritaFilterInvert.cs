using LoupedeckKritaApiClient.ClientBase;

namespace LoupedeckKritaApiClient.FiltersDialogs
{
    public class KritaFilterInvert(Client client) : FilterDialogBase(client)
    {
        internal override string ActionName => "krita_filter_invert";

        // No parameters
    }
}
