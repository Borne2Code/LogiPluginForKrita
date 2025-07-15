using Logi.KritaPlugin.Constants;

namespace Logi.KritaPlugin.DynamicFolders
{
    public class EditToolsDynamicFolder : ToolsDynamicFolderBase
    {
        public EditToolsDynamicFolder()
            :base("Edit Tools", ActionGroups.Edit, EditToolsConstants.Tools, "Logi.KritaPlugin.images.Layers.EditTools.png")
        {
        }
    }
}
