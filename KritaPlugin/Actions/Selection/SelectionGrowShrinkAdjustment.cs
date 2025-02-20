using LoupedeckKritaApiClient.ClientBase;

namespace Loupedeck.KritaPlugin
{
    // This class implements an example adjustment that counts the rotation ticks of a dial.

    public class SelectionGrowShrinkAdjustment : PluginDynamicAdjustment
    {
        private KritaPlugin KritaPlugin => (KritaPlugin)Plugin;
        //private Timer? _timer;

        // Initializes the adjustment class.
        // When `hasReset` is set to true, a reset command is automatically created for this adjustment.
        public SelectionGrowShrinkAdjustment()
            : base(displayName: "Selection Grow/Shrink", description: "Adjust selection grow/shrink", groupName: ActionGroups.Selection, hasReset: false)
        {
        }

        protected override BitmapImage GetAdjustmentImage(string actionParameter, PluginImageSize imageSize)
        {
            return EmbeddedResources.ReadImage(EmbeddedResources.FindFile("SelectionGrowShrink.png"));
        }

        // This method is called when the adjustment is executed.
        protected override void ApplyAdjustment(String actionParameter, Int32 diff)
        {
            if (diff > 0)
            {
                var selection = KritaPlugin.Client.CurrentSelection;
                {
                    if (selection != null)
                    {
                        selection.Grow(diff).Wait();
                        var action = KritaPlugin.Client.KritaInstance.Action(ActionsNames.Invert_selection).Result;
                        action.Trigger();
                        action.Trigger();
                        action.DisposeAsync().AsTask().Wait();
                    }
                }
                selection.DisposeAsync().AsTask().Wait();
            }
            else if (diff < 0)
            {
                var selection = KritaPlugin.Client.CurrentSelection;
                if (selection != null)
                {
                    if (selection != null)
                    {
                        selection.Shrink(-diff).Wait();
                        var action = KritaPlugin.Client.KritaInstance.Action(ActionsNames.Invert_selection).Result;
                        action.Trigger();
                        action.Trigger();
                        action.DisposeAsync().AsTask().Wait();
                    }
                }
            }
        }
    }
}
