using Logi.KritaPlugin.Constants;

namespace Logi.KritaPlugin.DynamicFolders
{
    public class PaintToolsDynamicFolder : ToolsDynamicFolderBase
    {
        public PaintToolsDynamicFolder()
            : base("Paint Tools", ActionGroups.Tools, PaintToolsConstants.Tools, "Logi.KritaPlugin.images.Tools.Brush.png")
        {
        }
    }
}
