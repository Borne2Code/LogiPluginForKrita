using LoupedeckKritaApiClient.ClientBase;

namespace LoupedeckKritaApiClient.FiltersDialogs
{
    public class KritaFilterEmbossAllDirections(Client client) : FilterDialogBase(client)
    {
        protected override string ActionName => "krita_filter_emboss all directions";

        // No parameters
    }
}
