using LoupedeckKritaApiClient.FiltersDialogs;

namespace Loupedeck.KritaPlugin.DynamicFolders
{
    public class FilterRandomNoise : FilterDialogBase
    {
        public FilterRandomNoise()
            : base(FilterNames.Noise)
        {
        }

        static internal DialogDefinition GetDefinition()
        {
            return new DialogDefinition("Random Noise",
                FilterNames.Noise,
                [],
                [
                    new AdjustmentDefinition("Level", (dialog, delta) => (dialog.Dialog as KritaFilterNoise).AdjustLevel((int)delta).Result, 50),
                    new AdjustmentDefinition("Opacity", (dialog, delta) => (dialog.Dialog as KritaFilterNoise).AdjustOpacity((int)delta).Result, 99),
                ]);
        }
    }
}
