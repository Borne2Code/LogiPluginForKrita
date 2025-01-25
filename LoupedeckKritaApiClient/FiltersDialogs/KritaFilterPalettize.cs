using LoupedeckKritaApiClient.ClientBase;

namespace LoupedeckKritaApiClient.FiltersDialogs
{
    public class KritaFilterPalettize(Client client) : FilterDialog(client)
    {
        protected override string ActionName => "krita_filter_palettize";

        // TODO, complex
    }
}
