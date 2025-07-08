using LogiKritaApiClient.ClientBase;

namespace Logi.KritaPlugin.Constants
{
    public class DynamicFolderActionDefinition
    {
        public DynamicFolderActionType ActionType { get; }
        public string Name { get; }
        public string BitMapImageName { get; }
        public string ActionName { get; }
        public Action<Client, Int32> AdjustMethod { get; }
        public Action<Client, Int32, Action> AdjustMethodWithValue { get; }
        public Func<Client, string> GetValueMethod { get; }
        public Func<float> GetMinValueMethod { get; }
        public Func<float> GetMaxValueMethod { get; }

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

        public DynamicFolderActionDefinition(string name,
            string bitmapImageName,
            Action<Client, Int32, Action> adjustMethod,
            Func<Client, string> getValueMethod,
            Func<float> getMinValueMethod,
            Func<float> getMaxValueMethod)
        {
            Name = name;
            BitMapImageName = bitmapImageName;
            ActionName = null;
            AdjustMethodWithValue = adjustMethod;
            GetValueMethod = getValueMethod;
            GetMinValueMethod = getMinValueMethod;
            GetMaxValueMethod = getMaxValueMethod;
            ActionType = DynamicFolderActionType.EncoderWithValue;
        }
    }
}
