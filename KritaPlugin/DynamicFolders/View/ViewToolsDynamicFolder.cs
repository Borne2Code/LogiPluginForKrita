using Logi.KritaPlugin.Constants;

namespace Logi.KritaPlugin.DynamicFolders
{
    public class ViewToolsDynamicFolder : ToolsDynamicFolderBase
    {
        public ViewToolsDynamicFolder()
            : base("View/Brush Tools", ActionGroups.View, ViewToolsConstants.Tools, "Logi.KritaPlugin.images.View.BrushSize.png")
        {
        }
    }
}
