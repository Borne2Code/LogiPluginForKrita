using Loupedeck;
using LogiKritaApiClient.ClientBase;
using Logi.KritaPlugin.Constants;

namespace Logi.KritaPlugin.Actions
{
    // This class implements an example adjustment that counts the rotation ticks of a dial.

    public class ToolCropCommand : PluginDynamicCommand
    {
        private Client Client => ((KritaApplication)Plugin.ClientApplication).Client;

        // Initializes the command class.
        public ToolCropCommand()
            : base(displayName: TransformToolsConstants.Crop.Name, description: "Activate Crop tool", groupName: ActionGroups.Tools)
        {
        }

        protected override BitmapImage GetCommandImage(string actionParameter, PluginImageSize imageSize)
        {
            return PluginResources.BitmapFromEmbaddedRessource(TransformToolsConstants.Crop.BitMapImageName);
        }

        protected override void RunCommand(string actionParameter)
        {
            if (Client == null) return;

            Client.KritaInstance.ExecuteAction(TransformToolsConstants.Crop.ActionName).Wait();
        }
    }
}
