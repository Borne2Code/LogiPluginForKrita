using LogiKritaApiClient.ClientBase;
using Loupedeck;

namespace Logi.KritaPlugin.DynamicFolders
{
    public class DynamicFolderCommandDefinition : DynamicFolderActionDefinition
    {
        public string ActionName { get; }
        public Action<Client> Command { get; }
        public VirtualKeyCode? ShortCut { get; }
        public bool ShouldCloseFolder { get; }

        public DynamicFolderCommandDefinition(string name, string bitmapImageName, string actionName, bool shouldCLoseFolder = true)
            : base (name, bitmapImageName)
        {
            ActionName = actionName;
            Command = null;
            ShortCut = null;
            ShouldCloseFolder = shouldCLoseFolder;
        }

        public DynamicFolderCommandDefinition(string name, string bitmapImageName, Action<Client> command, bool shouldCLoseFolder = true)
            : base(name, bitmapImageName)
        {
            ActionName = null;
            Command = command;
            ShortCut = null;
            ShouldCloseFolder = shouldCLoseFolder;
        }

        public DynamicFolderCommandDefinition(string name, string bitmapImageName, VirtualKeyCode shortCut, bool shouldCLoseFolder = true)
            : base(name, bitmapImageName)
        {
            ActionName = null;
            Command = null;
            ShortCut = shortCut;
            ShouldCloseFolder = shouldCLoseFolder;
        }
    }
}
