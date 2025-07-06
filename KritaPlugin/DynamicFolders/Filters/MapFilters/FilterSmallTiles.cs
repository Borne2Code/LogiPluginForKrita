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
                false,
                "Loupedeck.KritaPlugin.images.Filters.filters-SmallTiles.png",
                [
                    new AdjustmentDefinition("Number", (dialog, delta) => (dialog.Dialog as KritaFilterSmallTiles).AdjustNumberOfTiles((int)delta).Result, 2),
                ]);
        }
    }
}
