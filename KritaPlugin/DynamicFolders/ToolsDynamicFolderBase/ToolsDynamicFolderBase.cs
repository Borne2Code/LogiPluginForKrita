using Logi.KritaPlugin.Constants;
using LogiKritaApiClient.ClientBase;
using Loupedeck;

namespace Logi.KritaPlugin.DynamicFolders
{
    public class ToolsDynamicFolderBase : PluginDynamicFolder
    {
        protected Client Client => ((KritaApplication)Plugin.ClientApplication).Client;
        private IDictionary<string, DynamicFolderActionDefinition> ActionsList;
        private string IconResourceName;

        public ToolsDynamicFolderBase(string displayName, string groupeName, IDictionary<string, DynamicFolderActionDefinition> actionsList, string iconResourceName)
        {
            DisplayName = displayName;
            GroupName = groupeName;
            ActionsList = actionsList;
            IconResourceName = iconResourceName;
        }

        public override BitmapImage GetButtonImage(PluginImageSize imageSize)
        {
            return PluginResources.BitmapFromEmbaddedRessource(IconResourceName);
        }

        public override PluginDynamicFolderNavigation GetNavigationArea(DeviceType _)
        {
            return PluginDynamicFolderNavigation.ButtonArea;
        }

        public override IEnumerable<string> GetButtonPressActionNames(DeviceType _)
        {
            return ActionsList
                .Select(e => e.Value.ActionType == DynamicFolderActionType.Command
                    ? CreateCommandName(e.Key)
                    : CreateAdjustmentName(e.Key)).ToList();
        }

        public override BitmapImage GetCommandImage(string actionParameter, PluginImageSize imageSize)
        {
            return PluginResources.BitmapFromEmbaddedRessource(ActionsList[actionParameter].BitMapImageName);
        }

        public override BitmapImage GetAdjustmentImage(string actionParameter, PluginImageSize imageSize)
        {
            return PluginResources.BitmapFromEmbaddedRessource(ActionsList[actionParameter].BitMapImageName);
        }

        public override string GetAdjustmentDisplayName(string actionParameter, PluginImageSize imageSize)
        {
            return ActionsList[actionParameter].Name;
        }

        public override void RunCommand(string actionParameter)
        {
            if (Client == null) return;

            var action = ActionsList[actionParameter];
            Client.KritaInstance.ExecuteAction(action.ActionName).Wait();
            if (action.ShouldCloseFolder)
            {
                Close();
            }
        }

        public override void ApplyAdjustment(string actionParameter, int diff)
        {
            if (Client == null) return;

            var tool = ActionsList[actionParameter];

            if (tool.ActionType == DynamicFolderActionType.Encoder)
            {
                tool.AdjustMethod(Client, diff);
            }
            else
            {
                tool.AdjustMethodWithValue(Client, diff, () => AdjustmentValueChanged(actionParameter));
            }
        }

        public override string GetAdjustmentValue(string actionParameter)
        {
            var tool = ActionsList[actionParameter];

            if (tool.ActionType == DynamicFolderActionType.EncoderWithValue)
            {
                return tool.GetValueMethod(Client);
            }

            return string.Empty;
        }
    }
}
