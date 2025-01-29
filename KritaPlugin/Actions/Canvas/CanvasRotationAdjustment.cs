namespace Loupedeck.KritaPlugin
{
    // This class implements an example adjustment that counts the rotation ticks of a dial.

    public class CanvasRotationAdjustment : PluginDynamicAdjustment
    {
        private KritaPlugin KritaPlugin => (KritaPlugin)Plugin;

        // Initializes the adjustment class.
        // When `hasReset` is set to true, a reset command is automatically created for this adjustment.
        public CanvasRotationAdjustment()
            : base(displayName: "Canvas rotation", description: "Adjust canvas rotation", groupName: ActionGroups.CanvasAdjustements, hasReset: true)
        {
        }

        protected override BitmapImage GetAdjustmentImage(string actionParameter, PluginImageSize imageSize)
        {
            return EmbeddedResources.ReadImage(EmbeddedResources.FindFile("CanvasRotation.png"));
        }

        // This method is called when the adjustment is executed.
        protected override void ApplyAdjustment(String actionParameter, Int32 diff)
        {
            var rotation = KritaPlugin.Client.CurrentCanvas.Rotation().Result;
            KritaPlugin.Client.CurrentCanvas.SetRotation(rotation + diff).Wait();
            this.AdjustmentValueChanged(); // Notify the plugin service that the adjustment value has changed.
        }

        // This method is called when the reset command related to the adjustment is executed.
        protected override void RunCommand(String actionParameter)
        {
            KritaPlugin.Client.CurrentCanvas.ResetRotation().Wait();
            this.AdjustmentValueChanged(); // Notify the plugin service that the adjustment value has changed.
        }

        // Returns the adjustment value that is shown next to the dial.
        protected override String GetAdjustmentValue(String actionParameter)
        {
            return Math.Round(KritaPlugin.Client.CurrentCanvas.Rotation().Result, 2).ToString() + " °";
        }
    }
}
