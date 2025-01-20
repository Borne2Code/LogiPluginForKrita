using LoupedeckKritaApiClient.ClientBase;

namespace LoupedeckKritaApiClient
{
    public class QMainWindow() : LoupedeckClientKritaBaseClass()
    {
        public Task Show() => Execute("show");
    }
}
