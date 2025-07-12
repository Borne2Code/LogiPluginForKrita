using Loupedeck;
using LogiKritaApiClient.ClientBase;
using Logi.KritaPlugin.Constants;

namespace Logi.KritaPlugin.Actions
{
    // This class implements an example adjustment that counts the rotation ticks of a dial.

    public class ColorSelectorRedGreenAdjustment : PluginDynamicAdjustment
    {
        private Client Client => ((KritaApplication)Plugin.ClientApplication).Client;

        // Initializes the adjustment class.
        // When `hasReset` is set to true, a reset command is automatically created for this adjustment.
        public ColorSelectorRedGreenAdjustment()
            : base(displayName: ColorSelectorToolsConstants.RedGreen.Name, description: "Adjust color Red/Green", groupName: ActionGroups.ColorSelector, false)
        {
        }

        protected override BitmapImage GetAdjustmentImage(string actionParameter, PluginImageSize imageSize)
        {
            return PluginResources.BitmapFromEmbaddedRessource(ColorSelectorToolsConstants.RedGreen.BitMapImageName);
        }

        // This method is called when the adjustment is executed.
        protected override void ApplyAdjustment(String actionParameter, Int32 diff)
        {
            AdjustRedGreen(Client, diff);
        }

        public static void AdjustRedGreen(Client client, int diff)
        {
            if (client == null) return;

            if (diff > 0)
            {
                client.KritaInstance.ExecuteAction(ActionsNames.Make_brush_color_greener).Wait();
            }
            else
            {
                client.KritaInstance.ExecuteAction(ActionsNames.Make_brush_color_redder).Wait();
            }
        }
    }
}