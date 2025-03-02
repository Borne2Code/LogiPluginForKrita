using LoupedeckKritaApiClient.ClientBase;

namespace Loupedeck.KritaPlugin
{
    // This class implements an example adjustment that counts the rotation ticks of a dial.

    public class ViewBrushPatternSizeAdjustment : PluginDynamicAdjustment
    {
        private Client Client => ((KritaApplication)Plugin.ClientApplication).Client;

        // Initializes the adjustment class.
        // When `hasReset` is set to true, a reset command is automatically created for this adjustment.
        public ViewBrushPatternSizeAdjustment()
            : base(displayName: "Brush pattern size", description: "Adjust brush pattern size. Available with Krita 5.3.x and above", groupName: ActionGroups.ViewAdjustements, hasReset: true)
        {
        }

        protected override BitmapImage GetAdjustmentImage(string actionParameter, PluginImageSize imageSize)
        {
            return EmbeddedResources.ReadImage(EmbeddedResources.FindFile("BrushPatternSize.png"));
        }

        // This method is called when the adjustment is executed.
        protected override void ApplyAdjustment(String actionParameter, Int32 diff)
        {
            var brushPatternSize = Client.CurrentView.PatternSize().Result;
            var newBrushPatternSize = (float)Math.Round(brushPatternSize + diff / 100, 2);
            newBrushPatternSize = (float)Math.Min(Math.Max(newBrushPatternSize, 0.01), 20);

            if (newBrushPatternSize != brushPatternSize)
            {
                Client.CurrentView.SetPatternSize(newBrushPatternSize).Wait();
                this.AdjustmentValueChanged(); // Notify the plugin service that the adjustment value has changed.
            }
        }

        // This method is called when the reset command related to the adjustment is executed.
        protected override void RunCommand(String actionParameter)
        {
            Client.CurrentView.SetPatternSize(1).Wait();
            this.AdjustmentValueChanged(); // Notify the plugin service that the adjustment value has changed.
        }

        // Returns the adjustment value that is shown next to the dial.
        protected override String GetAdjustmentValue(String actionParameter)
        {
            return "0x"; // Math.Round(Client.CurrentView.PatternSize().Result, 2).ToString() + "x";
        }
    }
}
