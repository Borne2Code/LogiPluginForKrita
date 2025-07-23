using Logi.KritaPlugin.Constants;

namespace Logi.KritaPlugin.DynamicFolders
{
    public class SelectionModeToolsDynamicFolder : ToolsDynamicFolderBase
    {
        public SelectionModeToolsDynamicFolder()
            : base("Selection mode Tools", ActionGroups.Selection, SelectionModeToolsConstants.Tools, "Logi.KritaPlugin.images.Selection.ModeSubstract.png")
        {
        }
    }
}
