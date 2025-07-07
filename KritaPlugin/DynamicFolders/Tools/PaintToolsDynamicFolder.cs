using Logi.KritaPlugin.Constants;
using LogiKritaApiClient.ClientBase;
using Loupedeck;

namespace Logi.KritaPlugin.DynamicFolders
{
    public class PaintToolsDynamicFolder : PluginDynamicFolder
    {
        protected Client Client => ((KritaApplication)Plugin.ClientApplication).Client;

        public PaintToolsDynamicFolder()
        {
            DisplayName = "Paint Tools";
            GroupName = ActionGroups.Tools;
        }

        public override BitmapImage GetButtonImage(PluginImageSize imageSize)
        {
            return PluginResources.BitmapFromEmbaddedRessource("Logi.KritaPlugin.images.Selection.ToolSelectFreehand.png");
        }

        public override PluginDynamicFolderNavigation GetNavigationArea(DeviceType _)
        {
            return PluginDynamicFolderNavigation.ButtonArea;
        }

        public override IEnumerable<string> GetButtonPressActionNames(DeviceType _)
        {
            return ToolsConstants.PaintTools.Keys.Select(CreateCommandName).ToList();
        }

        public override BitmapImage GetCommandImage(string actionParameter, PluginImageSize imageSize)
        {
            return PluginResources.BitmapFromEmbaddedRessource(ToolsConstants.PaintTools[actionParameter].BitMapImageName);
        }

        public override void RunCommand(string actionParameter)
        {
            if (Client == null) return;

            Client.KritaInstance.ExecuteAction(ToolsConstants.PaintTools[actionParameter].ActionName).Wait();
            Close();
        }
    }
}
