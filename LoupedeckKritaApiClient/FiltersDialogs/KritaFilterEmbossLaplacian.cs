using LoupedeckKritaApiClient.ClientBase;

namespace LoupedeckKritaApiClient.FiltersDialogs
{
    public class KritaFilterEmbossLaplacian(Client client) : FilterDialogBase(client)
    {
        protected override string ActionName => "krita_filter_emboss laplascian";

        // No parameters
    }
}
