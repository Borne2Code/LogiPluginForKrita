using LoupedeckKritaApiClient.ClientBase;

namespace LoupedeckKritaApiClient.FiltersDialogs
{
    public class KritaFilterEmbossHorizontalOnly(Client client) : FilterDialog(client)
    {
        protected override string ActionName => "krita_filter_emboss horizontal only";

        // No parameters
    }
}
