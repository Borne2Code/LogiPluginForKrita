using Logi.KritaPlugin.DynamicFolders;
using LogiKritaApiClient.ClientBase;

namespace Logi.KritaPlugin.Constants
{
    public class NewLayerToolsConstants
    {
        public static DynamicFolderCommandDefinition PaintLayer => new DynamicFolderCommandDefinition("New paint layer", "Logi.KritaPlugin.images.Layers.NewRaster.png", ActionsNames.Add_new_paint_layer);
        public static DynamicFolderCommandDefinition VectorLayer => new DynamicFolderCommandDefinition("New vector layer", "Logi.KritaPlugin.images.Layers.NewVector.png", ActionsNames.Add_new_shape_layer);
        public static DynamicFolderCommandDefinition FillLayer => new DynamicFolderCommandDefinition("New fill layer", "Logi.KritaPlugin.images.Layers.NewFill.png", ActionsNames.Add_new_fill_layer);
        public static DynamicFolderCommandDefinition FilterLayer => new DynamicFolderCommandDefinition("New filter layer", "Logi.KritaPlugin.images.Layers.NewFilter.png", ActionsNames.Add_new_adjustment_layer);
        public static DynamicFolderCommandDefinition TransparencyMask => new DynamicFolderCommandDefinition("New transparency mask", "Logi.KritaPlugin.images.Layers.NewTransparency.png", ActionsNames.Add_new_transparency_mask);
        public static DynamicFolderCommandDefinition FilterMask => new DynamicFolderCommandDefinition("New filter mask", "Logi.KritaPlugin.images.Layers.NewFilterMask.png", ActionsNames.Add_new_filter_mask);
        public static DynamicFolderCommandDefinition TransformMask => new DynamicFolderCommandDefinition("New transform mask", "Logi.KritaPlugin.images.Layers.NewTransform.png", ActionsNames.Add_new_transform_mask);
        public static DynamicFolderCommandDefinition CloneLayer => new DynamicFolderCommandDefinition("New clone layer", "Logi.KritaPlugin.images.Layers.NewClone.png", ActionsNames.Add_new_clone_layer);
        public static DynamicFolderCommandDefinition FileLayer => new DynamicFolderCommandDefinition("New file layer", "Logi.KritaPlugin.images.Layers.NewFile.png", ActionsNames.Add_new_file_layer);
        public static DynamicFolderCommandDefinition ColorizeMask => new DynamicFolderCommandDefinition("New colorize mask", "Logi.KritaPlugin.images.Layers.NewColorize.png", ActionsNames.Add_new_colorize_mask);
        public static DynamicFolderCommandDefinition NewLocalSelection => new DynamicFolderCommandDefinition("New local selection", "Logi.KritaPlugin.images.Layers.NewSelection.png", ActionsNames.Add_new_selection_mask);

        public static IDictionary<string, DynamicFolderActionDefinition> Tools => new Dictionary<string, DynamicFolderActionDefinition>
        {
            { PaintLayer.Name, PaintLayer },
            { VectorLayer.Name, VectorLayer },
            { FillLayer.Name, FillLayer },
            { FilterLayer.Name, FilterLayer },
            { TransparencyMask.Name, TransparencyMask },
            { FilterMask.Name, FilterMask },
            { TransformMask.Name, TransformMask },
            { CloneLayer.Name, CloneLayer },
            { FileLayer.Name, FileLayer },
            { ColorizeMask.Name, ColorizeMask },
            { NewLocalSelection.Name, NewLocalSelection },
        };
    }
}
