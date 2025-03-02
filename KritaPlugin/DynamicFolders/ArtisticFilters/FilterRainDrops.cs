using LoupedeckKritaApiClient.FiltersDialogs;

namespace Loupedeck.KritaPlugin.DynamicFolders
{
    public class FilterRainDrops : FilterDialogBase
    {
        public FilterRainDrops()
            : base(GetDefinition())
        {
        }

        static internal FilterDialogDefinition GetDefinition()
        {
            return new FilterDialogDefinition("Rain Drops",
                FiltersEnum.RainDrops,
                [
                ],
                [
                    new FilterAdjustmentDefinition("Drop size", (dialog, delta) => ((KritaFilterRainDrops)dialog.Dialog).AdjustDropSize((int)delta).Result, 80),
                    new FilterAdjustmentDefinition("Number", (dialog, delta) => ((KritaFilterRainDrops)dialog.Dialog).AdjustNumberOfDrops((int)delta).Result, 80),
                    new FilterAdjustmentDefinition("Fish eyes", (dialog, delta) => ((KritaFilterRainDrops)dialog.Dialog).AdjustFishEyes((int)delta).Result, 30),
                ]);
        }
    }
}
