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
                [
                    new FilterCommandDefinition("Shadows", (dialog) => ((KritaFilterBurn)dialog.Dialog).SelectShadows()),
                    new FilterCommandDefinition("Midtones", (dialog) => ((KritaFilterBurn)dialog.Dialog).SelectMidTones()),
                    new FilterCommandDefinition("Highlights", (dialog) => ((KritaFilterBurn)dialog.Dialog).SelectHighLights())
                ],
                [
                    new FilterAdjustmentDefinition("Exposure", (dialog, delta) => ((KritaFilterBurn)dialog.Dialog).AdjustExposureValue((int)delta).Result, 50)
                ]);
        }
    }
}
