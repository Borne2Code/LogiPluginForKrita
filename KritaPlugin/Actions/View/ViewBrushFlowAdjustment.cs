using Loupedeck;
using LogiKritaApiClient.ClientBase;
using Logi.KritaPlugin.Constants;

namespace Logi.KritaPlugin.Actions
{
    // This class implements an example adjustment that counts the rotation ticks of a dial.

    public class ViewBrushFlowAdjustment : PluginDynamicAdjustment
    {
        private Client Client => ((KritaApplication)Plugin.ClientApplication).Client;
        private static float Flow = 1;
        private static DateTime LastAdjust = DateTime.MinValue;

        // Initializes the adjustment class.
        // When `hasReset` is set to true, a reset command is automatically created for this adjustment.
        public ViewBrushFlowAdjustment()
            : base(displayName: ViewToolsConstants.BrushFlow.Name, description: "Adjust brush flow", groupName: ActionGroups.View, hasReset: true)
        {
        }

        protected override BitmapImage GetAdjustmentImage(string actionParameter, PluginImageSize imageSize)
        {
            return PluginResources.BitmapFromEmbaddedRessource(ViewToolsConstants.BrushFlow.BitMapImageName);
        }


        // This method is called when the adjustment is executed.
        protected override void ApplyAdjustment(String actionParameter, Int32 diff)
        {
            AdjustBrushFlow(Client, diff, AdjustmentValueChanged);
        }

        public static void AdjustBrushFlow(Client client, int diff, Action valueChangedHandler)
        {
            if (client == null) return;

            UpdateAdjustValueIfNecessary(client);

            var newFlow = (float)Math.Min(Math.Max(Flow + (float)diff / 100, 0), 1);

            if (newFlow != Flow)
            {
                Flow = newFlow;
                client.CurrentView.SetPaintingFlow(Flow).Wait();
                valueChangedHandler(); // Notify the plugin service that the adjustment value has changed.
            }
        }

        // This method is called when the reset command related to the adjustment is executed.
        protected override void RunCommand(String actionParameter)
        {
            ResetBrushFlow(Client, AdjustmentValueChanged);
        }

        public static void ResetBrushFlow(Client client, Action adjustValueChangedHandler)
        {
            if (client == null) return;

            Flow = 1;
            client.CurrentView.SetPaintingFlow(1).Wait();
            adjustValueChangedHandler(); // Notify the plugin service that the adjustment value has changed.
        }

        // Returns the adjustment value that is shown next to the dial.
        protected override String GetAdjustmentValue(String actionParameter)
        {
            return GetBrushFlow(Client);
        }

        public static string GetBrushFlow(Client client)
        {
            if (client == null) return "-";

            UpdateAdjustValueIfNecessary(client);
            return Math.Round(Flow * 100).ToString() + " %";
        }

        private static void UpdateAdjustValueIfNecessary(Client client)
        {
            if ((DateTime.Now - LastAdjust).TotalMilliseconds > 500)
            {
                Flow = client.CurrentView.PaintingFlow().Result;
                LastAdjust = DateTime.Now;
            }
        }
    }
}
