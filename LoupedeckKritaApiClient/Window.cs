using LoupedeckKritaApiClient.ClientBase;

namespace LoupedeckKritaApiClient
{
    public class Window() : LooupedeckClientKritaBaseClass()
    {
        public async Task<View> ActiveView() => await Get<View>("activeView");
    }
}
