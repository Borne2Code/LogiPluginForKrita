using LoupedeckKritaApiClient.ClientBase;

namespace LoupedeckKritaApiClient
{
    public class Document(): LoupedeckClientKritaBaseClass
    {
        public Task<Node> ActiveNode() => Get<Node>("activeNode");
        public Task<int> GetResolution() => GetInt("resolution");
        public Task SetResolution(int resolution) => Execute("setResolution", resolution);
        public Task RefreshProjection() => Execute("refreshProjection");

        public Task Close() => Execute("close");
    }
}
