using LogiKritaApiClient.ClientBase;

namespace LogiKritaApiClient
{
    public class Document(): LogiClientKritaBaseClass
    {
        public Task<Node> ActiveNode() => Get<Node>("activeNode");
        public Task RefreshProjection() => Execute("refreshProjection");
        public Task SetActiveNode(Node node) => Execute("setActiveNode", node);
    }
}
