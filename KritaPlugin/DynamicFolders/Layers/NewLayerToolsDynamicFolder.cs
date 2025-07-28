using Logi.KritaPlugin.Constants;

namespace Logi.KritaPlugin.DynamicFolders
{
    public class NewLayerToolsDynamicFolder : ToolsDynamicFolderBase
    {
        public NewLayerToolsDynamicFolder()
            :base("New Layer Tools", ActionGroups.Layers, NewLayerToolsConstants.Tools, "Logi.KritaPlugin.images.Layers.LayerNewTools.png")
        {
        }
    }
}
