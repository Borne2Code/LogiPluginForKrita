namespace Loupedeck.KritaPlugin.DynamicFolders
{
    public class FilterDialogDefinition
    {
        public FilterDialogDefinition(string name,
            string filterName,
            FilterCommandDefinition[] commands,
            FilterAdjustmentDefinition[] adjustments)
        {
            Name = name;
            FilterName = filterName;
            HasDialog = true;
            Commands = commands;
            Adjustments = adjustments;
        }

        public FilterDialogDefinition(string name,
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
        public FilterCommandDefinition[] Commands { get; }
        public FilterAdjustmentDefinition[] Adjustments { get; }
    }
}
