using Loupedeck;
using LogiKritaApiClient.ClientBase;
using Logi.KritaPlugin.Constants;

namespace Logi.KritaPlugin.Actions
{
    // This class implements an example adjustment that counts the rotation ticks of a dial.

    public class ToolTransformCommand : PluginDynamicCommand
    {
        private Client Client => ((KritaApplication)Plugin.ClientApplication).Client;

        // Initializes the command class.
        public ToolTransformCommand()
            : base(displayName: TransformToolsConstants.Transform.Name, description: "Activate Transform tool", groupName: ActionGroups.Tools)
        {
        }

        protected override BitmapImage GetCommandImage(string actionParameter, PluginImageSize imageSize)
        {
            return PluginResources.BitmapFromEmbaddedRessource(TransformToolsConstants.Transform.BitMapImageName);
        }

        protected override void RunCommand(string actionParameter)
        {
            if (Client == null) return;

            Client.KritaInstance.ExecuteAction(TransformToolsConstants.Transform.ActionName).Wait();
        }
    }
}
