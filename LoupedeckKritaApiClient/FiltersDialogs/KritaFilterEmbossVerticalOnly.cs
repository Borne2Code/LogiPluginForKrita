using LoupedeckKritaApiClient.ClientBase;

namespace LoupedeckKritaApiClient.FiltersDialogs
{
    public class KritaFilterEmbossVerticalOnly(Client client) : FilterDialog(client)
    {
        protected override string ActionName => "krita_filter_emboss vertical only";

        // No parameters
    }
}
