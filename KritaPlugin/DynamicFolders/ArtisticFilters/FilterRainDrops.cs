using Loupedeck.KritaPlugin.DynamicFolders.FilterDefinitions;
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
                    new FilterAdjustmentDefinition("Drop size", (dialog, _, delta) => ((KritaFilterRainDrops)dialog.Dialog).AdjustDropSize(delta).Result),
                    new FilterAdjustmentDefinition("Number", (dialog, _, delta) => ((KritaFilterRainDrops)dialog.Dialog).AdjustNumberOfDrops(delta).Result),
                    new FilterAdjustmentDefinition("Fish eyes", (dialog, _, delta) => ((KritaFilterRainDrops)dialog.Dialog).AdjustFishEyes(delta).Result),
                ]);
        }
    }
}
