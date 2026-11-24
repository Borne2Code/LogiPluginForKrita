using LogiKritaApiClient.ClientBase;

namespace LogiKritaApiClient
{
    public class KritaInstance() : LogiClientKritaBaseClass
    {
        public Task<QAction> Action(string actionName) => Get<QAction>("action", actionName);
        public async Task ExecuteAction(string actionName) 
        {
            await using (var action = await Action(actionName))
            {
                await action.Trigger();
            }
        }
    }
}
