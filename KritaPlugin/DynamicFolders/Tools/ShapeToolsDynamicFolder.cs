using Logi.KritaPlugin.Constants;

namespace Logi.KritaPlugin.DynamicFolders
{
    public class ShapeToolsDynamicFolder : ToolsDynamicFolderBase
    {
        public ShapeToolsDynamicFolder()
            : base("Shape Tools", ActionGroups.Tools, ShapeToolsConstants.Tools, "Logi.KritaPlugin.images.Tools.ShapeTools.png")
        {
        }
    }
}
