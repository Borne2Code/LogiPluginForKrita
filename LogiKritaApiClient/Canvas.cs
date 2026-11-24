using LogiKritaApiClient.ClientBase;

namespace LogiKritaApiClient
{
    public class Canvas(): LogiClientKritaBaseClass
    {
        public Task ResetRotation() => Execute("resetRotation");
        public Task ResetZoom() => Execute("resetZoom");
        public Task<float> Rotation() => GetFloat("rotation");
        public Task SetRotation(float rotation) => Execute("setRotation", rotation);
        public Task SetZoomLevel(float zoomLevel) => Execute("setZoomLevel", zoomLevel);
        public Task<float> ZoomLevel() => GetFloat("zoomLevel");
    }
}
