using System.Reflection;
using LoupedeckKritaApiClient.ClientBase;

namespace Loupedeck.KritaPlugin
{
    // This class implements an example adjustment that counts the rotation ticks of a dial.

    public class LayerQuickGroup : PluginDynamicCommand
    {
        private Client Client => ((KritaApplication)Plugin.ClientApplication).Client;

        // Initializes the command class.
        public LayerQuickGroup()
            : base(displayName: "Quick group", description: "Quick group", groupName: ActionGroups.Layers)
        {
        }

        protected override BitmapImage GetCommandImage(string actionParameter, PluginImageSize imageSize)
        {
            return BitmapImage.FromResource(Assembly.GetExecutingAssembly(), "Loupedeck.KritaPlugin.images.LayerQuickGroup.png");
        }

        protected override void RunCommand(string actionParameter)
        {
            Client.KritaInstance.ExecuteAction(ActionsNames.Create_quick_group).Wait();
        }
    }
}
