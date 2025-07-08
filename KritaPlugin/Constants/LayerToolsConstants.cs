using Logi.KritaPlugin.Actions;
using LogiKritaApiClient.ClientBase;

namespace Logi.KritaPlugin.Constants
{
    public class LayerToolsConstants
    {
        public static DynamicFolderActionDefinition SelectCurrent => new DynamicFolderActionDefinition("Current Layer Selector", "Logi.KritaPlugin.images.Layers.CurrentAdjust.png", LayerCurrentAdjustment.AdjustCurrentLayer);
        public static DynamicFolderActionDefinition Opacity => new DynamicFolderActionDefinition("Layer Opacity",
            "Logi.KritaPlugin.images.Layers.Opacity.png",
            LayerOpacityAdjustment.AdjustOpacity,
            LayerOpacityAdjustment.GetOpcityValue,
            LayerOpacityAdjustment.GetMinOpacity,
            LayerOpacityAdjustment.GetMaxOpacity);
        public static DynamicFolderActionDefinition Isolate => new DynamicFolderActionDefinition("Isolate Layer", "Logi.KritaPlugin.images.Layers.ToggleVisible.png", ActionsNames.Isolate_active_layer);
        public static DynamicFolderActionDefinition Style => new DynamicFolderActionDefinition("Layer style", "Logi.KritaPlugin.images.Layers.Style.png", ActionsNames.Layer_style);
        public static DynamicFolderActionDefinition Rename => new DynamicFolderActionDefinition("Rename layer", "Logi.KritaPlugin.images.Layers.Rename.png", ActionsNames.RenameCurrentLayer);
        public static DynamicFolderActionDefinition Duplicate => new DynamicFolderActionDefinition("Duplicate Layer", "Logi.KritaPlugin.images.Layers.Duplicate.png", ActionsNames.Duplicatelayer);
        public static DynamicFolderActionDefinition Delete => new DynamicFolderActionDefinition("Delete Layer", "Logi.KritaPlugin.images.Layers.Delete.png", ActionsNames.Remove_layer);
        public static DynamicFolderActionDefinition LockUnlock => new DynamicFolderActionDefinition("Lock/Unlock Layer", "Logi.KritaPlugin.images.Layers.Lock.png", ActionsNames.Toggle_layer_lock);
        public static DynamicFolderActionDefinition ToggleVisible => new DynamicFolderActionDefinition("Toggle Layer visible", "Logi.KritaPlugin.images.Layers.ToggleVisible.png", ActionsNames.Toggle_layer_visibility);
        public static DynamicFolderActionDefinition InheritAlpha => new DynamicFolderActionDefinition("Inherit Alpha", "Logi.KritaPlugin.images.Layers.InheritAlpha.png", ActionsNames.Toggle_layer_inherit_alpha);
        public static DynamicFolderActionDefinition LockAlpha => new DynamicFolderActionDefinition("Lock Alpha", "Logi.KritaPlugin.images.Layers.LockAlpha.png", ActionsNames.Toggle_layer_alpha_lock);
        public static DynamicFolderActionDefinition QuickGroup => new DynamicFolderActionDefinition("Quick group", "Logi.KritaPlugin.images.Layers.QuickGroup.png", ActionsNames.Create_quick_group);
        public static DynamicFolderActionDefinition NewGroup => new DynamicFolderActionDefinition("New group", "Logi.KritaPlugin.images.Layers.NewGroup.png", ActionsNames.Add_new_group_layer);
        public static DynamicFolderActionDefinition Ungroup => new DynamicFolderActionDefinition("Ungroup", "Logi.KritaPlugin.images.Layers.Ungroup.png", ActionsNames.Quick_ungroup);
        public static DynamicFolderActionDefinition QuickClippingGroup => new DynamicFolderActionDefinition("Quick clipping group", "Logi.KritaPlugin.images.Layers.QuickClippingGroup.png", ActionsNames.Create_quick_clipping_group);
        public static DynamicFolderActionDefinition MergeWithBelow => new DynamicFolderActionDefinition("Merge with below", "Logi.KritaPlugin.images.Layers.MergeWithBelow.png", ActionsNames.Merge_layer);
        public static DynamicFolderActionDefinition Flatten => new DynamicFolderActionDefinition("Flatten layer", "Logi.KritaPlugin.images.Layers.Flatten.png", ActionsNames.Flatten_layer);
        public static DynamicFolderActionDefinition Move => new DynamicFolderActionDefinition("Move Layer", "Logi.KritaPlugin.images.Layers.Move.png", LayerMoveAdjustment.AdjustMoveLayer);

        public static IDictionary<string, DynamicFolderActionDefinition> Tools => new Dictionary<string, DynamicFolderActionDefinition>
        {
            { SelectCurrent.Name, SelectCurrent },
            { Opacity.Name, Opacity },
            { Isolate.Name, Isolate },
            { Style.Name, Style },
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
            { Move.Name, Move },
        };
    }
}
