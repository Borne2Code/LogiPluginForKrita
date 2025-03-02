using LoupedeckKritaApiClient.ClientBase;

namespace Loupedeck.KritaPlugin
{
    // This class implements an example adjustment that counts the rotation ticks of a dial.

    public class ViewBrushSizeAdjustment : PluginDynamicAdjustment
    {
        private Client Client => ((KritaApplication)Plugin.ClientApplication).Client;

        // Initializes the adjustment class.
        // When `hasReset` is set to true, a reset command is automatically created for this adjustment.
        public ViewBrushSizeAdjustment()
            : base(displayName: "Brush size", description: "Adjust brush size", groupName: ActionGroups.ViewAdjustements, hasReset: false)
        {
        }

        protected override BitmapImage GetAdjustmentImage(string actionParameter, PluginImageSize imageSize)
        {
            return EmbeddedResources.ReadImage(EmbeddedResources.FindFile("BrushSize.png"));
        }

        // This method is called when the adjustment is executed.
        protected override void ApplyAdjustment(String actionParameter, Int32 diff)
        {
            var brushSize = Client.CurrentView.BrushSize().Result;
            var delta = Math.Max(brushSize * (float)Math.Abs(diff) / 20, 0.01) * Math.Sign(diff);
            var newBrushSize = (float)Math.Round(brushSize + delta, 2);
            newBrushSize = (float)Math.Min(Math.Max(newBrushSize, 0.01), 3000);

            if (newBrushSize != brushSize)
            {
                Client.CurrentView.SetBrushSize(newBrushSize).Wait();
                this.AdjustmentValueChanged(); // Notify the plugin service that the adjustment value has changed.
            }
        }

        // This method is called when the reset command related to the adjustment is executed.
        protected override void RunCommand(String actionParameter)
        {
        }

        // Returns the adjustment value that is shown next to the dial.
        protected override String GetAdjustmentValue(String actionParameter)
        {
            return Math.Round(Client.CurrentView.BrushSize().Result, 2).ToString();
        }
    }
}
