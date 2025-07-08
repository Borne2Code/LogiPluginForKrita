using Loupedeck;
using LogiKritaApiClient.ClientBase;
using Logi.KritaPlugin.Constants;

namespace Logi.KritaPlugin.Actions
{
    // This class implements an example adjustment that counts the rotation ticks of a dial.

    public class LayerOpacityAdjustment : PluginDynamicAdjustment
    {
        private Client Client => ((KritaApplication)Plugin.ClientApplication).Client;
        private static int Opacity = 255;
        private static DateTime LastAdjust = DateTime.MinValue;
        private static Timer? _timer;

        // Initializes the adjustment class.
        // When `hasReset` is set to true, a reset command is automatically created for this adjustment.
        public LayerOpacityAdjustment()
            : base(displayName: LayerToolsConstants.Opacity.Name, description: "Adjust current layer's opacity", groupName: ActionGroups.Layers, hasReset: true)
        {
        }

        protected override BitmapImage GetAdjustmentImage(string actionParameter, PluginImageSize imageSize)
        {
            return PluginResources.BitmapFromEmbaddedRessource(LayerToolsConstants.Opacity.BitMapImageName);
        }

        // This method is called when the adjustment is executed.
        protected override void ApplyAdjustment(String actionParameter, Int32 diff)
        {
            AdjustOpacity(Client, diff, AdjustmentValueChanged);
        }

        public static void AdjustOpacity(Client client, int diff, Action adjustmentValueChangedHandler)
        {
            if (client == null) return;

            UpdateAdjustValueIfNecessary(client);

            var newOpacity = Math.Min(Math.Max(Opacity + diff, 0), 255);

            if (newOpacity != Opacity)
            {
                Opacity = newOpacity;
                client.CurrentNode.SetOpacity(Opacity).Wait();
                if (_timer != null)
                {
                    _timer.Dispose();
                    _timer = null;
                }
                _timer = new Timer((_) => client.CurrentDocument.RefreshProjection(), null, 500, Timeout.Infinite);

                adjustmentValueChangedHandler(); // Notify the plugin service that the adjustment value has changed.
            }
        }

        // This method is called when the reset command related to the adjustment is executed.
        protected override void RunCommand(String actionParameter)
        {
            if (Client == null) return;

            Opacity = 255;
            Client.CurrentNode.SetOpacity(Opacity).Wait();
            Client.CurrentDocument.RefreshProjection();
            AdjustmentValueChanged(); // Notify the plugin service that the adjustment value has changed.
        }

        // Returns the adjustment value that is shown next to the dial.
        protected override String GetAdjustmentValue(String actionParameter)
        {
            return GetOpcityValue(Client);
        }

        public static string GetOpcityValue(Client client)
        {
            if (client == null) return "-";

            UpdateAdjustValueIfNecessary(client);
            return (Opacity * 100 / 255).ToString() + " %";
        }

        protected override double? GetAdjustmentMinValue(string actionParameter)
        {
            return GetMinOpacity();
        }

        public static float GetMinOpacity()
        {
            return 0.0f;
        }

        protected override double? GetAdjustmentMaxValue(string actionParameter)
        {
            return GetMaxOpacity();
        }

        public static float GetMaxOpacity()
        {
            return 255f;
        }

        private static void UpdateAdjustValueIfNecessary(Client client)
        {
            if ((DateTime.Now - LastAdjust).TotalMilliseconds > 500)
            {
                Opacity = client.CurrentNode.Opacity().Result;
                LastAdjust = DateTime.Now;
            }
        }
    }
}
