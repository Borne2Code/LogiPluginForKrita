using System.Reflection;
using LoupedeckKritaApiClient.ClientBase;

namespace Loupedeck.KritaPlugin
{
    // This class implements an example adjustment that counts the rotation ticks of a dial.

    public class LayerOpacityAdjustment : PluginDynamicAdjustment
    {
        private Client Client => ((KritaApplication)Plugin.ClientApplication).Client;
        private int Opacity = 255;
        private DateTime LastAdjust = DateTime.MinValue;
        private Timer? _timer;

        // Initializes the adjustment class.
        // When `hasReset` is set to true, a reset command is automatically created for this adjustment.
        public LayerOpacityAdjustment()
            : base(displayName: "Layer Opacity", description: "Adjust current layer's opacity", groupName: ActionGroups.Layers, hasReset: true)
        {
        }

        protected override BitmapImage GetAdjustmentImage(string actionParameter, PluginImageSize imageSize)
        {
            return PluginResources.BitmapFromEmbaddedRessource("Loupedeck.KritaPlugin.images.Layers.Opacity.png");
        }

        // This method is called when the adjustment is executed.
        protected override void ApplyAdjustment(String actionParameter, Int32 diff)
        {
            if (Client == null) return;

            UpdateAdjustValueIfNecessary();

            var newOpacity = Math.Min(Math.Max(Opacity + diff, 0), 255);

            if (newOpacity != Opacity)
            {
                Opacity = newOpacity;
                Client.CurrentNode.SetOpacity(Opacity).Wait();
                if (_timer != null)
                {
                    _timer.Dispose();
                    _timer = null;
                }
                _timer = new Timer((_) => Client.CurrentDocument.RefreshProjection(), null, 500, Timeout.Infinite);

                AdjustmentValueChanged(); // Notify the plugin service that the adjustment value has changed.
            }
        }

        // This method is called when the reset command related to the adjustment is executed.
        protected override void RunCommand(String actionParameter)
        {
            if (Client == null) return;

            Opacity = 255;
            Client.CurrentNode.SetOpacity(Opacity).Wait();
            Client.CurrentDocument.RefreshProjection();
            AdjustmentValueChanged(); // Notify the plugin service that the adjustment value has changed.
        }

        // Returns the adjustment value that is shown next to the dial.
        protected override String GetAdjustmentValue(String actionParameter)
        {
            if (Client == null) return "-";

            UpdateAdjustValueIfNecessary();
            return (Opacity * 100 / 255).ToString() + " %";
        }

        private void UpdateAdjustValueIfNecessary()
        {
            if ((DateTime.Now - LastAdjust).TotalMilliseconds > 500)
            {
                Opacity = Client.CurrentNode.Opacity().Result;
                LastAdjust = DateTime.Now;
            }
        }
    }
}
