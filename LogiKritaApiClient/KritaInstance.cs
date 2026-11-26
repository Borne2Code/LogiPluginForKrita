using LogiKritaApiClient.ClientBase;

namespace LogiKritaApiClient
{
    public class KritaInstance() : LogiClientKritaBaseClass
    {
        public Task<QAction> Action(string actionName) => Get<QAction>("action", actionName);
        public Task ExecuteAction(string actionName) 
        {
            return ExecuteActionAsync(actionName);
        }
    }
}
