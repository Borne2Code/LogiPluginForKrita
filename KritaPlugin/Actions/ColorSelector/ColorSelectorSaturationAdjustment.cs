using Loupedeck;
using LogiKritaApiClient.ClientBase;
using Logi.KritaPlugin.Constants;

namespace Logi.KritaPlugin.Actions
{
    // This class implements an example adjustment that counts the rotation ticks of a dial.

    public class ColorSelectorSaturationAdjustment : PluginDynamicAdjustment
    {
        private Client Client => ((KritaApplication)Plugin.ClientApplication).Client;

        // Initializes the adjustment class.
        // When `hasReset` is set to true, a reset command is automatically created for this adjustment.
        public ColorSelectorSaturationAdjustment()
            : base(displayName: ColorSelectorToolsConstants.Saturation.Name, description: "Adjust color saturation", groupName: ActionGroups.ColorSelector, hasReset: false)
        {
        }

        protected override BitmapImage GetAdjustmentImage(string actionParameter, PluginImageSize imageSize)
        {
            return PluginResources.BitmapFromEmbaddedRessource(ColorSelectorToolsConstants.Saturation.BitMapImageName);
        }

        // This method is called when the adjustment is executed.
        protected override void ApplyAdjustment(String actionParameter, Int32 diff)
        {
            AdjustSaturation(Client, diff);
        }

        public static void AdjustSaturation(Client client, int diff)
        {
            if (client == null) return;

            if (diff > 0)
            {
                client.KritaInstance.ExecuteAction(ActionsNames.Wgcs_increase_saturation).Wait();
            }
            else
            {
                client.KritaInstance.ExecuteAction(ActionsNames.Wgcs_decrease_saturation).Wait();
            }
        }
    }
}