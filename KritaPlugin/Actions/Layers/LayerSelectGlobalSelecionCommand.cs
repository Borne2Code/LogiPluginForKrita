using Loupedeck;
using LogiKritaApiClient.ClientBase;
using Logi.KritaPlugin.Constants;

namespace Logi.KritaPlugin.Actions
{
    // This class implements an example adjustment that counts the rotation ticks of a dial.

    public class LayerSelectGlobalSelecionCommand : PluginDynamicCommand
    {
        private Client Client => ((KritaApplication)Plugin.ClientApplication).Client;

        // Initializes the command class.
        public LayerSelectGlobalSelecionCommand()
            : base(displayName: LayerToolsConstants.GlobalSelection.Name, description: "Select global selection layer", groupName: ActionGroups.Layers)
        {
        }

        protected override BitmapImage GetCommandImage(string actionParameter, PluginImageSize imageSize)
        {
            return PluginResources.BitmapFromEmbaddedRessource(LayerToolsConstants.GlobalSelection.BitMapImageName);
        }

        protected override void RunCommand(string actionParameter)
        {
            SelectGlobalSelectionMask(Client);
        }

        public static void SelectGlobalSelectionMask(Client client)
        {
            if (client == null) return;

            client.CurrentDocument.SetActiveNode(client.GlobalSelectionNode).Wait();
        }
    }
}
