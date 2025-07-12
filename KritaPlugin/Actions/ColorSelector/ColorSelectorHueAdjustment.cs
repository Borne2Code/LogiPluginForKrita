using Loupedeck;
using LogiKritaApiClient.ClientBase;
using Logi.KritaPlugin.Constants;

namespace Logi.KritaPlugin.Actions
{
    // This class implements an example adjustment that counts the rotation ticks of a dial.

    public class ColorSelectorHueAdjustment : PluginDynamicAdjustment
    {
        private Client Client => ((KritaApplication)Plugin.ClientApplication).Client;

        // Initializes the adjustment class.
        // When `hasReset` is set to true, a reset command is automatically created for this adjustment.
        public ColorSelectorHueAdjustment()
            : base(displayName: ColorSelectorToolsConstants.Hue.Name, description: "Adjust color hue", groupName: ActionGroups.ColorSelector, false)
        {
        }

        protected override BitmapImage GetAdjustmentImage(string actionParameter, PluginImageSize imageSize)
        {
            return PluginResources.BitmapFromEmbaddedRessource(ColorSelectorToolsConstants.Saturation.BitMapImageName);
        }

        // This method is called when the adjustment is executed.
        protected override void ApplyAdjustment(String actionParameter, Int32 diff)
        {
            AdjustHue(Client, diff);
        }

        public static void AdjustHue(Client client, int diff)
        {
            if (client == null) return;

            if (diff > 0)
            {
                client.KritaInstance.ExecuteAction(ActionsNames.Shift_brush_color_clockwise).Wait();
            }
            else
            {
                client.KritaInstance.ExecuteAction(ActionsNames.Shift_brush_color_counter_clockwise).Wait();
            }
        }
    }
}