using LoupedeckKritaApiClient.FiltersDialogs;

namespace Loupedeck.KritaPlugin.DynamicFolders
{
    public class FilterDodge : FilterDialogBase
    {
        public FilterDodge()
            : base(FilterNames.Dodge)
        {
        }

        static internal FilterDialogDefinition GetDefinition()
        {
            return new FilterDialogDefinition("Dodge",
                FilterNames.Dodge,
                "Loupedeck.KritaPlugin.images.Filters.filters-Dodge.png",
                [
                    new CommandDefinition("Shadows", (dialog) => ((KritaFilterDodge)dialog.Dialog).SelectShadows()),
                    new CommandDefinition("Midtones", (dialog) => ((KritaFilterDodge)dialog.Dialog).SelectMidTones()),
                    new CommandDefinition("Highlights", (dialog) => ((KritaFilterDodge)dialog.Dialog).SelectHighLights())
                ],
                [
                    new AdjustmentDefinition("Exposure", (dialog, delta) => ((KritaFilterDodge)dialog.Dialog).AdjustExposureValue((int)delta).Result, 50)
                ]);
        }
    }
}
