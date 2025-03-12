using LoupedeckKritaApiClient.FiltersDialogs;

namespace Loupedeck.KritaPlugin.DynamicFolders
{
    public class FilterRainDrops : FilterDialogBase
    {
        public FilterRainDrops()
            : base(FilterNames.RainDrops)
        {
        }

        static internal DialogDefinition GetDefinition()
        {
            return new DialogDefinition("Rain Drops",
                FilterNames.RainDrops,
                [
                ],
                [
                    new AdjustmentDefinition("Drop size", (dialog, delta) => (dialog.Dialog as KritaFilterRainDrops).AdjustDropSize((int)delta).Result, 80),
                    new AdjustmentDefinition("Number", (dialog, delta) => (dialog.Dialog as KritaFilterRainDrops).AdjustNumberOfDrops((int)delta).Result, 80),
                    new AdjustmentDefinition("Fish eyes", (dialog, delta) => (dialog.Dialog as KritaFilterRainDrops).AdjustFishEyes((int)delta).Result, 30),
                ]);
        }
    }
}
