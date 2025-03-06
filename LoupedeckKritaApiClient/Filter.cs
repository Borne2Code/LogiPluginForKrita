using LoupedeckKritaApiClient.ClientBase;

namespace LoupedeckKritaApiClient
{
    public class Filter(): LoupedeckClientKritaBaseClass
    {
        public Task<string> name() => GetStr("name");
    }
}
