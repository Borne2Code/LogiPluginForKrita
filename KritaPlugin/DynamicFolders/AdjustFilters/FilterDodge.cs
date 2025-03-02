using LoupedeckKritaApiClient.FiltersDialogs;

namespace Loupedeck.KritaPlugin.DynamicFolders
{
    public class FilterDodge : FilterDialogBase
    {
        public FilterDodge()
            : base(GetDefinition())
        {
        }

        static internal FilterDialogDefinition GetDefinition()
        {
            return new FilterDialogDefinition("Dodge",
                FiltersEnum.Dodge,
                [
                    new FilterCommandDefinition("Shadows", (dialog) => ((KritaFilterDodge)dialog.Dialog).SelectShadows()),
                    new FilterCommandDefinition("Midtones", (dialog) => ((KritaFilterDodge)dialog.Dialog).SelectMidTones()),
                    new FilterCommandDefinition("Highlights", (dialog) => ((KritaFilterDodge)dialog.Dialog).SelectHighLights())
                ],
                [
                    new FilterAdjustmentDefinition("Exposure", (dialog, delta) => ((KritaFilterDodge)dialog.Dialog).AdjustExposureValue((int)delta).Result, 50)
                ]);
        }
    }
}
