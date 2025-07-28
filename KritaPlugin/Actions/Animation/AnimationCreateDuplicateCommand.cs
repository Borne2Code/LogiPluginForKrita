using Loupedeck;
using LogiKritaApiClient.ClientBase;
using Logi.KritaPlugin.Constants;

namespace Logi.KritaPlugin.Actions
{
    // This class implements an example adjustment that counts the rotation ticks of a dial.

    public class AnimationCreateDuplicateCommand : PluginDynamicCommand
    {
        private Client Client => ((KritaApplication)Plugin.ClientApplication).Client;

        // Initializes the command class.
        public AnimationCreateDuplicateCommand()
            : base(displayName: AnimationToolsConstants.CreateDuplicate.Name, description: "Create duplicate frame", groupName: ActionGroups.Animation)
        {
        }

        protected override BitmapImage GetCommandImage(string actionParameter, PluginImageSize imageSize)
        {
            return PluginResources.BitmapFromEmbaddedRessource(AnimationToolsConstants.CreateDuplicate.BitMapImageName);
        }

        protected override void RunCommand(string actionParameter)
        {
            if (Client == null) return;

            Client.KritaInstance.ExecuteAction(AnimationToolsConstants.CreateDuplicate.ActionName).Wait();
        }
    }
}
