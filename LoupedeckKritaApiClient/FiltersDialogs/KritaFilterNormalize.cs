using LoupedeckKritaApiClient.ClientBase;

namespace LoupedeckKritaApiClient.FiltersDialogs
{
    public class KritaFilterNormalize(Client client) : FilterDialogBase(client)
    {
        protected override string ActionName => "krita_filter_normalize";

        // No parameters
    }
}
