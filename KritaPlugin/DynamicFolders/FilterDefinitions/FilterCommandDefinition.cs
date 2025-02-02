namespace Loupedeck.KritaPlugin.DynamicFolders.FilterDefinitions
{
    internal class FilterCommandDefinition
    {
        public string Name { get; }
        public Action<FilterDialogBase> Action { get; }

        public FilterCommandDefinition(string name, Action<FilterDialogBase> action)
        {
            Name = name;
            Action = action;
        }

        static FilterCommandDefinition _empty = new FilterCommandDefinition(string.Empty, null);
        static public FilterCommandDefinition Empty { get => _empty; }
    }
}
