using Loupedeck.KritaPlugin.Actions;

namespace Loupedeck.KritaPlugin
{
    // This class implements an example adjustment that counts the rotation ticks of a dial.

    public class CanvasZoomAdjustment : PluginDynamicAdjustment
    {
        private KritaPlugin KritaPlugin => (KritaPlugin)Plugin;

        // This variable holds the current value of the counter.
        private Int32 _counter = 0;

        // Initializes the adjustment class.
        // When `hasReset` is set to true, a reset command is automatically created for this adjustment.
        public CanvasZoomAdjustment()
            : base(displayName: "Canvas zoom", description: "Adjust canvas zoom", groupName: ActionGroups.CanvasAdjustements, hasReset: true)
        {
        }

        // This method is called when the adjustment is executed.
        protected override void ApplyAdjustment(String actionParameter, Int32 diff)
        {
            var zoom = KritaPlugin.Client.CurrentCanvas.ZoomLevel().Result;
            KritaPlugin.Client.CurrentCanvas.SetZoomLevel(zoom + (float)diff * zoom / 100).Wait();
            this.AdjustmentValueChanged(); // Notify the plugin service that the adjustment value has changed.
        }

        // This method is called when the reset command related to the adjustment is executed.
        protected override void RunCommand(String actionParameter)
        {
            KritaPlugin.Client.CurrentCanvas.ResetZoom().Wait();
            this.AdjustmentValueChanged(); // Notify the plugin service that the adjustment value has changed.
        }

        // Returns the adjustment value that is shown next to the dial.
        protected override String GetAdjustmentValue(String actionParameter)
        {
            return Math.Round(KritaPlugin.Client.CurrentCanvas.ZoomLevel().Result * 100, 1).ToString();
        }
    }
}
