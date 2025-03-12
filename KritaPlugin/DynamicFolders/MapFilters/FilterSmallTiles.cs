using LoupedeckKritaApiClient.FiltersDialogs;

namespace Loupedeck.KritaPlugin.DynamicFolders
{
    public class FilterSmallTiles : FilterDialogBase
    {
        public FilterSmallTiles()
            : base(FilterNames.SmallTiles)
        {
        }

        static internal DialogDefinition GetDefinition()
        {
            return new DialogDefinition("Small Tiles",
                FilterNames.SmallTiles,
                [],
                [
                    new AdjustmentDefinition("Number", (dialog, delta) => (dialog.Dialog as KritaFilterSmallTiles).AdjustNumberOfTiles((int)delta).Result, 2),
                ]);
        }
    }
}
