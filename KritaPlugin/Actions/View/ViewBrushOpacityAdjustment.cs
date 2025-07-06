using Loupedeck;
using LogiKritaApiClient.ClientBase;

namespace Logi.KritaPlugin.Actions
{
    // This class implements an example adjustment that counts the rotation ticks of a dial.

    public class ViewBrushOpacityAdjustment : PluginDynamicAdjustment
    {
        private Client Client => ((KritaApplication)Plugin.ClientApplication).Client;
        private float Opacity = 1;
        private DateTime LastAdjust = DateTime.MinValue;

        // Initializes the adjustment class.
        // When `hasReset` is set to true, a reset command is automatically created for this adjustment.
        public ViewBrushOpacityAdjustment()
            : base(displayName: "Brush opacity", description: "Adjust brush opacity", groupName: ActionGroups.ViewAdjustements, hasReset: true)
        {
        }

        protected override BitmapImage GetAdjustmentImage(string actionParameter, PluginImageSize imageSize)
        {
            return PluginResources.BitmapFromEmbaddedRessource("Logi.KritaPlugin.images.View.BrushOpacity.png");
        }


        // This method is called when the adjustment is executed.
        protected override void ApplyAdjustment(String actionParameter, Int32 diff)
        {
            if (Client == null) return;

            UpdateAdjustValueIfNecessary();
            var newOpacity = (float)Math.Min(Math.Max(Opacity + (float)diff / 100, 0), 1);

            if (newOpacity != Opacity)
            {
                Opacity = newOpacity;
                Client.CurrentView.SetPaintingOpacity(Opacity).Wait();
                this.AdjustmentValueChanged(); // Notify the plugin service that the adjustment value has changed.
            }
        }

        // This method is called when the reset command related to the adjustment is executed.
        protected override void RunCommand(String actionParameter)
        {
            if (Client == null) return;

            Client.CurrentView.SetPaintingOpacity(1).Wait();
            Opacity = 1;
            this.AdjustmentValueChanged(); // Notify the plugin service that the adjustment value has changed.
        }

        // Returns the adjustment value that is shown next to the dial.
        protected override String GetAdjustmentValue(String actionParameter)
        {
            if (Client == null) return "-";

            UpdateAdjustValueIfNecessary();
            return Math.Round(Opacity * 100).ToString() + " %";
        }

        private void UpdateAdjustValueIfNecessary()
        {
            if ((DateTime.Now - LastAdjust).TotalMilliseconds > 500)
            {
                Opacity = Client.CurrentView.PaintingOpacity().Result;
                LastAdjust = DateTime.Now;
            }
        }
    }
}
