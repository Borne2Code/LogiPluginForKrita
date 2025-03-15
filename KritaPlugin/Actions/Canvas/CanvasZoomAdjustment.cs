using System.Reflection;
using LoupedeckKritaApiClient.ClientBase;

namespace Loupedeck.KritaPlugin
{
    // This class implements an example adjustment that counts the rotation ticks of a dial.

    public class CanvasZoomAdjustment : PluginDynamicAdjustment
    {
        private Client Client => ((KritaApplication)Plugin.ClientApplication).Client;
        private float Zoom = 1;
        private DateTime LastAdjust = DateTime.MinValue;

        // Initializes the adjustment class.
        // When `hasReset` is set to true, a reset command is automatically created for this adjustment.
        public CanvasZoomAdjustment()
            : base(displayName: "Canvas zoom", description: "Adjust canvas zoom", groupName: ActionGroups.CanvasAdjustements, hasReset: true)
        {
        }

        protected override BitmapImage GetAdjustmentImage(string actionParameter, PluginImageSize imageSize)
        {
            return BitmapImage.FromResource(Assembly.GetExecutingAssembly(), "Loupedeck.KritaPlugin.images.Canvas.Zoom.png");
        }

        // This method is called when the adjustment is executed.
        protected override void ApplyAdjustment(String actionParameter, Int32 diff)
        {
            UpdateAdjustValueIfNecessary();
            Zoom = Zoom + (float)diff * Zoom / 100;
            Client.CurrentCanvas.SetZoomLevel(Zoom).Wait();
            this.AdjustmentValueChanged();
        }

        // This method is called when the reset command related to the adjustment is executed.
        protected override void RunCommand(String actionParameter)
        {
            Client.CurrentCanvas.ResetZoom().Wait();
            Zoom = 1;
            this.AdjustmentValueChanged(); // Notify the plugin service that the adjustment value has changed.
        }

        // Returns the adjustment value that is shown next to the dial.
        protected override String GetAdjustmentValue(String actionParameter)
        {
            UpdateAdjustValueIfNecessary();
            return Math.Round(Zoom * 100, Zoom >= 1000 ? 0 : 1).ToString() + " %";
        }

        private void UpdateAdjustValueIfNecessary()
        {
            if ((DateTime.Now - LastAdjust).TotalMilliseconds > 500)
            {
                Zoom = Client.CurrentCanvas.ZoomLevel().Result * 72 / Client.CurrentDocument.GetResolution().Result;
                LastAdjust = DateTime.Now;
            }
        }
    }
}
