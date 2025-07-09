using Logi.KritaPlugin.Actions;
using Logi.KritaPlugin.DynamicFolders;
using LogiKritaApiClient.ClientBase;

namespace Logi.KritaPlugin.Constants
{
    public class LayerToolsConstants
    {
        public static DynamicFolderAdjustmentDefinition SelectCurrent => new DynamicFolderAdjustmentDefinition("Current Layer Selector", "Logi.KritaPlugin.images.Layers.CurrentAdjust.png", LayerCurrentAdjustment.AdjustCurrentLayer);
        public static DynamicFolderAdjustmentWithValueDefinition Opacity => new DynamicFolderAdjustmentWithValueDefinition("Layer Opacity",
            "Logi.KritaPlugin.images.Layers.Opacity.png",
            LayerOpacityAdjustment.AdjustOpacity,
            LayerOpacityAdjustment.GetOpcityValue);
        public static DynamicFolderCommandDefinition Isolate => new DynamicFolderCommandDefinition("Isolate Layer", "Logi.KritaPlugin.images.Layers.ToggleVisible.png", ActionsNames.Isolate_active_layer, false);
        public static DynamicFolderActionDefinition Move => new DynamicFolderAdjustmentDefinition("Move Layer", "Logi.KritaPlugin.images.Layers.Move.png", LayerMoveAdjustment.AdjustMoveLayer);
        public static DynamicFolderCommandDefinition Style => new DynamicFolderCommandDefinition("Layer style", "Logi.KritaPlugin.images.Layers.Style.png", ActionsNames.Layer_style);
        public static DynamicFolderCommandDefinition GlobalSelection => new DynamicFolderCommandDefinition("Global selection", "Logi.KritaPlugin.images.Layers.GlobalSelection.png", LayerSelectGlobalSelecionCommand.SelectGlobalSelectionMask);
        public static DynamicFolderCommandDefinition Rename => new DynamicFolderCommandDefinition("Rename layer", "Logi.KritaPlugin.images.Layers.Rename.png", ActionsNames.RenameCurrentLayer);
        public static DynamicFolderCommandDefinition Duplicate => new DynamicFolderCommandDefinition("Duplicate Layer", "Logi.KritaPlugin.images.Layers.Duplicate.png", ActionsNames.Duplicatelayer);
        public static DynamicFolderCommandDefinition Delete => new DynamicFolderCommandDefinition("Delete Layer", "Logi.KritaPlugin.images.Layers.Delete.png", ActionsNames.Remove_layer);
        public static DynamicFolderCommandDefinition LockUnlock => new DynamicFolderCommandDefinition("Lock/Unlock Layer", "Logi.KritaPlugin.images.Layers.Lock.png", ActionsNames.Toggle_layer_lock, false);
        public static DynamicFolderCommandDefinition ToggleVisible => new DynamicFolderCommandDefinition("Toggle Layer visible", "Logi.KritaPlugin.images.Layers.ToggleVisible.png", ActionsNames.Toggle_layer_visibility, false);
        public static DynamicFolderCommandDefinition InheritAlpha => new DynamicFolderCommandDefinition("Inherit Alpha", "Logi.KritaPlugin.images.Layers.InheritAlpha.png", ActionsNames.Toggle_layer_inherit_alpha, false);
        public static DynamicFolderCommandDefinition LockAlpha => new DynamicFolderCommandDefinition("Lock Alpha", "Logi.KritaPlugin.images.Layers.LockAlpha.png", ActionsNames.Toggle_layer_alpha_lock, false);
        public static DynamicFolderCommandDefinition QuickGroup => new DynamicFolderCommandDefinition("Quick group", "Logi.KritaPlugin.images.Layers.QuickGroup.png", ActionsNames.Create_quick_group);
        public static DynamicFolderCommandDefinition NewGroup => new DynamicFolderCommandDefinition("New group", "Logi.KritaPlugin.images.Layers.NewGroup.png", ActionsNames.Add_new_group_layer);
        public static DynamicFolderCommandDefinition Ungroup => new DynamicFolderCommandDefinition("Ungroup", "Logi.KritaPlugin.images.Layers.Ungroup.png", ActionsNames.Quick_ungroup);
        public static DynamicFolderCommandDefinition QuickClippingGroup => new DynamicFolderCommandDefinition("Quick clipping group", "Logi.KritaPlugin.images.Layers.QuickClippingGroup.png", ActionsNames.Create_quick_clipping_group);
        public static DynamicFolderCommandDefinition MergeWithBelow => new DynamicFolderCommandDefinition("Merge with below", "Logi.KritaPlugin.images.Layers.MergeWithBelow.png", ActionsNames.Merge_layer);
        public static DynamicFolderCommandDefinition Flatten => new DynamicFolderCommandDefinition("Flatten layer", "Logi.KritaPlugin.images.Layers.Flatten.png", ActionsNames.Flatten_layer);

        public static IDictionary<string, DynamicFolderActionDefinition> Tools => new Dictionary<string, DynamicFolderActionDefinition>
        {
            { SelectCurrent.Name, SelectCurrent },
            { Opacity.Name, Opacity },
            { Isolate.Name, Isolate },
            { Move.Name, Move },
            { Style.Name, Style },
            { GlobalSelection.Name, GlobalSelection },
            { Rename.Name, Rename },
            { Duplicate.Name, Duplicate },
            { Delete.Name, Delete },
            { LockUnlock.Name, LockUnlock },
            { ToggleVisible.Name, ToggleVisible },
            { InheritAlpha.Name, InheritAlpha },
            { LockAlpha.Name, LockAlpha },
            { QuickGroup.Name, QuickGroup },
            { NewGroup.Name, NewGroup },
            { Ungroup.Name, Ungroup },
            { QuickClippingGroup.Name, QuickClippingGroup },
            { MergeWithBelow.Name, MergeWithBelow },
            { Flatten.Name, Flatten },
        };
    }
}
