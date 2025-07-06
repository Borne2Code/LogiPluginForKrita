namespace Logi.KritaPlugin.DynamicFolders
{
    public class CommandDefinition: ActionDefinition
    {
        public Func<DynamicFolderBase, Task> Action { get; }
        public bool ShoudClose { get; }

        public CommandDefinition(string name, Func<DynamicFolderBase, Task> action, bool shouldClose = false)
            :base(name)
        {
            Action = action;
            ShoudClose = shouldClose;
        }

        static CommandDefinition _empty = new CommandDefinition(string.Empty, null);
        static public CommandDefinition Empty { get => _empty; }
    }
}
