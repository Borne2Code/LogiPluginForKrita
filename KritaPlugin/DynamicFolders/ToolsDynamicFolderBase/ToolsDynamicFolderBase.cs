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
                .Select(e => (e.Value is DynamicFolderCommandDefinition)
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

            var action = ActionsList[actionParameter] as DynamicFolderCommandDefinition;

            if (action.ActionName != null)
            {
                Client.KritaInstance.ExecuteAction(action.ActionName).Wait();
            }
            else
            {
                action.Command(Client);
            }

            if (action.ShouldCloseFolder)
            {
                Close();
            }
        }

        public override void ApplyAdjustment(string actionParameter, int diff)
        {
            if (Client == null) return;

            var tool = ActionsList[actionParameter];

            if (tool is DynamicFolderAdjustmentDefinition adjustTool)
            {
                adjustTool.AdjustMethod(Client, diff);
            }
            else
            {
                (tool as DynamicFolderAdjustmentWithValueDefinition).AdjustMethodWithValue(Client, diff, () => AdjustmentValueChanged(actionParameter));
            }
        }

        public override string GetAdjustmentValue(string actionParameter)
        {
            var tool = ActionsList[actionParameter];

            if (tool is DynamicFolderAdjustmentWithValueDefinition adjustTool)
            {
                return adjustTool.GetValueMethod(Client);
            }
            else
            {
                return (tool as DynamicFolderAdjustmentDefinition).Name;
            }

            return string.Empty;
        }
    }
}
