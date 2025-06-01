using System.Reflection;
using LoupedeckKritaApiClient.ClientBase;

namespace Loupedeck.KritaPlugin
{
    // This class implements an example adjustment that counts the rotation ticks of a dial.

    public class ViewBrushPatternSizeAdjustment : PluginDynamicAdjustment
    {
        private Client Client => ((KritaApplication)Plugin.ClientApplication).Client;
        private float PatternSize = 1;
        private DateTime LastAdjust = DateTime.MinValue;

        // Initializes the adjustment class.
        // When `hasReset` is set to true, a reset command is automatically created for this adjustment.
        public ViewBrushPatternSizeAdjustment()
            : base(displayName: "Brush pattern size", description: "Adjust brush pattern size. Available with Krita 5.3.x and above", groupName: ActionGroups.ViewAdjustements, hasReset: true)
        {
        }

        protected override BitmapImage GetAdjustmentImage(string actionParameter, PluginImageSize imageSize)
        {
            return BitmapImage.FromResource(Assembly.GetExecutingAssembly(), "Loupedeck.KritaPlugin.images.View.BrushPatternSize.png");
        }

        // This method is called when the adjustment is executed.
        protected override void ApplyAdjustment(String actionParameter, Int32 diff)
        {
            if (Client == null) return;

            UpdateAdjustValueIfNecessary();
            var newBrushPatternSize = (float)Math.Min(Math.Max((float)Math.Round(PatternSize + diff / 100, 2), 0.01), 20);

            if (newBrushPatternSize != PatternSize)
            {
                PatternSize = newBrushPatternSize;
                Client.CurrentView.SetPatternSize(PatternSize).Wait();
                this.AdjustmentValueChanged(); // Notify the plugin service that the adjustment value has changed.
            }
        }

        // This method is called when the reset command related to the adjustment is executed.
        protected override void RunCommand(String actionParameter)
        {
            if (Client == null) return;

            PatternSize = 1;
            Client.CurrentView.SetPatternSize(PatternSize).Wait();
            this.AdjustmentValueChanged(); // Notify the plugin service that the adjustment value has changed.
        }

        // Returns the adjustment value that is shown next to the dial.
        protected override String GetAdjustmentValue(String actionParameter)
        {
            if (Client == null) return "-";

            UpdateAdjustValueIfNecessary();
            return "0x"; // Math.Round(Client.CurrentView.PatternSize().Result, 2).ToString() + "x";
        }

        private void UpdateAdjustValueIfNecessary()
        {
            if ((DateTime.Now - LastAdjust).TotalMilliseconds > 500)
            {
                PatternSize = Client.CurrentView.PatternSize().Result;
                LastAdjust = DateTime.Now;
            }
        }
    }
}
