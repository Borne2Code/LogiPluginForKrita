using LoupedeckKritaApiClient.ClientBase;

namespace LoupedeckKritaApiClient
{
    public class CurrentCanvas(Client client) : LooupedeckClientKritaBaseClass(client, "currentCanvas")
    {
        public async Task<float> GetRotation() => await GetFloat("rotation");
        public async Task SetRotation(float rotation) => await Execute("setRotation", rotation);

        public async Task<float> GetZoomLevel() => await GetFloat("zoomLevel");
        public async Task SetZoomLevel(float zoomLevel) => await Execute("setZoomLevel", zoomLevel);
    }
}
