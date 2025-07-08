using Logi.KritaPlugin.Constants;

namespace Logi.KritaPlugin.DynamicFolders
{
    public class SelectionToolsDynamicFolder : ToolsDynamicFolderBase
    {
        public SelectionToolsDynamicFolder()
            : base("Selection Tools", ActionGroups.Selection, SelectionToolsConstants.Tools, "Logi.KritaPlugin.images.Selection.ToolSelectFreehand.png")
        {
        }
    }
}
