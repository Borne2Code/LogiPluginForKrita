using Logi.KritaPlugin.Actions;
using Logi.KritaPlugin.DynamicFolders;
using LogiKritaApiClient.ClientBase;

namespace Logi.KritaPlugin.Constants
{
    public class LayerGroupsToolsConstants
    {
        public static IDictionary<string, DynamicFolderActionDefinition> Tools => new Dictionary<string, DynamicFolderActionDefinition>
        {
            { LayerToolsConstants.SelectCurrent.Name, LayerToolsConstants.SelectCurrent },
            { LayerToolsConstants.Move.Name, LayerToolsConstants.Move },
            { LayerToolsConstants.Isolate.Name, LayerToolsConstants.Isolate },
            { LayerToolsConstants.QuickGroup.Name, LayerToolsConstants.QuickGroup },
            { LayerToolsConstants.NewGroup.Name, LayerToolsConstants.NewGroup },
            { LayerToolsConstants.Ungroup.Name, LayerToolsConstants.Ungroup },
            { LayerToolsConstants.QuickClippingGroup.Name, LayerToolsConstants.QuickClippingGroup },
            { LayerToolsConstants.MergeWithBelow.Name, LayerToolsConstants.MergeWithBelow },
            { LayerToolsConstants.Flatten.Name, LayerToolsConstants.Flatten },
        };
    }
}
