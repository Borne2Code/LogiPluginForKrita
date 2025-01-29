namespace Loupedeck.KritaPlugin
{
    // This class implements an example adjustment that counts the rotation ticks of a dial.

    public class ViewOpacityAdjustment : PluginDynamicAdjustment
    {
        private KritaPlugin KritaPlugin => (KritaPlugin)Plugin;

        // This variable holds the current value of the counter.
        private Int32 _counter = 0;

        // Initializes the adjustment class.
        // When `hasReset` is set to true, a reset command is automatically created for this adjustment.
        public ViewOpacityAdjustment()
            : base(displayName: "Brush opacity", description: "Adjust brush opacity", groupName: ActionGroups.BrushAdjustements, hasReset: false)
        {
        }

        protected override BitmapImage GetAdjustmentImage(string actionParameter, PluginImageSize imageSize)
        {
            return EmbeddedResources.ReadImage(EmbeddedResources.FindFile("BrushOpacity.png"));
        }


        // This method is called when the adjustment is executed.
        protected override void ApplyAdjustment(String actionParameter, Int32 diff)
        {
            var opacity = KritaPlugin.Client.CurrentView.PaintingOpacity().Result;
            opacity = (float)Math.Min(Math.Max(opacity + (float)diff / 100, 0), 1);
            KritaPlugin.Client.CurrentView.SetPaintingOpacity(opacity).Wait();
            this.AdjustmentValueChanged(); // Notify the plugin service that the adjustment value has changed.
        }

        // This method is called when the reset command related to the adjustment is executed.
        protected override void RunCommand(String actionParameter)
        {
        }

        // Returns the adjustment value that is shown next to the dial.
        protected override String GetAdjustmentValue(String actionParameter)
        {
            return Math.Round(KritaPlugin.Client.CurrentView.PaintingOpacity().Result, 2).ToString();
        }
    }
}
