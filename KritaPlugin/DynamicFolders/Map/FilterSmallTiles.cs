using LoupedeckKritaApiClient.FiltersDialogs;

namespace Loupedeck.KritaPlugin.DynamicFolders
{
    public class FilterSmallTiles : FilterDialogBase
    {
        public FilterSmallTiles()
            : base(FilterNames.SmallTiles)
        {
        }

        static internal FilterDialogDefinition GetDefinition()
        {
            return new FilterDialogDefinition("Small Tiles",
                FilterNames.SmallTiles,
                [],
                [
                    new FilterAdjustmentDefinition("Number", (dialog, delta) => ((KritaFilterSmallTiles)dialog.Dialog).AdjustNumberOfTiles((int)delta).Result, 2),
                ]);
        }
    }
}
