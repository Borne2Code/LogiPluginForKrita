using Loupedeck;
using LogiKritaApiClient.ClientBase;
using Logi.KritaPlugin.Constants;

namespace Logi.KritaPlugin.Actions
{
    // This class implements an example adjustment that counts the rotation ticks of a dial.

    public class SwapColorsCommand : PluginDynamicCommand
    {
        private Client Client => ((KritaApplication)Plugin.ClientApplication).Client;

        // Initializes the command class.
        public SwapColorsCommand()
            : base(displayName: ColorSelectorToolsConstants.Swap.Name, description: "Swap Background/Foreground", groupName: ActionGroups.ColorSelector)
        {
        }

        protected override BitmapImage GetCommandImage(string actionParameter, PluginImageSize imageSize)
        {
            return PluginResources.BitmapFromEmbaddedRessource(ColorSelectorToolsConstants.Swap.BitMapImageName);
        }

        protected override void RunCommand(string actionParameter)
        {
            if (Client == null) return;

            Client.KritaInstance.ExecuteAction(ColorSelectorToolsConstants.Swap.ActionName).Wait();
        }
    }
}
