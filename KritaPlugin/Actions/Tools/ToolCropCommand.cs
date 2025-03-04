using System.Reflection;
using LoupedeckKritaApiClient.ClientBase;

namespace Loupedeck.KritaPlugin
{
    // This class implements an example adjustment that counts the rotation ticks of a dial.

    public class ToolCropCommand : PluginDynamicCommand
    {
        private Client Client => ((KritaApplication)Plugin.ClientApplication).Client;

        // Initializes the command class.
        public ToolCropCommand()
            : base(displayName: "Crop", description: "Activate Crop tool", groupName: ActionGroups.Tools)
        {
        }

        protected override BitmapImage GetCommandImage(string actionParameter, PluginImageSize imageSize)
        {
            return BitmapImage.FromResource(Assembly.GetExecutingAssembly(), "Loupedeck.KritaPlugin.images.ToolCrop.png");
        }

        protected override void RunCommand(string actionParameter)
        {
            Client.KritaInstance.ExecuteAction(ActionsNames.KisToolCrop).Wait();
        }
    }
}
