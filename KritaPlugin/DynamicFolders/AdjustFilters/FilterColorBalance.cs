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
                (filterDialog, _, diff) => ((KritaFilterColorBalance)filterDialog.Dialog).AdjustShadowsCyanRedValue(diff).Result);
            var shadowMagentaGreenAdj = new FilterAdjustmentDefinition("Shadows Magenta/Green",
                (filterDialog, _, diff) => ((KritaFilterColorBalance)filterDialog.Dialog).AdjustShadowsMagentaGreenValue(diff).Result);
            var shadowYellowBlueAdj = new FilterAdjustmentDefinition("Shadows Yellow/Blue",
                (filterDialog, _, diff) => ((KritaFilterColorBalance)filterDialog.Dialog).AdjustShadowsYellowBlueValue(diff).Result);

            var midtonesCyanRedAdj = new FilterAdjustmentDefinition("Midtones Cyan/Red",
                (filterDialog, _, diff) => ((KritaFilterColorBalance)filterDialog.Dialog).AdjustMidTonesCyanRedValue(diff).Result);
            var midtonesMagentaGreenAdj = new FilterAdjustmentDefinition("Midtones Magenta/Green",
                (filterDialog, _, diff) => ((KritaFilterColorBalance)filterDialog.Dialog).AdjustMidTonesMagentaGreenValue(diff).Result);
            var midtonesYellowBlueAdj = new FilterAdjustmentDefinition("Midtones Yellow/Blue",
                (filterDialog, _, diff) => ((KritaFilterColorBalance)filterDialog.Dialog).AdjustMidTonesYellowBlueValue(diff).Result);

            var highlightsCyanRedAdj = new FilterAdjustmentDefinition("Highlights Cyan/Red",
                (filterDialog, _, diff) => ((KritaFilterColorBalance)filterDialog.Dialog).AdjustHighLightsCyanRedValue(diff).Result);
            var highlightsMagentaGreenAdj = new FilterAdjustmentDefinition("Highlights Magenta/Green",
                (filterDialog, _, diff) => ((KritaFilterColorBalance)filterDialog.Dialog).AdjustHighLightsMagentaGreenValue(diff).Result);
            var highlightsYellowBlueAdj = new FilterAdjustmentDefinition("Highlights Yellow/Blue",
                (filterDialog, _, diff) => ((KritaFilterColorBalance)filterDialog.Dialog).AdjustHighLightsYellowBlueValue(diff).Result);

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
