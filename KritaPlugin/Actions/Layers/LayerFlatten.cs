using LoupedeckKritaApiClient.ClientBase;

namespace Loupedeck.KritaPlugin
{
    // This class implements an example adjustment that counts the rotation ticks of a dial.

    public class LayerFlatten : PluginDynamicCommand
    {
        private KritaPlugin KritaPlugin => (KritaPlugin)Plugin;

        // Initializes the command class.
        public LayerFlatten()
            : base(displayName: "Flatten layer", description: "Flatten layer", groupName: ActionGroups.Layers)
        {
        }

        protected override BitmapImage GetCommandImage(string actionParameter, PluginImageSize imageSize)
        {
            return EmbeddedResources.ReadImage(EmbeddedResources.FindFile("LayerFlatten.png"));
        }

        protected override void RunCommand(string actionParameter)
        {
            KritaPlugin.Client.KritaInstance.ExecuteAction(ActionsNames.Flatten_layer).Wait();
        }
    }
}
