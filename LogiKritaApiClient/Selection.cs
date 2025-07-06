using LogiKritaApiClient.ClientBase;

namespace LogiKritaApiClient
{
    public class Selection() : LogiClientKritaBaseClass
    {
        public Task Grow(int value) => Execute("grow", value, value);
        public Task Shrink(int value) => Execute("shrink", value, value, false);

    }
}
