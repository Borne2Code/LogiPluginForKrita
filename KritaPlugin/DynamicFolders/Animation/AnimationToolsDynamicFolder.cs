using Logi.KritaPlugin.Constants;

namespace Logi.KritaPlugin.DynamicFolders
{
    public class AnimationToolsDynamicFolder : ToolsDynamicFolderBase
    {
        public AnimationToolsDynamicFolder()
            : base("Animation Tools", ActionGroups.Animation, AnimationToolsConstants.Tools, "Logi.KritaPlugin.images.Animation.AnimationTools.png")
        {
        }
    }
}
