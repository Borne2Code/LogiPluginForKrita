using LoupedeckKritaApiClient.ClientBase;

namespace LoupedeckKritaApiClient
{
    public class KritaInstance() : LooupedeckClientKritaBaseClass
    {
        public async Task<Window> ActiveWindow() => await Get<Window>("activeWindow");
        public async Task<Document> ActiveDocument() => await Get<Document>("activeDocument");
    }
}
