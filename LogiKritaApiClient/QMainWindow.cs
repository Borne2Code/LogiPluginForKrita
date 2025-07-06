using LogiKritaApiClient.ClientBase;

namespace LogiKritaApiClient
{
    public class QMainWindow() : LogiClientKritaBaseClass()
    {
        public Task Show() => Execute("show");
    }
}
