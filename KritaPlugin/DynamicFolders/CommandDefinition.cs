namespace Loupedeck.KritaPlugin.DynamicFolders
{
    public class CommandDefinition
    {
        public string Name { get; }
        public Func<DynamicFolderBase, Task> Action { get; }
        public bool ShoudClose { get; }

        public CommandDefinition(string name, Func<DynamicFolderBase, Task> action, bool shouldClose = false)
        {
            Name = name;
            Action = action;
            ShoudClose = shouldClose;
        }

        static CommandDefinition _empty = new CommandDefinition(string.Empty, null);
        static public CommandDefinition Empty { get => _empty; }
    }
}
