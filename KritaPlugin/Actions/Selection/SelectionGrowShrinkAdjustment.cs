using Loupedeck;
using LogiKritaApiClient.ClientBase;
using Logi.KritaPlugin.Constants;

namespace Logi.KritaPlugin.Actions
{
    // This class implements an example adjustment that counts the rotation ticks of a dial.

    public class SelectionGrowShrinkAdjustment : PluginDynamicAdjustment
    {
        private Client Client => ((KritaApplication)Plugin.ClientApplication).Client;

        // Initializes the adjustment class.
        // When `hasReset` is set to true, a reset command is automatically created for this adjustment.
        public SelectionGrowShrinkAdjustment()
            : base(displayName: SelectionToolsConstants.GrowShrink.Name, description: "Adjust selection grow/shrink", groupName: ActionGroups.Selection, hasReset: false)
        {
        }

        protected override BitmapImage GetAdjustmentImage(string actionParameter, PluginImageSize imageSize)
        {
            return PluginResources.BitmapFromEmbaddedRessource(SelectionToolsConstants.GrowShrink.BitMapImageName);
        }

        // This method is called when the adjustment is executed.
        protected override void ApplyAdjustment(String actionParameter, Int32 diff)
        {
            if (Client == null) return;

            AdjustSelectionSize(Client, diff);
        }

        internal static void AdjustSelectionSize(Client client, int diff)
        {
            if (diff > 0)
            {
                var selection = client.CurrentSelection;
                {
                    if (selection != null)
                    {
                        selection.Grow(diff).Wait();
                        var action = client.KritaInstance.Action(ActionsNames.Invert_selection).Result;
                        action.Trigger();
                        action.Trigger();
                        action.DisposeAsync().AsTask().Wait();
                    }
                }
                selection.DisposeAsync().AsTask().Wait();
            }
            else if (diff < 0)
            {
                var selection = client.CurrentSelection;
                if (selection != null)
                {
                    if (selection != null)
                    {
                        selection.Shrink(-diff).Wait();
                        var action = client.KritaInstance.Action(ActionsNames.Invert_selection).Result;
                        action.Trigger();
                        action.Trigger();
                        action.DisposeAsync().AsTask().Wait();
                    }
                }
            }
        }
    }
}
