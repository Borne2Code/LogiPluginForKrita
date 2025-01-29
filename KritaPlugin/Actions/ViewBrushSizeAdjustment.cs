namespace Loupedeck.KritaPlugin
{
    // This class implements an example adjustment that counts the rotation ticks of a dial.

    public class ViewBrushSizeAdjustment : PluginDynamicAdjustment
    {
        private KritaPlugin KritaPlugin => (KritaPlugin)Plugin;

        // This variable holds the current value of the counter.
        private Int32 _counter = 0;

        // Initializes the adjustment class.
        // When `hasReset` is set to true, a reset command is automatically created for this adjustment.
        public ViewBrushSizeAdjustment()
            : base(displayName: "Brush size", description: "Adjust brush size", groupName: ActionGroups.BrushAdjustements, hasReset: false)
        {
        }

        protected override BitmapImage GetAdjustmentImage(string actionParameter, PluginImageSize imageSize)
        {
            return EmbeddedResources.ReadImage(EmbeddedResources.FindFile("BrushSize.png"));
        }

        // This method is called when the adjustment is executed.
        protected override void ApplyAdjustment(String actionParameter, Int32 diff)
        {
            var brushSize = KritaPlugin.Client.CurrentView.BrushSize().Result;
            var delta = Math.Max(brushSize * (float)Math.Abs(diff) / 20, 0.01) * Math.Sign(diff);
            brushSize = (float)Math.Round(brushSize + delta, 2);
            brushSize = (float)Math.Min(Math.Max(brushSize, 0.01), 3000);
            KritaPlugin.Client.CurrentView.SetBrushSize(brushSize).Wait();
            this.AdjustmentValueChanged(); // Notify the plugin service that the adjustment value has changed.
        }

        // This method is called when the reset command related to the adjustment is executed.
        protected override void RunCommand(String actionParameter)
        {
        }

        // Returns the adjustment value that is shown next to the dial.
        protected override String GetAdjustmentValue(String actionParameter)
        {
            return Math.Round(KritaPlugin.Client.CurrentView.BrushSize().Result, 2).ToString();
        }
    }
}
