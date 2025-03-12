using LoupedeckKritaApiClient.ClientBase;

namespace LoupedeckKritaApiClient.FiltersDialogs
{
    public class KritaFilterColorBalance(Client client) : FilterDialogBase(client)
    {
        internal override string ActionName => "krita_filter_colorbalance";

        public Task<int> AdjustShadowsCyanRedValue(int value)
        {
            return AdjustIntSpinBoxValue(value, "cyanRedShadowsSpinbox");
        }
        public Task<int> AdjustShadowsMagentaGreenValue(int value)
        {
            return AdjustIntSpinBoxValue(value, "magentaGreenShadowsSpinbox");
        }
        public Task<int> AdjustShadowsYellowBlueValue(int value)
        {
            return AdjustIntSpinBoxValue(value, "yellowBlueShadowsSpinbox");
        }

        public Task ResetShadows()
        {
            return ClickPushButton("pushResetShadows");
        }

        public Task<int> AdjustMidTonesCyanRedValue(int value)
        {
            return AdjustIntSpinBoxValue(value, "cyanRedMidtonesSpinbox");
        }
        public Task<int> AdjustMidTonesMagentaGreenValue(int value)
        {
            return AdjustIntSpinBoxValue(value, "magentaGreenMidtonesSpinbox");
        }
        public Task<int> AdjustMidTonesYellowBlueValue(int value)
        {
            return AdjustIntSpinBoxValue(value, "yellowBlueMidtonesSpinbox");
        }

        public Task ResetMidTones()
        {
            return ClickPushButton("pushResetMidtones");
        }

        public Task<int> AdjustHighLightsCyanRedValue(int value)
        {
            return AdjustIntSpinBoxValue(value, "cyanRedHighlightsSpinbox");
        }
        public Task<int> AdjustHighLightsMagentaGreenValue(int value)
        {
            return AdjustIntSpinBoxValue(value, "magentaGreenHighlightsSpinbox");
        }
        public Task<int> AdjustHighLightsYellowBlueValue(int value)
        {
            return AdjustIntSpinBoxValue(value, "yellowBlueHighlightsSpinbox");
        }

        public Task ResetHighLights()
        {
            return ClickPushButton("pushResetHighlights");
        }

        public Task TogglePreserveLuminosity()
        {
            return ClickCheckBox("chkPreserveLuminosity");
        }
    }
}
