using Loupedeck;
using LogiKritaApiClient.ClientBase;
using Logi.KritaPlugin.Constants;

namespace Logi.KritaPlugin.Actions
{
    // This class implements an example adjustment that counts the rotation ticks of a dial.

    public class ViewBrushOpacityAdjustment : PluginDynamicAdjustment
    {
        private Client Client => ((KritaApplication)Plugin.ClientApplication).Client;
        private static float Opacity = 1;
        private static DateTime LastAdjust = DateTime.MinValue;

        // Initializes the adjustment class.
        // When `hasReset` is set to true, a reset command is automatically created for this adjustment.
        public ViewBrushOpacityAdjustment()
            : base(displayName: ViewToolsConstants.BrushOpacity.Name, description: "Adjust brush opacity", groupName: ActionGroups.ViewAdjustements, hasReset: true)
        {
        }

        protected override BitmapImage GetAdjustmentImage(string actionParameter, PluginImageSize imageSize)
        {
            return PluginResources.BitmapFromEmbaddedRessource(ViewToolsConstants.BrushOpacity.BitMapImageName);
        }


        // This method is called when the adjustment is executed.
        protected override void ApplyAdjustment(String actionParameter, Int32 diff)
        {
            AdjustBrushOpacity(Client, diff, AdjustmentValueChanged);
        }

        public static void AdjustBrushOpacity(Client client, int diff, Action adjustValueChangedHandler)
        {
            if (client == null) return;

            UpdateAdjustValueIfNecessary(client);
            var newOpacity = (float)Math.Min(Math.Max(Opacity + (float)diff / 100, 0), 1);

            if (newOpacity != Opacity)
            {
                Opacity = newOpacity;
                client.CurrentView.SetPaintingOpacity(Opacity).Wait();
                adjustValueChangedHandler();
            }
        }

        // This method is called when the reset command related to the adjustment is executed.
        protected override void RunCommand(String actionParameter)
        {
            ResetBrushOpacity(Client, AdjustmentValueChanged);
        }

        public static void ResetBrushOpacity(Client client, Action adjustValueChangedHandler)
        {
            if (client == null) return;

            client.CurrentView.SetPaintingOpacity(1).Wait();
            Opacity = 1;
            adjustValueChangedHandler(); // Notify the plugin service that the adjustment value has changed.
        }

        // Returns the adjustment value that is shown next to the dial.
        protected override String GetAdjustmentValue(String actionParameter)
        {
            return GetBrushOpacity(Client);
        }

        public static string GetBrushOpacity(Client client)
        {
            if (client == null) return "-";

            UpdateAdjustValueIfNecessary(client);
            return Math.Round(Opacity * 100).ToString() + " %";
        }

        private static void UpdateAdjustValueIfNecessary(Client client)
        {
            if ((DateTime.Now - LastAdjust).TotalMilliseconds > 500)
            {
                Opacity = client.CurrentView.PaintingOpacity().Result;
                LastAdjust = DateTime.Now;
            }
        }
    }
}
