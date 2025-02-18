using Loupedeck.KritaPlugin.DynamicFolders.FilterDefinitions;
using LoupedeckKritaApiClient.FiltersDialogs;

namespace Loupedeck.KritaPlugin.DynamicFolders
{
    public class FilterSmallTiles : FilterDialogBase
    {
        public FilterSmallTiles()
            : base(GetDefinition())
        {
        }

        static internal FilterDialogDefinition GetDefinition()
        {
            return new FilterDialogDefinition("Small Tiles",
                FiltersEnum.SmallTiles,
                [],
                [
                    new FilterAdjustmentDefinition("Number", (dialog, delta) => ((KritaFilterSmallTiles)dialog.Dialog).AdjustNumberOfTiles((int)delta).Result, 2),
                ]);
        }
    }
}
