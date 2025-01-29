namespace Loupedeck.KritaPlugin
{
    // This class implements an example adjustment that counts the rotation ticks of a dial.

    public class ToolGenericActionCommand : PluginDynamicCommand
    {
        private KritaPlugin KritaPlugin => (KritaPlugin)Plugin;

        // Initializes the command class.
        public ToolGenericActionCommand()
            : base(displayName: "Action", description: "Execute a selected action", groupName: ActionGroups.Tools)
        {
            this.MakeProfileAction("text;Enter action name:");
        }

        protected override void RunCommand(string actionParameter)
        {
            KritaPlugin.Client.KritaInstance.ExecuteAction(actionParameter).Wait();
        }
    }
}
