using LoupedeckKritaApiClient.ClientBase;

namespace LoupedeckKritaApiClient
{
    public class View() : LoupedeckClientKritaBaseClass
    {
        public Task<Canvas> CurrentCanvas() => Get<Canvas>("canvas");
    }
}
