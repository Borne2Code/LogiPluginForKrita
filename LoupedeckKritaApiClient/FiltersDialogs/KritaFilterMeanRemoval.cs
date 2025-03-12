using LoupedeckKritaApiClient.ClientBase;

namespace LoupedeckKritaApiClient.FiltersDialogs
{
    public class KritaFilterMeanRemoval(Client client) : FilterDialogBase(client)
    {
        internal override string ActionName => "krita_filter_mean removal";

        // No parameters
    }
}
