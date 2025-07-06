using Loupedeck;
using LogiKritaApiClient.ClientBase;

namespace Logi.KritaPlugin.Actions
{
    // This class implements an example adjustment that counts the rotation ticks of a dial.

    public class SelectionGrowShrinkAdjustment : PluginDynamicAdjustment
    {
        private Client Client => ((KritaApplication)Plugin.ClientApplication).Client;

        // Initializes the adjustment class.
        // When `hasReset` is set to true, a reset command is automatically created for this adjustment.
        public SelectionGrowShrinkAdjustment()
            : base(displayName: "Selection Grow/Shrink", description: "Adjust selection grow/shrink", groupName: ActionGroups.Selection, hasReset: false)
        {
        }

        protected override BitmapImage GetAdjustmentImage(string actionParameter, PluginImageSize imageSize)
        {
            return PluginResources.BitmapFromEmbaddedRessource("Logi.KritaPlugin.images.Selection.GrowShrink.png");
        }

        // This method is called when the adjustment is executed.
        protected override void ApplyAdjustment(String actionParameter, Int32 diff)
        {
            if (Client == null) return;

            if (diff > 0)
            {
                var selection = Client.CurrentSelection;
                {
                    if (selection != null)
                    {
                        selection.Grow(diff).Wait();
                        var action = Client.KritaInstance.Action(ActionsNames.Invert_selection).Result;
                        action.Trigger();
                        action.Trigger();
                        action.DisposeAsync().AsTask().Wait();
                    }
                }
                selection.DisposeAsync().AsTask().Wait();
            }
            else if (diff < 0)
            {
                var selection = Client.CurrentSelection;
                if (selection != null)
                {
                    if (selection != null)
                    {
                        selection.Shrink(-diff).Wait();
                        var action = Client.KritaInstance.Action(ActionsNames.Invert_selection).Result;
                        action.Trigger();
                        action.Trigger();
                        action.DisposeAsync().AsTask().Wait();
                    }
                }
            }
        }
    }
}
