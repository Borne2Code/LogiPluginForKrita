using Loupedeck;
using LogiKritaApiClient.ClientBase;
using Logi.KritaPlugin.Constants;

namespace Logi.KritaPlugin.Actions
{
    // This class implements an example adjustment that counts the rotation ticks of a dial.

    public class ViewBrushSizeAdjustment : PluginDynamicAdjustment
    {
        private Client Client => ((KritaApplication)Plugin.ClientApplication).Client;
        private static float Size = 0;
        private static DateTime LastAdjust = DateTime.MinValue;

        // Initializes the adjustment class.
        // When `hasReset` is set to true, a reset command is automatically created for this adjustment.
        public ViewBrushSizeAdjustment()
            : base(displayName: ViewToolsConstants.BrushSize.Name, description: "Adjust brush size", groupName: ActionGroups.ViewAdjustements, hasReset: false)
        {
        }

        protected override BitmapImage GetAdjustmentImage(string actionParameter, PluginImageSize imageSize)
        {
            return PluginResources.BitmapFromEmbaddedRessource(ViewToolsConstants.BrushSize.BitMapImageName);
        }

        // This method is called when the adjustment is executed.
        protected override void ApplyAdjustment(String actionParameter, Int32 diff)
        {
            AdjustBrushSize(Client, diff, AdjustmentValueChanged);
        }

        public static void AdjustBrushSize(Client client, int diff, Action adjustValueChangedHandler)
        {
            if (client == null) return;

            UpdateAdjustValueIfNecessary(client);

            var delta = Math.Max(Size * (float)Math.Abs(diff) / 40, 0.01) * Math.Sign(diff);
            var newBrushSize = (float)Math.Round(Size + delta, 2);
            newBrushSize = (float)Math.Min(Math.Max(newBrushSize, 0.01), 3000);

            if (newBrushSize != Size)
            {
                Size = newBrushSize;
                client.CurrentView.SetBrushSize(Size).Wait();
                adjustValueChangedHandler(); // Notify the plugin service that the adjustment value has changed.
            }
        }

        // Returns the adjustment value that is shown next to the dial.
        protected override String GetAdjustmentValue(String actionParameter)
        {
            return GetBrushSize(Client);
        }

        public static string GetBrushSize(Client client)
        {
            if (client == null) return "-";

            UpdateAdjustValueIfNecessary(client);
            return Math.Round(Size, Size >= 100 ? 1 : 2).ToString();
        }

        private static void UpdateAdjustValueIfNecessary(Client client)
        {
            if ((DateTime.Now - LastAdjust).TotalMilliseconds > 500)
            {
                Size = client.CurrentView.BrushSize().Result;
                LastAdjust = DateTime.Now;
            }
        }
    }
}
