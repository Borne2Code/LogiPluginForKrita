using LoupedeckKritaApiClient.FiltersDialogs;

namespace Loupedeck.KritaPlugin.DynamicFolders
{
    public class FilterRandomNoise : FilterDialogBase
    {
        public FilterRandomNoise()
            : base(GetDefinition())
        {
        }

        static internal FilterDialogDefinition GetDefinition()
        {
            return new FilterDialogDefinition("Random Noise",
                FiltersEnum.Noise,
                [],
                [
                    new FilterAdjustmentDefinition("Level", (dialog, delta) => ((KritaFilterNoise)dialog.Dialog).AdjustLevel((int)delta).Result, 50),
                    new FilterAdjustmentDefinition("Opacity", (dialog, delta) => ((KritaFilterNoise)dialog.Dialog).AdjustOpacity((int)delta).Result, 99),
                ]);
        }
    }
}
