using LoupedeckKritaApiClient.ClientBase;

namespace LoupedeckKritaApiClient
{
    public class View() : LooupedeckClientKritaBaseClass
    {
        public async Task<Canvas> CurrentCanvas() => await Get<Canvas>("canvas");
    }
}
