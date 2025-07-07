using Logi.KritaPlugin.Constants;
using LogiKritaApiClient.ClientBase;
using Loupedeck;

namespace Logi.KritaPlugin.DynamicFolders
{
    public class SelectionToolsDynamicFolder : PluginDynamicFolder
    {
        protected Client Client => ((KritaApplication)Plugin.ClientApplication).Client;

        public SelectionToolsDynamicFolder()
        {
            DisplayName = "Selection Tools";
            GroupName = ActionGroups.Selection;
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
            return SelectionToolsConstants.Tools
                .Select(e => e.Value.ActionType == DynamicFolderActionType.Command
                    ? CreateCommandName(e.Key)
                    : CreateAdjustmentName(e.Key)).ToList();
        }

        public override BitmapImage GetCommandImage(string actionParameter, PluginImageSize imageSize)
        {
            return PluginResources.BitmapFromEmbaddedRessource(SelectionToolsConstants.Tools[actionParameter].BitMapImageName);
        }

        public override BitmapImage GetAdjustmentImage(string actionParameter, PluginImageSize imageSize)
        {
            return PluginResources.BitmapFromEmbaddedRessource(SelectionToolsConstants.Tools[actionParameter].BitMapImageName);
        }

        public override void RunCommand(string actionParameter)
        {
            if (Client == null) return;

            Client.KritaInstance.ExecuteAction(SelectionToolsConstants.Tools[actionParameter].ActionName).Wait();
            Close();
        }

        public override void ApplyAdjustment(string actionParameter, int diff)
        {
            if (Client == null) return;

            SelectionToolsConstants.Tools[actionParameter].AdjustMethod(Client, diff);
        }
    }
}
