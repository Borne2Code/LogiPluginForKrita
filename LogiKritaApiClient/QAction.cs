using LogiKritaApiClient.ClientBase;

namespace LogiKritaApiClient
{
    public class QAction() : LogiClientKritaBaseClass
    {
        public Task Trigger() => Execute("trigger");
    }
}
