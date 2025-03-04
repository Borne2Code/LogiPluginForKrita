using System.Reflection;
using LoupedeckKritaApiClient.ClientBase;

namespace Loupedeck.KritaPlugin
{
    // This class implements an example adjustment that counts the rotation ticks of a dial.

    public class ViewBrushFlowAdjustment : PluginDynamicAdjustment
    {
        private Client Client => ((KritaApplication)Plugin.ClientApplication).Client;

        // Initializes the adjustment class.
        // When `hasReset` is set to true, a reset command is automatically created for this adjustment.
        public ViewBrushFlowAdjustment()
            : base(displayName: "Brush flow", description: "Adjust brush flow", groupName: ActionGroups.ViewAdjustements, hasReset: true)
        {
        }

        protected override BitmapImage GetAdjustmentImage(string actionParameter, PluginImageSize imageSize)
        {
            return BitmapImage.FromResource(Assembly.GetExecutingAssembly(), "Loupedeck.KritaPlugin.images.BrushFlow.png");
        }


        // This method is called when the adjustment is executed.
        protected override void ApplyAdjustment(String actionParameter, Int32 diff)
        {
            var flow = Client.CurrentView.PaintingFlow().Result;
            var newFlow = (float)Math.Min(Math.Max(flow + (float)diff / 100, 0), 1);

            if (newFlow != flow)
            {
                Client.CurrentView.SetPaintingFlow(newFlow).Wait();
                this.AdjustmentValueChanged(); // Notify the plugin service that the adjustment value has changed.
            }
        }

        // This method is called when the reset command related to the adjustment is executed.
        protected override void RunCommand(String actionParameter)
        {
            Client.CurrentView.SetPaintingFlow(1).Wait();
            this.AdjustmentValueChanged(); // Notify the plugin service that the adjustment value has changed.
        }

        // Returns the adjustment value that is shown next to the dial.
        protected override String GetAdjustmentValue(String actionParameter)
        {
            return Math.Round(Client.CurrentView.PaintingFlow().Result * 100).ToString() + " %";
        }
    }
}
