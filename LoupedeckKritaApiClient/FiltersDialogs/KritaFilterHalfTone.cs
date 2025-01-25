using LoupedeckKritaApiClient.ClientBase;

namespace LoupedeckKritaApiClient.FiltersDialogs
{
    public class KritaFilterHalfTone(Client client) : FilterDialog(client)
    {
        protected override string ActionName => "krita_filter_halftone";

        // TODO: complete, very complex
    }
}
