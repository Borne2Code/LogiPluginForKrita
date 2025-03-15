using System.Reflection;
using LoupedeckKritaApiClient.ClientBase;

namespace Loupedeck.KritaPlugin
{
    // This class implements an example adjustment that counts the rotation ticks of a dial.

    public class ViewBrushSizeAdjustment : PluginDynamicAdjustment
    {
        private Client Client => ((KritaApplication)Plugin.ClientApplication).Client;
        private float Size = 0;
        private DateTime LastAdjust = DateTime.MinValue;

        // Initializes the adjustment class.
        // When `hasReset` is set to true, a reset command is automatically created for this adjustment.
        public ViewBrushSizeAdjustment()
            : base(displayName: "Brush size", description: "Adjust brush size", groupName: ActionGroups.ViewAdjustements, hasReset: false)
        {
        }

        protected override BitmapImage GetAdjustmentImage(string actionParameter, PluginImageSize imageSize)
        {
            return BitmapImage.FromResource(Assembly.GetExecutingAssembly(), "Loupedeck.KritaPlugin.images.View.BrushSize.png");
        }

        // This method is called when the adjustment is executed.
        protected override void ApplyAdjustment(String actionParameter, Int32 diff)
        {
            UpdateAdjustValueIfNecessary();

            var delta = Math.Max(Size * (float)Math.Abs(diff) / 40, 0.01) * Math.Sign(diff);
            var newBrushSize = (float)Math.Round(Size + delta, 2);
            newBrushSize = (float)Math.Min(Math.Max(newBrushSize, 0.01), 3000);

            if (newBrushSize != Size)
            {
                Size = newBrushSize;
                Client.CurrentView.SetBrushSize(Size).Wait();
                this.AdjustmentValueChanged(); // Notify the plugin service that the adjustment value has changed.
            }
        }

        // Returns the adjustment value that is shown next to the dial.
        protected override String GetAdjustmentValue(String actionParameter)
        {
            UpdateAdjustValueIfNecessary();
            return Math.Round(Size, 2).ToString();
        }

        private void UpdateAdjustValueIfNecessary()
        {
            if ((DateTime.Now - LastAdjust).TotalMilliseconds > 500)
            {
                Size = Client.CurrentView.BrushSize().Result;
                LastAdjust = DateTime.Now;
            }
        }
    }
}
