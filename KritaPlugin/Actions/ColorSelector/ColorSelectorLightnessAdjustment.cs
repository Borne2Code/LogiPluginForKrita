using Loupedeck;
using LogiKritaApiClient.ClientBase;
using Logi.KritaPlugin.Constants;

namespace Logi.KritaPlugin.Actions
{
    // This class implements an example adjustment that counts the rotation ticks of a dial.

    public class ColorSelectorLightnessAdjustment : PluginDynamicAdjustment
    {
        private Client Client => ((KritaApplication)Plugin.ClientApplication).Client;

        // Initializes the adjustment class.
        // When `hasReset` is set to true, a reset command is automatically created for this adjustment.
        public ColorSelectorLightnessAdjustment()
            : base(displayName: ColorSelectorToolsConstants.Lightness.Name, description: "Adjust color lightness", groupName: ActionGroups.ColorSelector, false)
        {
        }

        protected override BitmapImage GetAdjustmentImage(string actionParameter, PluginImageSize imageSize)
        {
            return PluginResources.BitmapFromEmbaddedRessource(ColorSelectorToolsConstants.Lightness.BitMapImageName);
        }

        // This method is called when the adjustment is executed.
        protected override void ApplyAdjustment(String actionParameter, Int32 diff)
        {
            AdjustLightness(Client, diff);
        }

        public static void AdjustLightness(Client client, int diff)
        {
            if (client == null) return;

            if (diff > 0)
            {
                client.KritaInstance.ExecuteAction(ActionsNames.Wgcs_lighten_color).Wait();
            }
            else
            {
                client.KritaInstance.ExecuteAction(ActionsNames.Wgcs_darken_color).Wait();
            }
        }
    }
}
