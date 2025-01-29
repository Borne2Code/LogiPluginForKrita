namespace Loupedeck.KritaPlugin
{
    // This class implements an example adjustment that counts the rotation ticks of a dial.

    public class ViewBrushPatternSizeAdjustment : PluginDynamicAdjustment
    {
        private KritaPlugin KritaPlugin => (KritaPlugin)Plugin;

        // Initializes the adjustment class.
        // When `hasReset` is set to true, a reset command is automatically created for this adjustment.
        public ViewBrushPatternSizeAdjustment()
            : base(displayName: "Brush pattern size", description: "Adjust brush pattern size", groupName: ActionGroups.BrushAdjustements, hasReset: true)
        {
        }

        protected override BitmapImage GetAdjustmentImage(string actionParameter, PluginImageSize imageSize)
        {
            return EmbeddedResources.ReadImage(EmbeddedResources.FindFile("BrushPatternSize.png"));
        }

        // This method is called when the adjustment is executed.
        protected override void ApplyAdjustment(String actionParameter, Int32 diff)
        {
            var brushPatternSize = KritaPlugin.Client.CurrentView.PatternSize().Result;
            brushPatternSize = (float)Math.Round(brushPatternSize + diff / 100, 2);
            brushPatternSize = (float)Math.Min(Math.Max(brushPatternSize, 0.01), 20);
            KritaPlugin.Client.CurrentView.SetPatternSize(brushPatternSize).Wait();
            this.AdjustmentValueChanged(); // Notify the plugin service that the adjustment value has changed.
        }

        // This method is called when the reset command related to the adjustment is executed.
        protected override void RunCommand(String actionParameter)
        {
            KritaPlugin.Client.CurrentView.SetPatternSize(1).Wait();
            this.AdjustmentValueChanged(); // Notify the plugin service that the adjustment value has changed.
        }

        // Returns the adjustment value that is shown next to the dial.
        protected override String GetAdjustmentValue(String actionParameter)
        {
            return "0x"; // Math.Round(KritaPlugin.Client.CurrentView.PatternSize().Result, 2).ToString() + "x";
        }
    }
}
