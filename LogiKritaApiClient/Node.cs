using LogiKritaApiClient.ClientBase;

namespace LogiKritaApiClient
{
    public class Node(): LogiClientKritaBaseClass
    {
        public Task<string> LayerType() => GetStr("type");
        public Task<int> Opacity() => GetInt("opacity");
        public Task SetOpacity(int opacity) => Execute("setOpacity", opacity);
        public Task<Filter> Filter() => Get<Filter>("filter");
    }
}
