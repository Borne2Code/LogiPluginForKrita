using LoupedeckKritaApiClient.ClientBase;

namespace Loupedeck.KritaPlugin
{
    // This class implements an example adjustment that counts the rotation ticks of a dial.

    public class ViewBrushOpacityAdjustment : PluginDynamicAdjustment
    {
        private Client Client => ((KritaApplication)Plugin.ClientApplication).Client;

        // Initializes the adjustment class.
        // When `hasReset` is set to true, a reset command is automatically created for this adjustment.
        public ViewBrushOpacityAdjustment()
            : base(displayName: "Brush opacity", description: "Adjust brush opacity", groupName: ActionGroups.ViewAdjustements, hasReset: true)
        {
        }

        protected override BitmapImage GetAdjustmentImage(string actionParameter, PluginImageSize imageSize)
        {
            return EmbeddedResources.ReadImage(EmbeddedResources.FindFile("BrushOpacity.png"));
        }


        // This method is called when the adjustment is executed.
        protected override void ApplyAdjustment(String actionParameter, Int32 diff)
        {
            var opacity = Client.CurrentView.PaintingOpacity().Result;
            var newOpacity = (float)Math.Min(Math.Max(opacity + (float)diff / 100, 0), 1);

            if (newOpacity != opacity)
            {
                Client.CurrentView.SetPaintingOpacity(newOpacity).Wait();
                this.AdjustmentValueChanged(); // Notify the plugin service that the adjustment value has changed.
            }
        }

        // This method is called when the reset command related to the adjustment is executed.
        protected override void RunCommand(String actionParameter)
        {
            Client.CurrentView.SetPaintingOpacity(1).Wait();
            this.AdjustmentValueChanged(); // Notify the plugin service that the adjustment value has changed.
        }

        // Returns the adjustment value that is shown next to the dial.
        protected override String GetAdjustmentValue(String actionParameter)
        {
            return Math.Round(Client.CurrentView.PaintingOpacity().Result * 100).ToString() + " %";
        }
    }
}
