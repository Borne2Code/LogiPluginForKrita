using Loupedeck.KritaPlugin.DynamicFolders.FilterDefinitions;
using LoupedeckKritaApiClient.FiltersDialogs;

namespace Loupedeck.KritaPlugin.DynamicFolders
{
    public class FilterBurn : FilterDialogBase
    {
        public FilterBurn()
            : base(GetDefinition())
        {
        }

        static internal FilterDialogDefinition GetDefinition()
        {
            return new FilterDialogDefinition("Burn",
                FiltersEnum.Burn,
                [
                    new FilterCommandDefinition("Shadows", (dialog) => ((KritaFilterBurn)dialog.Dialog).SelectShadows()),
                    new FilterCommandDefinition("Midtones", (dialog) => ((KritaFilterBurn)dialog.Dialog).SelectMidTones()),
                    new FilterCommandDefinition("Highlights", (dialog) => ((KritaFilterBurn)dialog.Dialog).SelectHighLights())
                ],
                [
                    new FilterAdjustmentDefinition("Exposure", (dialog, _, delta) => ((KritaFilterBurn)dialog.Dialog).AdjustExposureValue(delta).Result)
                ]);
        }
    }
}
