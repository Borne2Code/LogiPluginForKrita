using LoupedeckKritaApiClient.ClientBase;

namespace LoupedeckKritaApiClient
{
    public class Selection() : LoupedeckClientKritaBaseClass
    {
        public Task Grow(int value) => Execute("grow", value, value);
        public Task Shrink(int value) => Execute("shrink", value, value, false);

    }
}
