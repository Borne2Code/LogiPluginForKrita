namespace Loupedeck.KritaPlugin.DynamicFolders
{
    public class DialogDefinition
    {
        public DialogDefinition(string name,
            ActionDefinition[] commandsAndAdjustments = null,
            CommandDefinition[] fixedCommands = null)
        {
            Name = name;
            CommandsAndAdjustments = commandsAndAdjustments;
            FixedCommands = fixedCommands;
        }

        public string Name { get; }
        public ActionDefinition[] CommandsAndAdjustments { get; internal set; }
        public CommandDefinition[] FixedCommands { get; internal set; }
    }
}
