using Loupedeck;
using LogiKritaApiClient.ClientBase;
using Logi.KritaPlugin.Constants;

namespace Logi.KritaPlugin.Actions
{
    // This class implements an example adjustment that counts the rotation ticks of a dial.

    public class AnimationKeyframeAdjustment : PluginDynamicAdjustment
    {
        private Client Client => ((KritaApplication)Plugin.ClientApplication).Client;

        // Initializes the adjustment class.
        // When `hasReset` is set to true, a reset command is automatically created for this adjustment.
        public AnimationKeyframeAdjustment()
            : base(displayName: AnimationToolsConstants.KeyFrame.Name, description: "Prev/Next Keyframe", groupName: ActionGroups.Animation, hasReset: false)
        {
        }

        protected override BitmapImage GetAdjustmentImage(string actionParameter, PluginImageSize imageSize)
        {
            return PluginResources.BitmapFromEmbaddedRessource(AnimationToolsConstants.KeyFrame.BitMapImageName);
        }

        // This method is called when the adjustment is executed.
        protected override void ApplyAdjustment(String actionParameter, Int32 diff)
        {
            AdjustKeyframe(Client, diff);
        }

        public static void AdjustKeyframe(Client client, int diff)
        {
            if (client == null) return;

            if (diff > 0)
            {
                client.KritaInstance.ExecuteAction(ActionsNames.Next_keyframe).Wait();
            }
            else
            {
                client.KritaInstance.ExecuteAction(ActionsNames.Previous_keyframe).Wait();
            }
        }
    }
}
