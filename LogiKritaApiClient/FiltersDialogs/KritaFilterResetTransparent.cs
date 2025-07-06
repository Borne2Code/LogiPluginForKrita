using LogiKritaApiClient.ClientBase;

namespace LogiKritaApiClient.FiltersDialogs
{
    public class KritaFilterResetTransparent(Client client, bool isModal) : FilterDialogBase(client, isModal)
    {
        public override string ActionName => "krita_filter_resettransparent";

        // No parameters
    }
}
