using Loupedeck;
using LogiKritaApiClient.ClientBase;
using Logi.KritaPlugin.Constants;

namespace Logi.KritaPlugin.Actions
{
    // This class implements an example adjustment that counts the rotation ticks of a dial.

    public class ToggleMirrorViewCommand : PluginDynamicCommand
    {
        private Client Client => ((KritaApplication)Plugin.ClientApplication).Client;

        // Initializes the command class.
        public ToggleMirrorViewCommand()
            : base(displayName: ViewToolsConstants.Mirror.Name, description: "Toggle Mirror view mode", groupName: ActionGroups.ViewAdjustements)
        {
        }

        protected override BitmapImage GetCommandImage(string actionParameter, PluginImageSize imageSize)
        {
            return PluginResources.BitmapFromEmbaddedRessource(ViewToolsConstants.Mirror.BitMapImageName);
        }

        protected override void RunCommand(string actionParameter)
        {
            if (Client == null) return;

            Client.KritaInstance.ExecuteAction(ViewToolsConstants.Mirror.ActionName).Wait();
        }
    }
}
