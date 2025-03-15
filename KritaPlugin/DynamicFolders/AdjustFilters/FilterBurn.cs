using LoupedeckKritaApiClient.FiltersDialogs;

namespace Loupedeck.KritaPlugin.DynamicFolders
{
    public class FilterBurn : FilterDialogBase
    {
        public FilterBurn()
            : base(FilterNames.Burn)
        {
        }

        static internal FilterDialogDefinition GetDefinition()
        {
            return new FilterDialogDefinition("Burn",
                FilterNames.Burn,
                "Loupedeck.KritaPlugin.images.Filters.filters-Burn.png",
                [
                    new CommandDefinition("Shadows", (dialog) => ((KritaFilterBurn)dialog.Dialog).SelectShadows()),
                    new CommandDefinition("Midtones", (dialog) => ((KritaFilterBurn)dialog.Dialog).SelectMidTones()),
                    new CommandDefinition("Highlights", (dialog) => ((KritaFilterBurn)dialog.Dialog).SelectHighLights())
                ],
                [
                    new AdjustmentDefinition("Exposure", (dialog, delta) => ((KritaFilterBurn)dialog.Dialog).AdjustExposureValue((int)delta).Result, 50)
                ]);
        }
    }
}
