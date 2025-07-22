using Logi.KritaPlugin.Actions;
using Logi.KritaPlugin.DynamicFolders;
using LogiKritaApiClient.ClientBase;

namespace Logi.KritaPlugin.Constants
{
    public class AnimationToolsConstants
    {
        public static DynamicFolderAdjustmentDefinition Frame => new DynamicFolderAdjustmentDefinition("Frame sel.",
            "Logi.KritaPlugin.images.Animation.SelectFrame.png",
            AnimationFrameAdjustment.AdjustFrame);
        public static DynamicFolderAdjustmentDefinition KeyFrame => new DynamicFolderAdjustmentDefinition("Keyframe sel.",
            "Logi.KritaPlugin.images.Animation.SelectKeyFrame.png",
            AnimationKeyframeAdjustment.AdjustKeyframe);
        public static DynamicFolderCommandDefinition PlayPause => new DynamicFolderCommandDefinition("Play/Pause",
            "Logi.KritaPlugin.images.Animation.PlayPause.png",
            ActionsNames.Toggle_playback, false);
        public static DynamicFolderCommandDefinition Stop => new DynamicFolderCommandDefinition("Stop playback",
            "Logi.KritaPlugin.images.Animation.Stop.png",
            ActionsNames.Stop_playback, false);

        public static IDictionary<string, DynamicFolderActionDefinition> Tools => new Dictionary<string, DynamicFolderActionDefinition>
        {
            { Frame.Name, Frame },
            { KeyFrame.Name, KeyFrame },
            { PlayPause.Name, PlayPause },
            { Stop.Name, Stop },
        };
    }
}
