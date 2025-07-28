using Logi.KritaPlugin.Constants;

namespace Logi.KritaPlugin.DynamicFolders
{
    public class TransformToolsDynamicFolder : ToolsDynamicFolderBase
    {
        public TransformToolsDynamicFolder()
            : base("Transform Tools", ActionGroups.Tools, TransformToolsConstants.Tools, "Logi.KritaPlugin.images.Tools.TransformTools.png")
        {
        }
    }
}
