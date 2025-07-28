using Loupedeck;
using LogiKritaApiClient.ClientBase;
using Logi.KritaPlugin.Constants;

namespace Logi.KritaPlugin.Actions
{
    // This class implements an example adjustment that counts the rotation ticks of a dial.

    public class ViewBrushFadeAdjustment : PluginDynamicAdjustment
    {
        private Client Client => ((KritaApplication)Plugin.ClientApplication).Client;
        private static float Opacity = 1;
        private static DateTime LastAdjust = DateTime.MinValue;

        // Initializes the adjustment class.
        // When `hasReset` is set to true, a reset command is automatically created for this adjustment.
        public ViewBrushFadeAdjustment()
            : base(displayName: ViewToolsConstants.BrushFade.Name, description: "Adjust brush fade", groupName: ActionGroups.View, hasReset: false)
        {
        }

        protected override BitmapImage GetAdjustmentImage(string actionParameter, PluginImageSize imageSize)
        {
            return PluginResources.BitmapFromEmbaddedRessource(ViewToolsConstants.BrushFade.BitMapImageName);
        }


        // This method is called when the adjustment is executed.
        protected override void ApplyAdjustment(String actionParameter, Int32 diff)
        {
            AdjustBrushFade(Client, diff);
        }

        public static void AdjustBrushFade(Client client, int diff)
        {
            if (client == null) return;

            if (diff > 0)
            {
                client.KritaInstance.ExecuteAction(ActionsNames.Increase_fade).Wait();
            }
            else
            {
                client.KritaInstance.ExecuteAction(ActionsNames.Decrease_fade).Wait();
            }
        }
    }
}
