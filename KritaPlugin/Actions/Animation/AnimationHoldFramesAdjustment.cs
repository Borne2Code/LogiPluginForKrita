using Loupedeck;
using LogiKritaApiClient.ClientBase;
using Logi.KritaPlugin.Constants;

namespace Logi.KritaPlugin.Actions
{
    // This class implements an example adjustment that counts the rotation ticks of a dial.

    public class AnimationHoldFramesAdjustment : PluginDynamicAdjustment
    {
        private Client Client => ((KritaApplication)Plugin.ClientApplication).Client;

        // Initializes the adjustment class.
        // When `hasReset` is set to true, a reset command is automatically created for this adjustment.
        public AnimationHoldFramesAdjustment()
            : base(displayName: AnimationToolsConstants.HoldFrames.Name, description: "Add/Remove Hold frames", groupName: ActionGroups.Animation, hasReset: false)
        {
        }

        protected override BitmapImage GetAdjustmentImage(string actionParameter, PluginImageSize imageSize)
        {
            return PluginResources.BitmapFromEmbaddedRessource(AnimationToolsConstants.HoldFrames.BitMapImageName);
        }

        // This method is called when the adjustment is executed.
        protected override void ApplyAdjustment(String actionParameter, Int32 diff)
        {
            AddRemoveHoldFrame(Client, diff);
        }

        public static void AddRemoveHoldFrame(Client client, int diff)
        {
            if (client == null) return;

            if (diff > 0)
            {
                client.KritaInstance.ExecuteAction(ActionsNames.Insert_hold_frame).Wait();
            }
            else
            {
                client.KritaInstance.ExecuteAction(ActionsNames.Remove_hold_frame).Wait();
            }
        }
    }
}
