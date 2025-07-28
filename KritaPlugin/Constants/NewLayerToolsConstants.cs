using Logi.KritaPlugin.Actions;
using Logi.KritaPlugin.DynamicFolders;
using LogiKritaApiClient.ClientBase;

namespace Logi.KritaPlugin.Constants
{
    public class NewLayerToolsConstants
    {
        public static DynamicFolderCommandDefinition PaintLayer => new DynamicFolderCommandDefinition("Raster layer", "Logi.KritaPlugin.images.Layers.NewRaster.png", ActionsNames.Add_new_paint_layer);
        public static DynamicFolderCommandDefinition VectorLayer => new DynamicFolderCommandDefinition("Vector layer", "Logi.KritaPlugin.images.Layers.NewVector.png", ActionsNames.Add_new_shape_layer);
        public static DynamicFolderCommandDefinition FillLayer => new DynamicFolderCommandDefinition("Fill layer", "Logi.KritaPlugin.images.Layers.NewFill.png", ActionsNames.Add_new_fill_layer);
        public static DynamicFolderCommandDefinition FilterLayer => new DynamicFolderCommandDefinition("Filter layer", "Logi.KritaPlugin.images.Layers.NewFilter.png", ActionsNames.Add_new_adjustment_layer);
        public static DynamicFolderCommandDefinition FilterMask => new DynamicFolderCommandDefinition("Filter mask", "Logi.KritaPlugin.images.Layers.NewFilterMask.png", ActionsNames.Add_new_filter_mask);
        public static DynamicFolderCommandDefinition TransparencyMask => new DynamicFolderCommandDefinition("Transparency mask", "Logi.KritaPlugin.images.Layers.NewTransparency.png", ActionsNames.Add_new_transparency_mask);
        public static DynamicFolderCommandDefinition TransformMask => new DynamicFolderCommandDefinition("Transform mask", "Logi.KritaPlugin.images.Layers.NewTransform.png", ActionsNames.Add_new_transform_mask);
        public static DynamicFolderCommandDefinition CloneLayer => new DynamicFolderCommandDefinition("Clone layer", "Logi.KritaPlugin.images.Layers.NewClone.png", ActionsNames.Add_new_clone_layer);
        public static DynamicFolderCommandDefinition FileLayer => new DynamicFolderCommandDefinition("File layer", "Logi.KritaPlugin.images.Layers.NewFile.png", ActionsNames.Add_new_file_layer);
        public static DynamicFolderCommandDefinition ColorizeMask => new DynamicFolderCommandDefinition("Colorize mask", "Logi.KritaPlugin.images.Layers.NewColorize.png", ActionsNames.Add_new_colorize_mask);
        public static DynamicFolderCommandDefinition NewLocalSelection => new DynamicFolderCommandDefinition("Local selection", "Logi.KritaPlugin.images.Layers.NewSelection.png", ActionsNames.Add_new_selection_mask);

        public static IDictionary<string, DynamicFolderActionDefinition> Tools => new Dictionary<string, DynamicFolderActionDefinition>
        {
            { LayerToolsConstants.SelectCurrent.Name, LayerToolsConstants.SelectCurrent },
            { LayerToolsConstants.Move.Name, LayerToolsConstants.Move },
            { PaintLayer.Name, PaintLayer },
            { VectorLayer.Name, VectorLayer },
            { FillLayer.Name, FillLayer },
            { FilterLayer.Name, FilterLayer },
            { FilterMask.Name, FilterMask },
            { TransparencyMask.Name, TransparencyMask },
            { TransformMask.Name, TransformMask },
            { CloneLayer.Name, CloneLayer },
            { FileLayer.Name, FileLayer },
            { ColorizeMask.Name, ColorizeMask },
            { NewLocalSelection.Name, NewLocalSelection },
        };
    }
}
