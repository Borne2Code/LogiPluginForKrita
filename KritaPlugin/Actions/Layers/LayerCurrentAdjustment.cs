using System.Reflection;
using LoupedeckKritaApiClient.ClientBase;

namespace Loupedeck.KritaPlugin
{
    // This class implements an example adjustment that counts the rotation ticks of a dial.

    public class LayerCurrentAdjustment : PluginDynamicAdjustment
    {
        private Client Client => ((KritaApplication)Plugin.ClientApplication).Client;

        // Initializes the adjustment class.
        // When `hasReset` is set to true, a reset command is automatically created for this adjustment.
        public LayerCurrentAdjustment()
            : base(displayName: "Current Layer Selector", description: "Adjust current layer selection", groupName: ActionGroups.Layers, hasReset: true)
        {
        }

        protected override BitmapImage GetAdjustmentImage(string actionParameter, PluginImageSize imageSize)
        {
            return BitmapImage.FromResource(Assembly.GetExecutingAssembly(), "Loupedeck.KritaPlugin.images.Layers.CurrentAdjust.png");
        }

        // This method is called when the adjustment is executed.
        protected override void ApplyAdjustment(String actionParameter, Int32 diff)
        {
            if (diff > 0)
            {
                Client.KritaInstance.ExecuteAction(ActionsNames.ActivatePreviousLayer).Wait();
            }
            else
            {
                Client.KritaInstance.ExecuteAction(ActionsNames.ActivateNextLayer).Wait();
            }
            //this.AdjustmentValueChanged(); // Notify the plugin service that the adjustment value has changed.
        }

        // This method is called when the reset command related to the adjustment is executed.
        protected override void RunCommand(String actionParameter)
        {
            Client.KritaInstance.ExecuteAction(ActionsNames.Isolate_active_layer).Wait();
        }

        // Returns the adjustment value that is shown next to the dial.
        protected override String GetAdjustmentValue(String actionParameter)
        {
            return string.Empty;
        }
    }
}
