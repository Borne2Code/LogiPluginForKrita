namespace Loupedeck.KritaPlugin.DynamicFolders
{
    public class DialogDefinition
    {
        public DialogDefinition(string name,
            CommandDefinition[] commands = null,
            CommandDefinition[] fixedCommands = null,
            AdjustmentDefinition[] adjustments = null)
        {
            Name = name;
            Commands = commands;
            FixedCommands = fixedCommands;
            Adjustments = adjustments;
        }

        public string Name { get; }
        public CommandDefinition[] Commands { get; }
        public CommandDefinition[] FixedCommands { get; }
        public AdjustmentDefinition[] Adjustments { get; }
    }
}
