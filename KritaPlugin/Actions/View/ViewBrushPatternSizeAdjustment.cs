using Loupedeck;
using LogiKritaApiClient.ClientBase;
using Logi.KritaPlugin.Constants;

namespace Logi.KritaPlugin.Actions
{
    // This class implements an example adjustment that counts the rotation ticks of a dial.

    public class ViewBrushPatternSizeAdjustment : PluginDynamicAdjustment
    {
        private Client Client => ((KritaApplication)Plugin.ClientApplication).Client;
        private static float PatternSize = 1;
        private static DateTime LastAdjust = DateTime.MinValue;

        // Initializes the adjustment class.
        // When `hasReset` is set to true, a reset command is automatically created for this adjustment.
        public ViewBrushPatternSizeAdjustment()
            : base(displayName: ViewToolsConstants.BrushPatternSize.Name, description: "Adjust brush pattern size. Available with Krita 5.3.x and above", groupName: ActionGroups.View, hasReset: true)
        {
        }

        protected override BitmapImage GetAdjustmentImage(string actionParameter, PluginImageSize imageSize)
        {
            return PluginResources.BitmapFromEmbaddedRessource(ViewToolsConstants.BrushPatternSize.BitMapImageName);
        }

        // This method is called when the adjustment is executed.
        protected override void ApplyAdjustment(String actionParameter, Int32 diff)
        {
            AdjustBrushPatternSize(Client, diff, AdjustmentValueChanged);
        }

        public static void AdjustBrushPatternSize(Client client, int diff, Action valueChangedHandler)
        {
            if (client == null) return;

            UpdateAdjustValueIfNecessary(client);
            var newBrushPatternSize = (float)Math.Min(Math.Max((float)Math.Round(PatternSize + diff / 100, 2), 0.01), 20);

            if (newBrushPatternSize != PatternSize)
            {
                PatternSize = newBrushPatternSize;
                client.CurrentView.SetPatternSize(PatternSize).Wait();
                valueChangedHandler(); // Notify the plugin service that the adjustment value has changed.
            }
        }

        // This method is called when the reset command related to the adjustment is executed.
        protected override void RunCommand(String actionParameter)
        {
            ResetBrushPatternSize(Client, AdjustmentValueChanged);
        }

        public static void ResetBrushPatternSize(Client client, Action adjustValueChangedHandler)
        {
            if (client == null) return;

            PatternSize = 1;
            client.CurrentView.SetPatternSize(PatternSize).Wait();
            adjustValueChangedHandler(); // Notify the plugin service that the adjustment value has changed.
        }

        // Returns the adjustment value that is shown next to the dial.
        protected override String GetAdjustmentValue(String actionParameter)
        {
            return GetBrushPatternSize(Client);
        }

        public static string GetBrushPatternSize(Client client)
        {
            if (client == null) return "-";

            UpdateAdjustValueIfNecessary(client);
            return "0x"; // Math.Round(Client.CurrentView.PatternSize().Result, 2).ToString() + "x";
        }

        private static void UpdateAdjustValueIfNecessary(Client client)
        {
            if ((DateTime.Now - LastAdjust).TotalMilliseconds > 500)
            {
                PatternSize = client.CurrentView.PatternSize().Result;
                LastAdjust = DateTime.Now;
            }
        }
    }
}
