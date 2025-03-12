using LoupedeckKritaApiClient.ClientBase;

namespace LoupedeckKritaApiClient.FiltersDialogs
{
    public class KritaFilterEmbossHorizontalOnly(Client client) : FilterDialogBase(client)
    {
        internal override string ActionName => "krita_filter_emboss horizontal only";

        // No parameters
    }
}
