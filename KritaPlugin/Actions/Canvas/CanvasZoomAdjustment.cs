using Loupedeck;
using LogiKritaApiClient.ClientBase;
using Logi.KritaPlugin.Constants;
using System.Runtime.InteropServices;

namespace Logi.KritaPlugin.Actions
{
    // This class implements an example adjustment that counts the rotation ticks of a dial.

    public class CanvasZoomAdjustment : PluginDynamicAdjustment
    {
        private Client Client => ((KritaApplication)Plugin.ClientApplication).Client;
        private static int referenceDpi = RuntimeInformation.IsOSPlatform(OSPlatform.Windows) ? 72 : 144; // Reference DPI for Krita, used to calculate zoom level.
        private static float Zoom = 1;
        private static DateTime LastAdjust = DateTime.MinValue;

        // Initializes the adjustment class.
        // When `hasReset` is set to true, a reset command is automatically created for this adjustment.
        public CanvasZoomAdjustment()
            : base(displayName: ViewToolsConstants.CanvasZoom.Name, description: "Adjust canvas zoom", groupName: ActionGroups.Canvas, hasReset: true)
        {
        }

        protected override BitmapImage GetAdjustmentImage(string actionParameter, PluginImageSize imageSize)
        {
            return PluginResources.BitmapFromEmbaddedRessource(ViewToolsConstants.CanvasZoom.BitMapImageName);
        }

        // This method is called when the adjustment is executed.
        protected override void ApplyAdjustment(String actionParameter, Int32 diff)
        {
            AdjustCanvasZoom(Client, diff, AdjustmentValueChanged);
        }

        public static void AdjustCanvasZoom(Client client, int diff, Action valueCHangedHandler)
        {
            if (client == null) return;

            UpdateAdjustValueIfNecessary(client);
            Zoom = Zoom + (float)diff * Zoom / 100;
            client.CurrentCanvas.SetZoomLevel(Zoom).Wait();
            valueCHangedHandler();
        }

        // This method is called when the reset command related to the adjustment is executed.
        protected override void RunCommand(String actionParameter)
        {
            ResetZoom(Client, AdjustmentValueChanged);
        }

        public static void ResetZoom(Client client, Action adjustValueChangedHandler)
        {
            if (client == null) return;

            client.CurrentCanvas.ResetZoom().Wait();
            Zoom = 1;
            adjustValueChangedHandler(); // Notify the plugin service that the adjustment value has changed.
        }

        // Returns the adjustment value that is shown next to the dial.
        protected override String GetAdjustmentValue(String actionParameter)
        {
            return GetCanvasZoom(Client);
        }

        public static string GetCanvasZoom(Client client)
        {
            if (client == null) return "-";

            UpdateAdjustValueIfNecessary(client);
            return Math.Round(Zoom * 100, Zoom >= 1 ? 0 : 1).ToString() + " %";
        }

        private static void UpdateAdjustValueIfNecessary(Client client)
        {
            if ((DateTime.Now - LastAdjust).TotalMilliseconds > 500)
            {
                Zoom = client.CurrentCanvas.ZoomLevel().Result * referenceDpi / client.CurrentDocument.GetResolution().Result;
                LastAdjust = DateTime.Now;
            }
        }
    }
}
