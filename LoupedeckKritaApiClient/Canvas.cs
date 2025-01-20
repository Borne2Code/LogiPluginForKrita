using LoupedeckKritaApiClient.ClientBase;

namespace LoupedeckKritaApiClient
{
    public class Canvas(): LoupedeckClientKritaBaseClass
    {
        public Task<float> Rotation() => GetFloat("rotation");
        public Task SetRotation(float rotation) => Execute("setRotation", rotation);
        public Task ResetRotation() => Execute("resetRotation");
        public Task<float> ZoomLevel() => GetFloat("zoomLevel");
        public Task SetZoomLevel(float zoomLevel) => Execute("setZoomLevel", zoomLevel);
        public Task ResetZoom() => Execute("resetZoom");

        // TODO: manage bools
    }
}
