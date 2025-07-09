using LogiKritaApiClient.ClientBase;

namespace Logi.KritaPlugin.DynamicFolders
{
    public class DynamicFolderAdjustmentWithValueDefinition: DynamicFolderActionDefinition
    {
        public Action<Client, Int32, Action> AdjustMethodWithValue { get; }
        public Func<Client, string> GetValueMethod { get; }

        public DynamicFolderAdjustmentWithValueDefinition(string name,
            string bitmapImageName,
            Action<Client, Int32, Action> adjustMethod,
            Func<Client, string> getValueMethod)
            : base(name, bitmapImageName)
        {
            AdjustMethodWithValue = adjustMethod;
            GetValueMethod = getValueMethod;
        }
    }
}
