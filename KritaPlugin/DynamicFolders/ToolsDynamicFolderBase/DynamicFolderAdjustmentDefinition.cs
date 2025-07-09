using LogiKritaApiClient.ClientBase;

namespace Logi.KritaPlugin.DynamicFolders
{
    public class DynamicFolderAdjustmentDefinition: DynamicFolderActionDefinition
    {
        public Action<Client, Int32> AdjustMethod { get; }

        public DynamicFolderAdjustmentDefinition(string name, string bitmapImageName, Action<Client, Int32> adjustMethod)
            : base(name, bitmapImageName)
        {
            AdjustMethod = adjustMethod;
        }
    }
}
