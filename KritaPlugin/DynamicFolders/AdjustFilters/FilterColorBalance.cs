using Loupedeck.KritaPlugin.DynamicFolders.FilterDefinitions;
using LoupedeckKritaApiClient.FiltersDialogs;

namespace Loupedeck.KritaPlugin.DynamicFolders
{
    public class FilterColorsBalance : FilterDialogBase
    {
        public FilterColorsBalance()
            : base(GetDefinition())
        {
        }

        static internal FilterDialogDefinition GetDefinition()
        {
            var shadowCyanRedAdj = new FilterAdjustmentDefinition("Shadows Cyan/Red",
                (filterDialog, diff) => ((KritaFilterColorBalance)filterDialog.Dialog).AdjustShadowsCyanRedValue((int)diff).Result);
            var shadowMagentaGreenAdj = new FilterAdjustmentDefinition("Shadows Magenta/Green",
                (filterDialog, diff) => ((KritaFilterColorBalance)filterDialog.Dialog).AdjustShadowsMagentaGreenValue((int)diff).Result);
            var shadowYellowBlueAdj = new FilterAdjustmentDefinition("Shadows Yellow/Blue",
                (filterDialog, diff) => ((KritaFilterColorBalance)filterDialog.Dialog).AdjustShadowsYellowBlueValue((int)diff).Result);

            var midtonesCyanRedAdj = new FilterAdjustmentDefinition("Midtones Cyan/Red",
                (filterDialog, diff) => ((KritaFilterColorBalance)filterDialog.Dialog).AdjustMidTonesCyanRedValue((int)diff).Result);
            var midtonesMagentaGreenAdj = new FilterAdjustmentDefinition("Midtones Magenta/Green",
                (filterDialog, diff) => ((KritaFilterColorBalance)filterDialog.Dialog).AdjustMidTonesMagentaGreenValue((int)diff).Result);
            var midtonesYellowBlueAdj = new FilterAdjustmentDefinition("Midtones Yellow/Blue",
                (filterDialog, diff) => ((KritaFilterColorBalance)filterDialog.Dialog).AdjustMidTonesYellowBlueValue((int)diff).Result);

            var highlightsCyanRedAdj = new FilterAdjustmentDefinition("Highlights Cyan/Red",
                (filterDialog, diff) => ((KritaFilterColorBalance)filterDialog.Dialog).AdjustHighLightsCyanRedValue((int)diff).Result);
            var highlightsMagentaGreenAdj = new FilterAdjustmentDefinition("Highlights Magenta/Green",
                (filterDialog, diff) => ((KritaFilterColorBalance)filterDialog.Dialog).AdjustHighLightsMagentaGreenValue((int)diff).Result);
            var highlightsYellowBlueAdj = new FilterAdjustmentDefinition("Highlights Yellow/Blue",
                (filterDialog, diff) => ((KritaFilterColorBalance)filterDialog.Dialog).AdjustHighLightsYellowBlueValue((int)diff).Result);

            var resetShadows = new FilterCommandDefinition("Reset Shadows",
                (filterDialog) =>
                {
                    shadowCyanRedAdj.Value = 0;
                    shadowMagentaGreenAdj.Value = 0;
                    shadowYellowBlueAdj.Value = 0;
                    return ((KritaFilterColorBalance)filterDialog.Dialog).ResetShadows();
                });
            var resetMidtones = new FilterCommandDefinition("Reset Midtones",
                (filterDialog) =>
                {
                    midtonesCyanRedAdj.Value = 0;
                    midtonesMagentaGreenAdj.Value = 0;
                    midtonesYellowBlueAdj.Value = 0;
                    return ((KritaFilterColorBalance)filterDialog.Dialog).ResetMidTones();
                });
            var resetHighlights = new FilterCommandDefinition("Reset Highlights",
                (filterDialog) =>
                {
                    highlightsCyanRedAdj.Value = 0;
                    highlightsMagentaGreenAdj.Value = 0;
                    highlightsYellowBlueAdj.Value = 0;
                    return ((KritaFilterColorBalance)filterDialog.Dialog).ResetHighLights();
                });
            var preserveLuminosity = new FilterCommandDefinition("Preserve Luminosity",
                (filterDialog) => ((KritaFilterColorBalance)filterDialog.Dialog).TogglePreserveLuminosity());

            return new FilterDialogDefinition("Colors balance",
                FiltersEnum.ColorBalance,
                [
                    resetShadows,
                    resetMidtones,
                    resetHighlights,
                    preserveLuminosity
                ],
                [
                    shadowCyanRedAdj,
                    shadowMagentaGreenAdj,
                    shadowYellowBlueAdj,
                    midtonesCyanRedAdj,
                    midtonesMagentaGreenAdj,
                    midtonesYellowBlueAdj,
                    midtonesCyanRedAdj,
                    midtonesMagentaGreenAdj,
                    midtonesYellowBlueAdj,
                    highlightsCyanRedAdj,
                    highlightsMagentaGreenAdj,
                    highlightsYellowBlueAdj
                ]);
        }
    }
}
