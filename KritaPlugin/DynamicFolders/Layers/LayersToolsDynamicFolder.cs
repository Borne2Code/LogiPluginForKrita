using Logi.KritaPlugin.Constants;

namespace Logi.KritaPlugin.DynamicFolders
{
    public class LayersToolsDynamicFolder : ToolsDynamicFolderBase
    {
        public LayersToolsDynamicFolder()
            :base("Layer Tools", ActionGroups.Layers, LayerToolsConstants.Tools, "Logi.KritaPlugin.images.Layers.CurrentAdjust.png")
        {
        }
    }
}
