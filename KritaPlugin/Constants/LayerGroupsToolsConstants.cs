using Logi.KritaPlugin.Actions;
using Logi.KritaPlugin.DynamicFolders;
using LogiKritaApiClient.ClientBase;

namespace Logi.KritaPlugin.Constants
{
    public class LayerGroupsToolsConstants
    {
        public static DynamicFolderAdjustmentDefinition SelectCurrent => new DynamicFolderAdjustmentDefinition("Current Layer Selector", "Logi.KritaPlugin.images.Layers.CurrentAdjust.png", LayerCurrentAdjustment.AdjustCurrentLayer);
        public static DynamicFolderCommandDefinition Isolate => new DynamicFolderCommandDefinition("Isolate Layer", "Logi.KritaPlugin.images.Layers.ToggleVisible.png", ActionsNames.Isolate_active_layer, false);
        public static DynamicFolderAdjustmentDefinition Move => new DynamicFolderAdjustmentDefinition("Move Layer", "Logi.KritaPlugin.images.Layers.Move.png", LayerMoveAdjustment.AdjustMoveLayer);
        public static DynamicFolderCommandDefinition QuickGroup => new DynamicFolderCommandDefinition("Quick group", "Logi.KritaPlugin.images.Layers.QuickGroup.png", ActionsNames.Create_quick_group);
        public static DynamicFolderCommandDefinition NewGroup => new DynamicFolderCommandDefinition("New group", "Logi.KritaPlugin.images.Layers.NewGroup.png", ActionsNames.Add_new_group_layer);
        public static DynamicFolderCommandDefinition Ungroup => new DynamicFolderCommandDefinition("Ungroup", "Logi.KritaPlugin.images.Layers.Ungroup.png", ActionsNames.Quick_ungroup);
        public static DynamicFolderCommandDefinition QuickClippingGroup => new DynamicFolderCommandDefinition("Quick clipping group", "Logi.KritaPlugin.images.Layers.QuickClippingGroup.png", ActionsNames.Create_quick_clipping_group);
        public static DynamicFolderCommandDefinition MergeWithBelow => new DynamicFolderCommandDefinition("Merge with below", "Logi.KritaPlugin.images.Layers.MergeWithBelow.png", ActionsNames.Merge_layer);
        public static DynamicFolderCommandDefinition Flatten => new DynamicFolderCommandDefinition("Flatten layer", "Logi.KritaPlugin.images.Layers.Flatten.png", ActionsNames.Flatten_layer);

        public static IDictionary<string, DynamicFolderActionDefinition> Tools => new Dictionary<string, DynamicFolderActionDefinition>
        {
            { SelectCurrent.Name, SelectCurrent },
            { Isolate.Name, Isolate },
            { Move.Name, Move },
            { QuickGroup.Name, QuickGroup },
            { NewGroup.Name, NewGroup },
            { Ungroup.Name, Ungroup },
            { QuickClippingGroup.Name, QuickClippingGroup },
            { MergeWithBelow.Name, MergeWithBelow },
            { Flatten.Name, Flatten },
        };
    }
}
