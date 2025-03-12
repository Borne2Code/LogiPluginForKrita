using LoupedeckKritaApiClient.ClientBase;

namespace LoupedeckKritaApiClient.FiltersDialogs
{
    public class KritaFilterEmbossVerticalOnly(Client client) : FilterDialogBase(client)
    {
        internal override string ActionName => "krita_filter_emboss vertical only";

        // No parameters
    }
}
