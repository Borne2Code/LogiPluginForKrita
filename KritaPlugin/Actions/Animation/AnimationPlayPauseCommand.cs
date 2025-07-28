using Loupedeck;
using LogiKritaApiClient.ClientBase;
using Logi.KritaPlugin.Constants;

namespace Logi.KritaPlugin.Actions
{
    // This class implements an example adjustment that counts the rotation ticks of a dial.

    public class AnimationPlayPauseCommand : PluginDynamicCommand
    {
        private Client Client => ((KritaApplication)Plugin.ClientApplication).Client;

        // Initializes the command class.
        public AnimationPlayPauseCommand()
            : base(displayName: AnimationToolsConstants.PlayPause.Name, description: "Play/Pause animation", groupName: ActionGroups.Animation)
        {
        }

        protected override BitmapImage GetCommandImage(string actionParameter, PluginImageSize imageSize)
        {
            return PluginResources.BitmapFromEmbaddedRessource(AnimationToolsConstants.PlayPause.BitMapImageName);
        }

        protected override void RunCommand(string actionParameter)
        {
            if (Client == null) return;

            Client.KritaInstance.ExecuteAction(AnimationToolsConstants.PlayPause.ActionName).Wait();
        }
    }
}
