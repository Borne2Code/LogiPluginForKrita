using Loupedeck;
using LogiKritaApiClient.ClientBase;
using Logi.KritaPlugin.Constants;

namespace Logi.KritaPlugin.Actions
{
    // This class implements an example adjustment that counts the rotation ticks of a dial.

    public class AnimationInsertRightCommand : PluginDynamicCommand
    {
        private Client Client => ((KritaApplication)Plugin.ClientApplication).Client;

        // Initializes the command class.
        public AnimationInsertRightCommand()
            : base(displayName: AnimationToolsConstants.InsertFrameRight.Name, description: "Insert frame right", groupName: ActionGroups.Animation)
        {
        }

        protected override BitmapImage GetCommandImage(string actionParameter, PluginImageSize imageSize)
        {
            return PluginResources.BitmapFromEmbaddedRessource(AnimationToolsConstants.InsertFrameRight.BitMapImageName);
        }

        protected override void RunCommand(string actionParameter)
        {
            if (Client == null) return;

            Client.KritaInstance.ExecuteAction(AnimationToolsConstants.InsertFrameRight.ActionName).Wait();
        }
    }
}
