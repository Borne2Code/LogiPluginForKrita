using LoupedeckKritaApiClient;
using LoupedeckKritaApiClient.FiltersDialogs;

namespace Loupedeck.KritaPlugin.DynamicFolders
{
    public class ColorsBalance: PluginDynamicFolder
    {
        private KritaPlugin KritaPlugin => (KritaPlugin)Plugin;

        private KritaFilterColorBalance dialog;

        private const string ShadowsCyanRed = "Shadows Cyan/Red";
        private const string ShadowsMagentaGreen = "Shadows Magenta/Green";
        private const string ShadowsYellowBlue = "Shadows Yellow/Blue";
        private const string ResetShadows = "Reset Shadows";

        private const string MidtonesCyanRed = "Midtones Cyan/Red";
        private const string MidtonesMagentaGreen = "Midtones Magenta/Green";
        private const string MidtonesYellowBlue = "Midtones Yellow/Blue";
        private const string ResetMidtones = "Reset Midtones";

        private const string HighlightsCyanRed = "Highlights Cyan/Red";
        private const string HighlightsMagentaGreen = "Highlights Magenta/Green";
        private const string HighlightsYellowBlue = "Highlights Yellow/Blue";
        private const string ResetHighlights = "Reset Highlights";

        private const string PreserveLuminosity = "Preserve Luminosity";

        private int ShadowsCyanRedValue = 0;
        private int ShadowsMagentaGreenValue = 0;
        private int ShadowsYellowBlueValue = 0;
        private int MidtonesCyanRedValue = 0;
        private int MidtonesMagentaGreenValue = 0;
        private int MidtonesYellowBlueValue = 0;
        private int HighlightsCyanRedValue = 0;
        private int HighlightsMagentaGreenValue = 0;
        private int HighlightsYellowBlueValue = 0;

        public ColorsBalance() 
        {
            this.DisplayName = "Colors adjustment";
            this.GroupName = ActionGroups.Filters;
        }

        public override PluginDynamicFolderNavigation GetNavigationArea(DeviceType _)
        {
            return PluginDynamicFolderNavigation.ButtonArea;
        }

        public override bool Activate()
        {
            dialog = (KritaFilterColorBalance)(Filter.GetFilterDialog(KritaPlugin.Client, FiltersEnum.ColorBalance).Result);
            ShadowsCyanRedValue = 0;
            ShadowsMagentaGreenValue = 0;
            ShadowsYellowBlueValue = 0;
            MidtonesCyanRedValue = 0;
            MidtonesMagentaGreenValue = 0;
            MidtonesYellowBlueValue = 0;
            HighlightsCyanRedValue = 0;
            HighlightsMagentaGreenValue = 0;
            HighlightsYellowBlueValue = 0;
            return true;
        }

        public override bool Deactivate()
        {
            dialog.DisposeAsync().AsTask().Wait();
            return true;
        }

        public override IEnumerable<string> GetButtonPressActionNames(DeviceType _)
        {
            return new[]
            {
                this.CreateCommandName(ResetShadows),
                this.CreateCommandName(ResetMidtones),
                this.CreateCommandName(ResetHighlights),
                string.Empty,
                string.Empty,
                string.Empty,
                string.Empty,
                string.Empty,
                string.Empty,
                string.Empty,
                this.CreateCommandName(PreserveLuminosity),
            };
        }

        public override IEnumerable<string> GetEncoderRotateActionNames(DeviceType _)
        {
            //dialog.AdjustShadowsCyanRedValue();
            return new[] {
                base.CreateAdjustmentName(ShadowsCyanRed),
                base.CreateAdjustmentName(ShadowsMagentaGreen),
                base.CreateAdjustmentName(ShadowsYellowBlue),
                base.CreateAdjustmentName(MidtonesCyanRed),
                base.CreateAdjustmentName(MidtonesMagentaGreen),
                base.CreateAdjustmentName(MidtonesYellowBlue),
                base.CreateAdjustmentName(MidtonesCyanRed),
                base.CreateAdjustmentName(MidtonesMagentaGreen),
                base.CreateAdjustmentName(MidtonesYellowBlue),
                base.CreateAdjustmentName(HighlightsCyanRed),
                base.CreateAdjustmentName(HighlightsMagentaGreen),
                base.CreateAdjustmentName(HighlightsYellowBlue),
            };
        }

        public override void ApplyAdjustment(string actionParameter, int diff)
        {
            switch(actionParameter)
            {
                case ShadowsCyanRed:
                    ShadowsCyanRedValue = dialog.AdjustShadowsCyanRedValue(diff).Result;
                    this.AdjustmentValueChanged(actionParameter);
                    break;
                case ShadowsMagentaGreen:
                    ShadowsMagentaGreenValue = dialog.AdjustShadowsMagentaGreenValue(diff).Result;
                    this.AdjustmentValueChanged(actionParameter);
                    break;

                case ShadowsYellowBlue:
                    ShadowsYellowBlueValue = dialog.AdjustShadowsYellowBlueValue(diff).Result;
                    this.AdjustmentValueChanged(actionParameter);
                    break;
                case MidtonesCyanRed:
                    MidtonesCyanRedValue = dialog.AdjustMidTonesCyanRedValue(diff).Result;
                    this.AdjustmentValueChanged(actionParameter);
                    break;
                case MidtonesMagentaGreen:
                    MidtonesMagentaGreenValue = dialog.AdjustMidTonesMagentaGreenValue(diff).Result;
                    this.AdjustmentValueChanged(actionParameter);
                    break;

                case MidtonesYellowBlue:
                    MidtonesYellowBlueValue = dialog.AdjustMidTonesYellowBlueValue(diff).Result;
                    this.AdjustmentValueChanged(actionParameter);
                    break;
                case HighlightsCyanRed:
                    HighlightsCyanRedValue = dialog.AdjustHighLightsCyanRedValue(diff).Result;
                    this.AdjustmentValueChanged(actionParameter);
                    break;
                case HighlightsMagentaGreen:
                    HighlightsMagentaGreenValue = dialog.AdjustHighLightsMagentaGreenValue(diff).Result;
                    this.AdjustmentValueChanged(actionParameter);
                    break;

                case HighlightsYellowBlue:
                    HighlightsYellowBlueValue = dialog.AdjustHighLightsYellowBlueValue(diff).Result;
                    this.AdjustmentValueChanged(actionParameter);
                    break;
                default:
                    break;
            }
        }

        public override void RunCommand(string actionParameter)
        {
            switch(actionParameter)
            {
                case ResetShadows:
                    dialog.ResetShadows();
                    ShadowsCyanRedValue = 0;
                    ShadowsMagentaGreenValue = 0;
                    ShadowsYellowBlueValue = 0;
                    this.AdjustmentValueChanged(ShadowsCyanRed);
                    this.AdjustmentValueChanged(ShadowsMagentaGreen);
                    this.AdjustmentValueChanged(ShadowsYellowBlue);
                    break;
                case ResetMidtones:
                    dialog.ResetMidTones();
                    MidtonesCyanRedValue = 0;
                    MidtonesMagentaGreenValue = 0;
                    MidtonesYellowBlueValue = 0;
                    this.AdjustmentValueChanged(MidtonesCyanRed);
                    this.AdjustmentValueChanged(MidtonesMagentaGreen);
                    this.AdjustmentValueChanged(MidtonesYellowBlue);
                    break;
                case ResetHighlights:
                    dialog.ResetHighLights();
                    HighlightsCyanRedValue = 0;
                    HighlightsMagentaGreenValue = 0;
                    HighlightsYellowBlueValue = 0;
                    this.AdjustmentValueChanged(HighlightsCyanRed);
                    this.AdjustmentValueChanged(HighlightsMagentaGreen);
                    this.AdjustmentValueChanged(HighlightsYellowBlue);
                    break;
                case PreserveLuminosity:
                    dialog.TogglePreserveLuminosity();
                    break;
                default:
                    break;
            }
        }

        public override string GetAdjustmentValue(string actionParameter)
        {
            switch (actionParameter)
            {
                case ShadowsCyanRed:
                    return ShadowsCyanRedValue.ToString();
                case ShadowsMagentaGreen:
                    return ShadowsMagentaGreenValue.ToString();
                case ShadowsYellowBlue:
                    return ShadowsYellowBlueValue.ToString();
                case MidtonesCyanRed:
                    return MidtonesCyanRedValue.ToString();
                case MidtonesMagentaGreen:
                    return MidtonesMagentaGreenValue.ToString();
                case MidtonesYellowBlue:
                    return MidtonesYellowBlueValue.ToString();
                case HighlightsCyanRed:
                    return HighlightsCyanRedValue.ToString();
                case HighlightsMagentaGreen:
                    return HighlightsMagentaGreenValue.ToString();
                case HighlightsYellowBlue:
                    return HighlightsYellowBlueValue.ToString();
                default:
                    return string.Empty;
            }
        }
    }
}
