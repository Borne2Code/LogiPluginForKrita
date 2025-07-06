using LogiKritaApiClient.ClientBase;

namespace LogiKritaApiClient
{
    public class Filter(): LogiClientKritaBaseClass
    {
        public Task<string> name() => GetStr("name");
    }
}
