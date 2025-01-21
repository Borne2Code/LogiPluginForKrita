using LoupedeckKritaApiClient.ClientBase;

namespace LoupedeckKritaApiClient
{
    public class QAction() : LoupedeckClientKritaBaseClass
    {
        public Task Trigger() => Execute("trigger");
    }
}
