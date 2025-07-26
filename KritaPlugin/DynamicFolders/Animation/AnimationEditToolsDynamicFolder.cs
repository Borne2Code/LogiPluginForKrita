using Logi.KritaPlugin.Constants;

namespace Logi.KritaPlugin.DynamicFolders
{
    public class AnimationEditToolsDynamicFolder : ToolsDynamicFolderBase
    {
        public AnimationEditToolsDynamicFolder()
            : base("Animation Edit Tools", ActionGroups.Animation, AnimationEditToolsConstants.Tools, "Logi.KritaPlugin.images.Animation.AnimationEditTools.png")
        {
        }
    }
}
