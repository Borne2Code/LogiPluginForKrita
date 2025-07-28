using Logi.KritaPlugin.DynamicFolders;

namespace Logi.KritaPlugin.Constants
{
    public class AnimationEditToolsConstants
    {
        public static IDictionary<string, DynamicFolderActionDefinition> Tools => new Dictionary<string, DynamicFolderActionDefinition>
        {
            { AnimationToolsConstants.Frame.Name , AnimationToolsConstants.Frame },
            { AnimationToolsConstants.KeyFrame.Name , AnimationToolsConstants.KeyFrame },
            { LayerToolsConstants.SelectCurrent.Name, LayerToolsConstants.SelectCurrent },
            { AnimationToolsConstants.HoldFrames.Name , AnimationToolsConstants.HoldFrames },
            { AnimationToolsConstants.HoldColumns.Name , AnimationToolsConstants.HoldColumns },
            { AnimationToolsConstants.CreateBlank.Name, AnimationToolsConstants.CreateBlank },
            { AnimationToolsConstants.CreateDuplicate.Name, AnimationToolsConstants.CreateDuplicate },
            { AnimationToolsConstants.InsertFrameLeft.Name, AnimationToolsConstants.InsertFrameLeft },
            { AnimationToolsConstants.InsertFrameRight.Name, AnimationToolsConstants.InsertFrameRight },
            { AnimationToolsConstants.RemoveKeyFrame.Name , AnimationToolsConstants.RemoveKeyFrame },
            { AnimationToolsConstants.RemoveKeyFramePull.Name , AnimationToolsConstants.RemoveKeyFramePull },
            { AnimationToolsConstants.Copy.Name, AnimationToolsConstants.Copy },
            { AnimationToolsConstants.Cut.Name, AnimationToolsConstants.Cut },
            { AnimationToolsConstants.Paste.Name, AnimationToolsConstants.Paste },
        };
    }
}
