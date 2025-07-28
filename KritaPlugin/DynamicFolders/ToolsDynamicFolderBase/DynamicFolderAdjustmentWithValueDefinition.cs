using LogiKritaApiClient.ClientBase;

namespace Logi.KritaPlugin.DynamicFolders
{
    public class DynamicFolderAdjustmentWithValueDefinition: DynamicFolderActionDefinition
    {
        public Action<Client, Int32, Action> AdjustMethodWithValue { get; }
        public Func<Client, string> GetValueMethod { get; }
        public Action<Client, Action> ResetValueMethod { get; }

        public DynamicFolderAdjustmentWithValueDefinition(string name,
            string bitmapImageName,
            Action<Client, Int32, Action> adjustMethod,
            Func<Client, string> getValueMethod,
            Action<Client, Action> resetValueMethod = null)
            : base(name, bitmapImageName)
        {
            AdjustMethodWithValue = adjustMethod;
            GetValueMethod = getValueMethod;
            ResetValueMethod = resetValueMethod;
        }
    }
}
