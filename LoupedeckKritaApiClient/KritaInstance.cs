using System.Collections.Generic;
using LoupedeckKritaApiClient.ClientBase;

namespace LoupedeckKritaApiClient
{
    public class KritaInstance() : LoupedeckClientKritaBaseClass
    {
        public Task<QAction> Action(string actionName) => Get<QAction>("action", actionName);
        public async Task ExecuteAction(string actionName) 
        {
            await using (var action = await Action(actionName))
            {
                await action.Trigger();
            }
        }

        public Task<IEnumerable<string>> Actions() => GetStringList("actions");
        public Task<Document> ActiveDocument() => Get<Document>("activeDocument");
        public Task<Window> ActiveWindow() => Get<Window>("activeWindow");
        public Task<bool> Batchmode() => GetBool("batchmode");
        public Task<IEnumerable<string>> ColorDepths(string colorModel) => GetStringList("colorDepths", colorModel);
        public Task<IEnumerable<string>> ColorModels() => GetStringList("colorModels");
        public Task<Document> CreateDocument(int width,
            int height,
            string name,
            string colorModel = "RGBA",
            string colorDepth = "U8",
            string profile = "",
            float resolution = 300)
            => Get<Document>("createDocument",
                width,
                height,
                name,
                colorModel,
                colorDepth,
                profile,
                resolution);
        public Task<IEnumerable<string>> Filters() => GetStringList("filters");
        public Task<IEnumerable<string>> FilterStrategies() => GetStringList("filterStrategies");
        public Task<string> GetAppDataLocation() => GetStr("getAppDataLocation");
        public Task<QIcon> Icon(string name) => Get<QIcon>("icon", name);
        public Task<string> Krita_i18n(string text) => GetStr("krita_i18n", text);
        public Task<string> Krita_i18nc(string context, string text) => GetStr("krita_i18nc", context, text);
        public Task<Document> OpenDocument(string filename) => Get<Document>("openDocument", filename);
        public Task<Window> OpenWindow() => Get<Window>("openWindow");
        public Task<IEnumerable<string>> Profiles(string colorModel, string colorDepth) => GetStringList("profiles", colorModel, colorDepth);
        public Task<string> ReadSetting(string group, string name, string defaultValue) => GetStr("profiles", group, name, defaultValue);
        public Task<IEnumerable<string>> RecentDocuments() => GetStringList("recentDocuments");
        public Task SetActiveDocument(Document document) => Execute("setActiveDocument", document);
        public Task setBatchmode(bool value) => Execute("setBatchmode", value);
        public Task<string> Version() => GetStr("version");
        public Task WriteSetting(string group, string name, string value) => Execute("writeSetting", group, name, value);
    }
}
