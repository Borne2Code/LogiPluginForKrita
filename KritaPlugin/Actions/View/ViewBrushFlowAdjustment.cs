using System.Reflection;
using LoupedeckKritaApiClient.ClientBase;

namespace Loupedeck.KritaPlugin
{
    // This class implements an example adjustment that counts the rotation ticks of a dial.

    public class ViewBrushFlowAdjustment : PluginDynamicAdjustment
    {
        private Client Client => ((KritaApplication)Plugin.ClientApplication).Client;
        private float Flow = 1;
        private DateTime LastAdjust = DateTime.MinValue;

        // Initializes the adjustment class.
        // When `hasReset` is set to true, a reset command is automatically created for this adjustment.
        public ViewBrushFlowAdjustment()
            : base(displayName: "Brush flow", description: "Adjust brush flow", groupName: ActionGroups.ViewAdjustements, hasReset: true)
        {
        }

        protected override BitmapImage GetAdjustmentImage(string actionParameter, PluginImageSize imageSize)
        {
            return PluginResources.BitmapFromEmbaddedRessource("Loupedeck.KritaPlugin.images.View.BrushFlow.png");
        }


        // This method is called when the adjustment is executed.
        protected override void ApplyAdjustment(String actionParameter, Int32 diff)
        {
            if (Client == null) return;

            UpdateAdjustValueIfNecessary();

            var newFlow = (float)Math.Min(Math.Max(Flow + (float)diff / 100, 0), 1);

            if (newFlow != Flow)
            {
                Flow = newFlow;
                Client.CurrentView.SetPaintingFlow(Flow).Wait();
                this.AdjustmentValueChanged(); // Notify the plugin service that the adjustment value has changed.
            }
        }

        // This method is called when the reset command related to the adjustment is executed.
        protected override void RunCommand(String actionParameter)
        {
            if (Client == null) return;

            Flow = 1;
            Client.CurrentView.SetPaintingFlow(1).Wait();
            this.AdjustmentValueChanged(); // Notify the plugin service that the adjustment value has changed.
        }

        // Returns the adjustment value that is shown next to the dial.
        protected override String GetAdjustmentValue(String actionParameter)
        {
            if (Client == null) return "-";

            UpdateAdjustValueIfNecessary();
            return Math.Round(Flow * 100).ToString() + " %";
        }

        private void UpdateAdjustValueIfNecessary()
        {
            if ((DateTime.Now - LastAdjust).TotalMilliseconds > 500)
            {
                Flow = Client.CurrentView.PaintingFlow().Result;
                LastAdjust = DateTime.Now;
            }
        }
    }
}
