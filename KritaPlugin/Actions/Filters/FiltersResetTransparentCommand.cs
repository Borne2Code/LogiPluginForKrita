using System.Reflection;
using LoupedeckKritaApiClient.ClientBase;

namespace Loupedeck.KritaPlugin
{
    // This class implements an example adjustment that counts the rotation ticks of a dial.

    public class FiltersResetTransparentCommand : PluginDynamicCommand
    {
        private Client Client => ((KritaApplication)Plugin.ClientApplication).Client;

        // Initializes the command class.
        public FiltersResetTransparentCommand()
            : base(displayName: "Reset Transparent", description: "Apply Reset Transparent filter (Others)", groupName: ActionGroups.Filters)
        {
        }

        protected override void RunCommand(string actionParameter)
        {
            Client.KritaInstance.ExecuteAction(ActionsNames.Krita_filter_resettransparent).Wait();
        }
    }
}
