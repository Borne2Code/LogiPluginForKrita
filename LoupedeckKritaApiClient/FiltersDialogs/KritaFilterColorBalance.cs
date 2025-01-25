using System.Runtime.CompilerServices;
using LoupedeckKritaApiClient.ClientBase;
using Newtonsoft.Json.Linq;

namespace LoupedeckKritaApiClient.FiltersDialogs
{
    public class KritaFilterColorBalance(Client client) : FilterDialog(client)
    {
        protected override string ActionName => "krita_filter_colorbalance";

        public Task SetShadowsCyanRedValue(int value)
        {
            return SetSpinBoxValue(value, "cyanRedShadowsSpinbox");
        }
        public Task SetShadowsMagentaGreenValue(int value)
        {
            return SetSpinBoxValue(value, "magentaGreenShadowsSpinbox");
        }
        public Task SetShadowsYellowBlueValue(int value)
        {
            return SetSpinBoxValue(value, "yellowBlueShadowsSpinbox");
        }

        public Task ResetShadows()
        {
            return ClickPushButton("pushResetShadows");
        }

        public Task SetMidTonesCyanRedValue(int value)
        {
            return SetSpinBoxValue(value, "cyanRedMidtonesSpinbox");
        }
        public Task SetMidTonesMagentaGreenValue(int value)
        {
            return SetSpinBoxValue(value, "magentaGreenMidtonesSpinbox");
        }
        public Task SetMidTonesYellowBlueValue(int value)
        {
            return SetSpinBoxValue(value, "yellowBlueMidtonesSpinbox");
        }

        public Task ResetMidTones()
        {
            return ClickPushButton("pushResetMidtones");
        }

        public Task SetHighLightsCyanRedValue(int value)
        {
            return SetSpinBoxValue(value, "cyanRedHighlightsSpinbox");
        }
        public Task SetHighLightsMagentaGreenValue(int value)
        {
            return SetSpinBoxValue(value, "magentaGreenHighlightsSpinbox");
        }
        public Task SetHighLightsYellowBlueValue(int value)
        {
            return SetSpinBoxValue(value, "yellowBlueHighlightsSpinbox");
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
