using LoupedeckKritaApiClient.ClientBase;

namespace LoupedeckKritaApiClient.FiltersDialogs
{
    public class KritaFilterEmbossVerticalOnly(Client client) : FilterDialogBase(client)
    {
        protected override string ActionName => "krita_filter_emboss vertical only";

        // No parameters
    }
}
