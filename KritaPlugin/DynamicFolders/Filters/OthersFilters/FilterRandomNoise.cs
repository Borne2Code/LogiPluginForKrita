using LoupedeckKritaApiClient.FiltersDialogs;

namespace Loupedeck.KritaPlugin.DynamicFolders
{
    public class FilterRandomNoise : FilterDialogBase
    {
        public FilterRandomNoise()
            : base(FilterNames.Noise)
        {
        }

        static internal FilterDialogDefinition GetDefinition()
        {
            return new FilterDialogDefinition("Random Noise",
                FilterNames.Noise,
                true,
                "Loupedeck.KritaPlugin.images.Filters.filters-RandomNoise.png",
                [
                    new AdjustmentDefinition("Level", (dialog, delta) => (dialog.Dialog as KritaFilterNoise).AdjustLevel((int)delta).Result, 50),
                    new AdjustmentDefinition("Opacity", (dialog, delta) => (dialog.Dialog as KritaFilterNoise).AdjustOpacity((int)delta).Result, 99),
                ]);
        }
    }
}
