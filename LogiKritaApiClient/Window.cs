using LogiKritaApiClient.ClientBase;

namespace LogiKritaApiClient
{
    public class Window() : LogiClientKritaBaseClass()
    {
        public Task Activate() => Execute("activate");
        public Task<View> ActiveView() => Get<View>("activeView");
        public Task<View> AddView(Document document) => Get<View>("addView", document);
        public Task<QMainWindow> QWindow() => Get<QMainWindow>("qwindow");
        public Task ShowView(View view) => Execute("showView", view);
    }
}
