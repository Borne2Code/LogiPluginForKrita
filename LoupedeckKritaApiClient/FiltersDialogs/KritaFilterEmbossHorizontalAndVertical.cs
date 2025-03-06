using LoupedeckKritaApiClient.ClientBase;

namespace LoupedeckKritaApiClient.FiltersDialogs
{
    public class KritaFilterEmbossHorizontalAndVertical(Client client) : FilterDialogBase(client)
    {
        protected override string ActionName => "krita_filter_emboss horizontal and vertical";

        // No parameters
    }
}
