using Loupedeck;
using LogiKritaApiClient.ClientBase;
using Logi.KritaPlugin.Constants;

namespace Logi.KritaPlugin.Actions
{
    // This class implements an example adjustment that counts the rotation ticks of a dial.

    public class CanvasRotationAdjustment : PluginDynamicAdjustment
    {
        private Client Client => ((KritaApplication)Plugin.ClientApplication).Client;
        private static float Rotation = 0;
        private static DateTime LastAdjust = DateTime.MinValue;

        // Initializes the adjustment class.
        // When `hasReset` is set to true, a reset command is automatically created for this adjustment.
        public CanvasRotationAdjustment()
            : base(displayName: ViewToolsConstants.CanvasRotation.Name, description: "Adjust canvas rotation", groupName: ActionGroups.CanvasAdjustements, hasReset: true)
        {
        }

        protected override BitmapImage GetAdjustmentImage(string actionParameter, PluginImageSize imageSize)
        {
            return PluginResources.BitmapFromEmbaddedRessource(ViewToolsConstants.CanvasRotation.BitMapImageName);
        }

        // This method is called when the adjustment is executed.
        protected override void ApplyAdjustment(String actionParameter, Int32 diff)
        {
            AdjustCanvasRotation(Client, diff, AdjustmentValueChanged);
        }

        public static void AdjustCanvasRotation(Client client, int diff, Action valueChangedHandler)
        {
            if (client == null) return;

            UpdateAdjustValueIfNecessary(client);
            Rotation += diff;
            client.CurrentCanvas.SetRotation(Rotation).Wait();
            valueChangedHandler(); // Notify the plugin service that the adjustment value has changed.
        }

        // This method is called when the reset command related to the adjustment is executed.
        protected override void RunCommand(String actionParameter)
        {
            if (Client == null) return;

            Client.CurrentCanvas.ResetRotation().Wait();
            Rotation = 0;
            this.AdjustmentValueChanged(); // Notify the plugin service that the adjustment value has changed.
        }

        // Returns the adjustment value that is shown next to the dial.
        protected override String GetAdjustmentValue(String actionParameter)
        {
            return GetCanvasRotation(Client);
        }

        public static string GetCanvasRotation(Client client)
        {
            if (client == null) return "-";

            UpdateAdjustValueIfNecessary(client);
            return Math.Round(Rotation).ToString() + " °";
        }

        private static void UpdateAdjustValueIfNecessary(Client client)
        {
            if ((DateTime.Now - LastAdjust).TotalMilliseconds > 500)
            {
                Rotation = client.CurrentCanvas.Rotation().Result;
                LastAdjust = DateTime.Now;
            }
        }
    }
}
