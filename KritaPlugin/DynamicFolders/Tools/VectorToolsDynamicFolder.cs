using Logi.KritaPlugin.Actions;
using LogiKritaApiClient.ClientBase;
using Loupedeck;

namespace Logi.KritaPlugin.DynamicFolders
{
    public class VectorToolsDynamicFolder : PluginDynamicFolder
    {
        protected Client Client => ((KritaApplication)Plugin.ClientApplication).Client;

        public VectorToolsDynamicFolder()
        {
            DisplayName = "Vector Tools";
            GroupName = "Tools";
        }

        public override BitmapImage GetButtonImage(PluginImageSize imageSize)
        {
            return PluginResources.BitmapFromEmbaddedRessource("Logi.KritaPlugin.images.Tools.ShapeEdit.png");
        }

        public override PluginDynamicFolderNavigation GetNavigationArea(DeviceType _)
        {
            return PluginDynamicFolderNavigation.ButtonArea;
        }

        public override IEnumerable<string> GetButtonPressActionNames(DeviceType _)
        {
            return ToolsConstants.VectorTools.Keys.Select(CreateCommandName).ToList();
        }

        public override BitmapImage GetCommandImage(string actionParameter, PluginImageSize imageSize)
        {
            return PluginResources.BitmapFromEmbaddedRessource(ToolsConstants.VectorTools[actionParameter].BitMapImageName);
        }

        public override void RunCommand(string actionParameter)
        {
            if (Client == null) return;

            Client.KritaInstance.ExecuteAction(ToolsConstants.VectorTools[actionParameter].ActionName).Wait();
            Close();
        }
    }
}
