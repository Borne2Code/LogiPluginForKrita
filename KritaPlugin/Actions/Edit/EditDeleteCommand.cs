using Logi.KritaPlugin.Constants;
using Loupedeck;

namespace Logi.KritaPlugin.Actions
{
    // This class implements an example adjustment that counts the rotation ticks of a dial.

    public class EditDeleteCommand : PluginDynamicCommand
    {
        // Initializes the command class.
        public EditDeleteCommand()
            : base(displayName: EditToolsConstants.Delete.Name, description: "Delete selection/content", groupName: ActionGroups.Edit)
        {
        }

        protected override BitmapImage GetCommandImage(string actionParameter, PluginImageSize imageSize)
        {
            return PluginResources.BitmapFromEmbaddedRessource(EditToolsConstants.Delete.BitMapImageName);
        }

        protected override void RunCommand(string actionParameter)
        {
            Plugin.ClientApplication.SendKeyboardShortcut(EditToolsConstants.Delete.ShortCut.Value);
        }
    }
}
