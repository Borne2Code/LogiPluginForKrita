using Loupedeck;
using LogiKritaApiClient.ClientBase;

namespace Logi.KritaPlugin.Actions
{
    // This class implements an example adjustment that counts the rotation ticks of a dial.

    public class LayerSelectGlobalSelecionCommand : PluginDynamicCommand
    {
        private Client Client => ((KritaApplication)Plugin.ClientApplication).Client;

        // Initializes the command class.
        public LayerSelectGlobalSelecionCommand()
            : base(displayName: "Global selection", description: "Select global selection layer", groupName: ActionGroups.Layers)
        {
        }

        protected override BitmapImage GetCommandImage(string actionParameter, PluginImageSize imageSize)
        {
            return PluginResources.BitmapFromEmbaddedRessource("Logi.KritaPlugin.images.Layers.GlobalSelection.png");
        }

        protected override void RunCommand(string actionParameter)
        {
            if (Client == null) return;

            Client.CurrentDocument.SetActiveNode(Client.GlobalSelectionNode).Wait();
        }
    }
}
