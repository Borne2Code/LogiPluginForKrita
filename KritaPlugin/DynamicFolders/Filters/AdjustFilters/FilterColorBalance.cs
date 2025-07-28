using LogiKritaApiClient.FiltersDialogs;

namespace Logi.KritaPlugin.DynamicFolders
{
    public class FilterColorsBalance : FilterDialogBase
    {
        public FilterColorsBalance()
            : base(FilterNames.ColorBalance)
        {
        }

        static internal FilterDialogDefinition GetDefinition()
        {
            var shadowCyanRedAdj = new AdjustmentDefinition("Shadows Cyan/Red",
                (filterDialog, diff) => ((KritaFilterColorBalance)filterDialog.Dialog).AdjustShadowsCyanRedValue((int)diff).Result);
            var shadowMagentaGreenAdj = new AdjustmentDefinition("Shadows Magenta/Green",
                (filterDialog, diff) => ((KritaFilterColorBalance)filterDialog.Dialog).AdjustShadowsMagentaGreenValue((int)diff).Result);
            var shadowYellowBlueAdj = new AdjustmentDefinition("Shadows Yellow/Blue",
                (filterDialog, diff) => ((KritaFilterColorBalance)filterDialog.Dialog).AdjustShadowsYellowBlueValue((int)diff).Result);

            var midtonesCyanRedAdj = new AdjustmentDefinition("Midtones Cyan/Red",
                (filterDialog, diff) => ((KritaFilterColorBalance)filterDialog.Dialog).AdjustMidTonesCyanRedValue((int)diff).Result);
            var midtonesMagentaGreenAdj = new AdjustmentDefinition("Midtones Magenta/Green",
                (filterDialog, diff) => ((KritaFilterColorBalance)filterDialog.Dialog).AdjustMidTonesMagentaGreenValue((int)diff).Result);
            var midtonesYellowBlueAdj = new AdjustmentDefinition("Midtones Yellow/Blue",
                (filterDialog, diff) => ((KritaFilterColorBalance)filterDialog.Dialog).AdjustMidTonesYellowBlueValue((int)diff).Result);

            var highlightsCyanRedAdj = new AdjustmentDefinition("Highlights Cyan/Red",
                (filterDialog, diff) => ((KritaFilterColorBalance)filterDialog.Dialog).AdjustHighLightsCyanRedValue((int)diff).Result);
            var highlightsMagentaGreenAdj = new AdjustmentDefinition("Highlights Magenta/Green",
                (filterDialog, diff) => ((KritaFilterColorBalance)filterDialog.Dialog).AdjustHighLightsMagentaGreenValue((int)diff).Result);
            var highlightsYellowBlueAdj = new AdjustmentDefinition("Highlights Yellow/Blue",
                (filterDialog, diff) => ((KritaFilterColorBalance)filterDialog.Dialog).AdjustHighLightsYellowBlueValue((int)diff).Result);

            var resetShadows = new CommandDefinition("Reset Shadows",
                (filterDialog) =>
                {
                    shadowCyanRedAdj.Value = 0;
                    shadowMagentaGreenAdj.Value = 0;
                    shadowYellowBlueAdj.Value = 0;
                    return ((KritaFilterColorBalance)filterDialog.Dialog).ResetShadows();
                });
            var resetMidtones = new CommandDefinition("Reset Midtones",
                (filterDialog) =>
                {
                    midtonesCyanRedAdj.Value = 0;
                    midtonesMagentaGreenAdj.Value = 0;
                    midtonesYellowBlueAdj.Value = 0;
                    return ((KritaFilterColorBalance)filterDialog.Dialog).ResetMidTones();
                });
            var resetHighlights = new CommandDefinition("Reset Highlights",
                (filterDialog) =>
                {
                    highlightsCyanRedAdj.Value = 0;
                    highlightsMagentaGreenAdj.Value = 0;
                    highlightsYellowBlueAdj.Value = 0;
                    return ((KritaFilterColorBalance)filterDialog.Dialog).ResetHighLights();
                });
            var preserveLuminosity = new CommandDefinition("Preserve Luminosity",
                (filterDialog) => ((KritaFilterColorBalance)filterDialog.Dialog).TogglePreserveLuminosity());

            return new FilterDialogDefinition("Colors balance",
                FilterNames.ColorBalance,
                true,
                "Logi.KritaPlugin.images.Filters.filters-ColorBalance.png",
                [
                    shadowCyanRedAdj,
                    shadowMagentaGreenAdj,
                    shadowYellowBlueAdj,
                    midtonesCyanRedAdj,
                    midtonesMagentaGreenAdj,
                    midtonesYellowBlueAdj,
                    highlightsCyanRedAdj,
                    highlightsMagentaGreenAdj,
                    highlightsYellowBlueAdj,
                    resetShadows,
                    resetMidtones,
                    resetHighlights,
                    preserveLuminosity,
                ]);
        }
    }
}
