namespace Loupedeck.KritaPlugin.DynamicFolders
{
    public class DialogDefinition
    {
        public DialogDefinition(string name,
            string filterName,
            CommandDefinition[] commands,
            AdjustmentDefinition[] adjustments)
        {
            Name = name;
            FilterName = filterName;
            HasDialog = true;
            Commands = commands;
            Adjustments = adjustments;
        }

        public DialogDefinition(string name,
            string filterName)
        {
            Name = name;
            FilterName = filterName;
            HasDialog = false;
            Commands = null;
            Adjustments = null;
        }

        public string Name { get; }
        public string FilterName { get; }
        public bool HasDialog { get; }
        public CommandDefinition[] Commands { get; }
        public AdjustmentDefinition[] Adjustments { get; }
    }
}
