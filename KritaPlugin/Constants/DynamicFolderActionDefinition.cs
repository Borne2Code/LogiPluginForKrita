using LogiKritaApiClient.ClientBase;

namespace Logi.KritaPlugin.Constants
{
    internal class DynamicFolderActionDefinition
    {
        public DynamicFolderActionType ActionType { get; }
        public string Name { get; }
        public string BitMapImageName { get; }
        public string ActionName { get; }
        public Action<Client, Int32> AdjustMethod { get; }

        public DynamicFolderActionDefinition(string name, string bitmapImageName, string actionName)
        {
            Name = name;
            BitMapImageName = bitmapImageName;
            ActionName = actionName;
            AdjustMethod = null;
            ActionType = DynamicFolderActionType.Command;
        }

        public DynamicFolderActionDefinition(string name, string bitmapImageName, Action<Client, Int32> adjustMethod)
        {
            Name = name;
            BitMapImageName = bitmapImageName;
            ActionName = null;
            AdjustMethod = adjustMethod;
            ActionType = DynamicFolderActionType.Encoder;
        }
    }
}
