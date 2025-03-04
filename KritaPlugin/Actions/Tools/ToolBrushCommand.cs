using System.Reflection;
using LoupedeckKritaApiClient.ClientBase;

namespace Loupedeck.KritaPlugin
{
    // This class implements an example adjustment that counts the rotation ticks of a dial.

    public class ToolBrushCommand : PluginDynamicCommand
    {
        private Client Client => ((KritaApplication)Plugin.ClientApplication).Client;

        // Initializes the command class.
        public ToolBrushCommand()
            : base(displayName: "Brush", description: "Activate brush tool", groupName: ActionGroups.Tools)
        {
        }

        protected override BitmapImage GetCommandImage(string actionParameter, PluginImageSize imageSize)
        {
            return BitmapImage.FromResource(Assembly.GetExecutingAssembly(), "Loupedeck.KritaPlugin.images.ToolBrush.png");
        }

        protected override void RunCommand(string actionParameter)
        {
            Client.KritaInstance.ExecuteAction(ActionsNames.KritaShape_KisToolBrush).Wait();
        }
    }
}
