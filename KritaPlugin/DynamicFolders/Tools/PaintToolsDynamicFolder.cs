using Logi.KritaPlugin.Actions;
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
            GroupName = "Tools";
        }

        public override BitmapImage GetButtonImage(PluginImageSize imageSize)
        {
            return PluginResources.BitmapFromEmbaddedRessource("Logi.KritaPlugin.images.Tools.Brush.png");
        }

        public override PluginDynamicFolderNavigation GetNavigationArea(DeviceType _)
        {
            return PluginDynamicFolderNavigation.None;
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
