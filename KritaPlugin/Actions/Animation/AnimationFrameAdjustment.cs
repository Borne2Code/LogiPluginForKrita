using Loupedeck;
using LogiKritaApiClient.ClientBase;
using Logi.KritaPlugin.Constants;

namespace Logi.KritaPlugin.Actions
{
    // This class implements an example adjustment that counts the rotation ticks of a dial.

    public class AnimationFrameAdjustment : PluginDynamicAdjustment
    {
        private Client Client => ((KritaApplication)Plugin.ClientApplication).Client;

        // Initializes the adjustment class.
        // When `hasReset` is set to true, a reset command is automatically created for this adjustment.
        public AnimationFrameAdjustment()
            : base(displayName: AnimationToolsConstants.Frame.Name, description: "Prev/Next Frame", groupName: ActionGroups.Animation, hasReset: false)
        {
        }

        protected override BitmapImage GetAdjustmentImage(string actionParameter, PluginImageSize imageSize)
        {
            return PluginResources.BitmapFromEmbaddedRessource(AnimationToolsConstants.Frame.BitMapImageName);
        }

        // This method is called when the adjustment is executed.
        protected override void ApplyAdjustment(String actionParameter, Int32 diff)
        {
            AdjustFrame(Client, diff);
        }

        public static void AdjustFrame(Client client, int diff)
        {
            if (client == null) return;

            if (diff > 0)
            {
                client.KritaInstance.ExecuteAction(ActionsNames.Next_frame).Wait();
            }
            else
            {
                client.KritaInstance.ExecuteAction(ActionsNames.Previous_frame).Wait();
            }
        }
    }
}
