using LoupedeckKritaApiClient.FiltersDialogs;

namespace Loupedeck.KritaPlugin.DynamicFolders
{
    public class FilterRainDrops : FilterDialogBase
    {
        public FilterRainDrops()
            : base(FilterNames.RainDrops)
        {
        }

        static internal FilterDialogDefinition GetDefinition()
        {
            return new FilterDialogDefinition("Rain Drops",
                FilterNames.RainDrops,
                "Loupedeck.KritaPlugin.images.Filters.filters-RainDrops.png",
                [],
                [
                    new AdjustmentDefinition("Drop size", (dialog, delta) => (dialog.Dialog as KritaFilterRainDrops).AdjustDropSize((int)delta).Result, 80),
                    new AdjustmentDefinition("Number", (dialog, delta) => (dialog.Dialog as KritaFilterRainDrops).AdjustNumberOfDrops((int)delta).Result, 80),
                    new AdjustmentDefinition("Fish eyes", (dialog, delta) => (dialog.Dialog as KritaFilterRainDrops).AdjustFishEyes((int)delta).Result, 30),
                ]);
        }
    }
}
