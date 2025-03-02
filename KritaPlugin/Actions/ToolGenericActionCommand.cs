using LoupedeckKritaApiClient.ClientBase;

namespace Loupedeck.KritaPlugin
{
    // This class implements an example adjustment that counts the rotation ticks of a dial.

    public class ToolGenericActionCommand : PluginDynamicCommand
    {
        private Client Client => ((KritaApplication)Plugin.ClientApplication).Client;

        // Initializes the command class.
        public ToolGenericActionCommand()
            : base(displayName: "Action", description: "Execute a selected action", groupName: ActionGroups.Tools)
        {
            this.MakeProfileAction("text;Enter action name:");
        }

        protected override void RunCommand(string actionParameter)
        {
            Client.KritaInstance.ExecuteAction(actionParameter).Wait();
        }
    }
}
