using LoupedeckKritaApiClient.FiltersDialogs;

namespace Loupedeck.KritaPlugin.DynamicFolders
{
    public class FilterRoundCorners : FilterDialogBase
    {
        public FilterRoundCorners()
            : base(FilterNames.RoundCorners)
        {
        }

        static internal FilterDialogDefinition GetDefinition()
        {
            return new FilterDialogDefinition("Round Corners",
                FilterNames.RoundCorners,
                [],
                [
                    new FilterAdjustmentDefinition("Radius", (dialog, delta) => ((KritaFilterRoundCorners)dialog.Dialog).AdjustRadius((int)delta).Result, 30),
                ]);
        }
    }
}
