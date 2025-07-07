using Logi.KritaPlugin.Constants;
using LogiKritaApiClient.ClientBase;
using Loupedeck;

namespace Logi.KritaPlugin.Actions
{
    // This class implements an example adjustment that counts the rotation ticks of a dial.

    public class ToolBrushCommand : PluginDynamicCommand
    {
        private Client Client => ((KritaApplication)Plugin.ClientApplication).Client;

        // Initializes the command class.
        public ToolBrushCommand()
            : base(displayName: ToolsConstants.Brush.Name, description: "Activate brush tool", groupName: ActionGroups.Tools)
        {
        }

        protected override BitmapImage GetCommandImage(string actionParameter, PluginImageSize imageSize)
        {
            return PluginResources.BitmapFromEmbaddedRessource(ToolsConstants.Brush.BitMapImageName);
        }

        protected override void RunCommand(string actionParameter)
        {
            if (Client == null) return;
            Client.KritaInstance.ExecuteAction(ToolsConstants.Brush.ActionName).Wait();
        }
    }
}
