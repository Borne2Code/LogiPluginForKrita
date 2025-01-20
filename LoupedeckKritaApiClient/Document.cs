using LoupedeckKritaApiClient.ClientBase;

namespace LoupedeckKritaApiClient
{
    public class Document(): LoupedeckClientKritaBaseClass
    {
        public Task<int> GetResolution() => GetInt("resolution");
        public Task SetResolution(int resolution) => Execute("resolution", resolution);
        public Task Close() => Execute("close");
    }
}
