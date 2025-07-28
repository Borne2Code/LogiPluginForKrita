using LogiKritaApiClient.ClientBase;

namespace LogiKritaApiClient
{
    public class Node(): LogiClientKritaBaseClass
    {
        public Task<string> LayerType() => GetStr("type");
        public Task<int> Opacity() => GetInt("opacity");
        public Task SetOpacity(int opacity) => Execute("setOpacity", opacity);
        public Task<bool> AlphaLocked() => GetBool("alphaLocked");
        public Task SetAlphaLocked(bool locked) => Execute("setAlphaLocked", locked);
        public Task<bool> InheritAlpha() => GetBool("inheritAlpha");
        public Task SetInheritAlpha(bool inherit) => Execute("setInheritAlpha", inherit);
        public Task<bool> Locked() => GetBool("locked");
        public Task SetLocked(bool locked) => Execute("setLocked", locked);
        public Task<Filter> Filter() => Get<Filter>("filter");
    }
}
