using Logi.KritaPlugin.Constants;

namespace Logi.KritaPlugin.DynamicFolders
{
    public class LayerGroupsToolsDynamicFolder : ToolsDynamicFolderBase
    {
        public LayerGroupsToolsDynamicFolder()
            :base("Groups Tools", ActionGroups.Layers, LayerGroupsToolsConstants.Tools, "Logi.KritaPlugin.images.Layers.NewGroup.png")
        {
        }
    }
}
