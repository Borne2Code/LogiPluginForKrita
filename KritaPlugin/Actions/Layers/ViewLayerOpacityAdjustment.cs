using LoupedeckKritaApiClient.ClientBase;

namespace Loupedeck.KritaPlugin
{
    // This class implements an example adjustment that counts the rotation ticks of a dial.

    public class ViewLayerOpacityAdjustment : PluginDynamicAdjustment
    {
        private KritaPlugin KritaPlugin => (KritaPlugin)Plugin;
        private Timer? _timer;

        // Initializes the adjustment class.
        // When `hasReset` is set to true, a reset command is automatically created for this adjustment.
        public ViewLayerOpacityAdjustment()
            : base(displayName: "Layer Opacity", description: "Adjust current layer's opacity", groupName: ActionGroups.Layers, hasReset: true)
        {
        }

        protected override BitmapImage GetAdjustmentImage(string actionParameter, PluginImageSize imageSize)
        {
            return EmbeddedResources.ReadImage(EmbeddedResources.FindFile("LayerOpacity.png"));
        }

        // This method is called when the adjustment is executed.
        protected override void ApplyAdjustment(String actionParameter, Int32 diff)
        {
            var opacity = KritaPlugin.Client.CurrentNode.Opacity().Result;
            var newOpacity = Math.Min(Math.Max(opacity + diff, 0), 255);

            if (newOpacity != opacity)
            {
                KritaPlugin.Client.CurrentNode.SetOpacity(newOpacity).Wait();
                if (_timer != null)
                {
                    _timer.Dispose();
                    _timer = null;
                }
                _timer = new Timer((_) => KritaPlugin.Client.CurrentDocument.RefreshProjection(), null, 500, Timeout.Infinite);

                AdjustmentValueChanged(); // Notify the plugin service that the adjustment value has changed.
            }
        }

        // This method is called when the reset command related to the adjustment is executed.
        protected override void RunCommand(String actionParameter)
        {
            KritaPlugin.Client.CurrentNode.SetOpacity(255).Wait();
            KritaPlugin.Client.CurrentDocument.RefreshProjection();
            AdjustmentValueChanged(); // Notify the plugin service that the adjustment value has changed.
        }

        // Returns the adjustment value that is shown next to the dial.
        protected override String GetAdjustmentValue(String actionParameter)
        {
            return (KritaPlugin.Client.CurrentNode.Opacity().Result * 100 / 255).ToString() + " %";
        }
    }
}
