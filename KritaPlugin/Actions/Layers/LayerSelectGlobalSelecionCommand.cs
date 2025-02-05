using LoupedeckKritaApiClient.ClientBase;

namespace Loupedeck.KritaPlugin
{
    // This class implements an example adjustment that counts the rotation ticks of a dial.

    public class LayerSelectGlobalSelecionCommand : PluginDynamicCommand
    {
        private KritaPlugin KritaPlugin => (KritaPlugin)Plugin;

        // Initializes the command class.
        public LayerSelectGlobalSelecionCommand()
            : base(displayName: "Global selection", description: "Select global selection layer", groupName: ActionGroups.Layers)
        {
        }

        protected override BitmapImage GetCommandImage(string actionParameter, PluginImageSize imageSize)
        {
            return EmbeddedResources.ReadImage(EmbeddedResources.FindFile("GlobalSelection.png"));
        }

        protected override void RunCommand(string actionParameter)
        {
            KritaPlugin.Client.CurrentDocument.SetActiveNode(KritaPlugin.Client.GlobalSelectionNode).Wait();
        }
    }
}
