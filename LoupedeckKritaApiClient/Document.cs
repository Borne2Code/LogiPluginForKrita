using LoupedeckKritaApiClient.ClientBase;

namespace LoupedeckKritaApiClient
{
    public class Document(): LooupedeckClientKritaBaseClass
    {
        public async Task<int> GetResolution() => await GetInt("resolution");
        public async Task SetResolution(int resolution) => await Execute("resolution", resolution);
    }
}
