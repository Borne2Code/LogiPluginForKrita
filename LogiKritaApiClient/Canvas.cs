using LogiKritaApiClient.ClientBase;

namespace LogiKritaApiClient
{
    public class Canvas(): LogiClientKritaBaseClass
    {
        public Task<bool> LevelOfDetailMode() => GetBool("levelOfDetailMode");
        public Task<bool> Mirror() => GetBool("mirror");
        public Task ResetRotation() => Execute("resetRotation");
        public Task ResetZoom() => Execute("resetZoom");
        public Task<float> Rotation() => GetFloat("rotation");
        public Task SetLevelOfDetailMode(float enabled) => Execute("setLevelOfDetailMode", enabled);
        public Task SetMirror(bool enabled) => Execute("setMirror", enabled);
        public Task SetRotation(float rotation) => Execute("setRotation", rotation);
        public Task SetWrapAroundMode(bool enabled) => Execute("setWrapAroundMode", enabled);
        public Task SetZoomLevel(float zoomLevel) => Execute("setZoomLevel", zoomLevel);
        public Task<View> View() => Get<View>("view");
        public Task<bool> WrapAroundMode() => GetBool("wrapAroundMode");
        public Task<float> ZoomLevel() => GetFloat("zoomLevel");
    }
}
