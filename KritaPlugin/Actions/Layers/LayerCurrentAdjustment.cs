using Loupedeck;
using LogiKritaApiClient.ClientBase;
using Logi.KritaPlugin.Constants;

namespace Logi.KritaPlugin.Actions
{
    // This class implements an example adjustment that counts the rotation ticks of a dial.

    public class LayerCurrentAdjustment : PluginDynamicAdjustment
    {
        private Client Client => ((KritaApplication)Plugin.ClientApplication).Client;

        // Initializes the adjustment class.
        // When `hasReset` is set to true, a reset command is automatically created for this adjustment.
        public LayerCurrentAdjustment()
            : base(displayName: LayerToolsConstants.SelectCurrent.Name, description: "Adjust current layer selection", groupName: ActionGroups.Layers, hasReset: true)
        {
        }

        protected override BitmapImage GetAdjustmentImage(string actionParameter, PluginImageSize imageSize)
        {
            return PluginResources.BitmapFromEmbaddedRessource(LayerToolsConstants.SelectCurrent.BitMapImageName);
        }

        // This method is called when the adjustment is executed.
        protected override void ApplyAdjustment(String actionParameter, Int32 diff)
        {
            AdjustCurrentLayer(Client, diff);
        }

        public static void AdjustCurrentLayer(Client client, int diff)
        {
            if (client == null) return;

            if (diff > 0)
            {
                client.KritaInstance.ExecuteAction(ActionsNames.ActivatePreviousLayer).Wait();
            }
            else
            {
                client.KritaInstance.ExecuteAction(ActionsNames.ActivateNextLayer).Wait();
            }
            //this.AdjustmentValueChanged(); // Notify the plugin service that the adjustment value has changed.
        }

        // This method is called when the reset command related to the adjustment is executed.
        protected override void RunCommand(String actionParameter)
        {
            if (Client == null) return;

            Client.KritaInstance.ExecuteAction(ActionsNames.Isolate_active_layer).Wait();
        }
    }
}
