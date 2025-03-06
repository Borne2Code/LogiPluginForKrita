namespace Loupedeck.KritaPlugin.DynamicFolders
{
    public class FilterCommandDefinition
    {
        public string Name { get; }
        public Func<FilterDialogBase, Task> Action { get; }

        public FilterCommandDefinition(string name, Func<FilterDialogBase, Task> action)
        {
            Name = name;
            Action = action;
        }

        static FilterCommandDefinition _empty = new FilterCommandDefinition(string.Empty, null);
        static public FilterCommandDefinition Empty { get => _empty; }
    }
}
