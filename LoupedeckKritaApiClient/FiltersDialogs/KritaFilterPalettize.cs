using LoupedeckKritaApiClient.ClientBase;

namespace LoupedeckKritaApiClient.FiltersDialogs
{
    public class KritaFilterPalettize(Client client) : FilterDialogBase(client)
    {
        protected override string ActionName => "krita_filter_palettize";

        // TODO, complex
    }
}
