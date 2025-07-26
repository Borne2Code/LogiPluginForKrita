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
        public static DynamicFolderCommandDefinition OnionSkin => new DynamicFolderCommandDefinition("Onion skin",
            "Logi.KritaPlugin.images.Animation.OnionSkin.png",
            ActionsNames.Toggle_onion_skin, false);
        public static DynamicFolderCommandDefinition PinTimeline => new DynamicFolderCommandDefinition("Pin to timeline",
            "Logi.KritaPlugin.images.Animation.PinTimeline.png",
            ActionsNames.Pin_to_timeline, false);
        public static DynamicFolderCommandDefinition CreateBlank => new DynamicFolderCommandDefinition("Create blank frame",
            "Logi.KritaPlugin.images.Animation.CreateBlank.png",
            ActionsNames.Add_blank_frame, false);
        public static DynamicFolderCommandDefinition CreateDuplicate => new DynamicFolderCommandDefinition("Create duplicate frame",
            "Logi.KritaPlugin.images.Animation.CreateDuplicate.png",
            ActionsNames.Add_duplicate_frame, false);
        public static DynamicFolderCommandDefinition InsertFrameLeft => new DynamicFolderCommandDefinition("Insert frame left",
            "Logi.KritaPlugin.images.Animation.InsertLeft.png",
            ActionsNames.Insert_keyframe_left, false);
        public static DynamicFolderCommandDefinition InsertFrameRight => new DynamicFolderCommandDefinition("Insert frame right",
            "Logi.KritaPlugin.images.Animation.InsertRight.png",
            ActionsNames.Insert_keyframe_right, false);
        public static DynamicFolderAdjustmentDefinition HoldFrames => new DynamicFolderAdjustmentDefinition("+/- Hold frame",
            "Logi.KritaPlugin.images.Animation.HoldFrame.png",
            AnimationHoldFramesAdjustment.AddRemoveHoldFrame);
        public static DynamicFolderAdjustmentDefinition HoldColumns => new DynamicFolderAdjustmentDefinition("+/- Hold column",
            "Logi.KritaPlugin.images.Animation.HoldColumn.png",
            AnimationHoldColumnsAdjustment.AddRemoveHoldColumn);
        public static DynamicFolderCommandDefinition RemoveKeyFrame => new DynamicFolderCommandDefinition("Remove frame",
            "Logi.KritaPlugin.images.Animation.RemoveFrame.png",
            ActionsNames.Remove_frames, false);
        public static DynamicFolderCommandDefinition RemoveKeyFramePull => new DynamicFolderCommandDefinition("Remove frame and pull",
            "Logi.KritaPlugin.images.Animation.RemoveFramePull.png",
            ActionsNames.Remove_frames_and_pull, false);
        public static DynamicFolderCommandDefinition Copy => new DynamicFolderCommandDefinition("Copy frame",
             "Logi.KritaPlugin.images.Animation.Copy.png",
             ActionsNames.Copy_frames, false);
        public static DynamicFolderCommandDefinition Cut => new DynamicFolderCommandDefinition("Cut frame",
             "Logi.KritaPlugin.images.Animation.Cut.png",
             ActionsNames.Cut_frames, false);
        public static DynamicFolderCommandDefinition Paste => new DynamicFolderCommandDefinition("Paste frame",
             "Logi.KritaPlugin.images.Animation.Paste.png",
             ActionsNames.Paste_frames, false);

        public static IDictionary<string, DynamicFolderActionDefinition> Tools => new Dictionary<string, DynamicFolderActionDefinition>
        {
            { Frame.Name, Frame },
            { KeyFrame.Name, KeyFrame },
            { LayerToolsConstants.SelectCurrent.Name, LayerToolsConstants.SelectCurrent },
            { PlayPause.Name, PlayPause },
            { Stop.Name, Stop },
            { OnionSkin.Name, OnionSkin },
            { PinTimeline.Name, PinTimeline },
            { CreateBlank.Name, CreateBlank },
            { CreateDuplicate.Name, CreateDuplicate },
            { InsertFrameLeft.Name, InsertFrameLeft },
            { InsertFrameRight.Name, InsertFrameRight },
            { HoldFrames.Name, HoldFrames },
            { HoldColumns.Name, HoldColumns },
            { RemoveKeyFrame.Name, RemoveKeyFrame },
            { RemoveKeyFramePull.Name, RemoveKeyFramePull },
            { Copy.Name, Copy },
            { Cut.Name, Cut },
            { Paste.Name, Paste },
        };
    }
}
