using LoupedeckKritaApiClient.ClientBase;

namespace LoupedeckKritaApiClient.FiltersDialogs
{
    public class KritaFilterHalfTone(Client client) : FilterDialogBase(client)
    {
        internal override string ActionName => "krita_filter_halftone";

        // TODO: complete, very complex
    }
}
