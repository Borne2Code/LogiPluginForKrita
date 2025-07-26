using Loupedeck;
using LogiKritaApiClient.ClientBase;
using Logi.KritaPlugin.Constants;

namespace Logi.KritaPlugin.Actions
{
    // This class implements an example adjustment that counts the rotation ticks of a dial.

    public class AnimationHoldColumnsAdjustment : PluginDynamicAdjustment
    {
        private Client Client => ((KritaApplication)Plugin.ClientApplication).Client;

        // Initializes the adjustment class.
        // When `hasReset` is set to true, a reset command is automatically created for this adjustment.
        public AnimationHoldColumnsAdjustment()
            : base(displayName: AnimationToolsConstants.HoldColumns.Name, description: "Add/Remove Hold columns", groupName: ActionGroups.Animation, hasReset: false)
        {
        }

        protected override BitmapImage GetAdjustmentImage(string actionParameter, PluginImageSize imageSize)
        {
            return PluginResources.BitmapFromEmbaddedRessource(AnimationToolsConstants.HoldColumns.BitMapImageName);
        }

        // This method is called when the adjustment is executed.
        protected override void ApplyAdjustment(String actionParameter, Int32 diff)
        {
            AddRemoveHoldColumn(Client, diff);
        }

        public static void AddRemoveHoldColumn(Client client, int diff)
        {
            if (client == null) return;

            if (diff > 0)
            {
                client.KritaInstance.ExecuteAction(ActionsNames.Insert_hold_column).Wait();
            }
            else
            {
                client.KritaInstance.ExecuteAction(ActionsNames.Remove_hold_column).Wait();
            }
        }
    }
}
