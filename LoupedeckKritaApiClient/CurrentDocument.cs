using LoupedeckKritaApiClient.ClientBase;

namespace LoupedeckKritaApiClient
{
    public class CurrentDocument(Client client) : LooupedeckClientKritaBaseClass(client, "currentDocument")
    {
        public async Task<int> GetResolution() => await GetInt("resolution");
        public async Task SetResolution(int resolution) => await Execute("resolution", resolution);
    }
}
