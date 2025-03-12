using LoupedeckKritaApiClient.FiltersDialogs;

namespace Loupedeck.KritaPlugin.DynamicFolders
{
    public class FilterRoundCorners : FilterDialogBase
    {
        public FilterRoundCorners()
            : base(FilterNames.RoundCorners)
        {
        }

        static internal DialogDefinition GetDefinition()
        {
            return new DialogDefinition("Round Corners",
                FilterNames.RoundCorners,
                [],
                [
                    new AdjustmentDefinition("Radius", (dialog, delta) => (dialog.Dialog as KritaFilterRoundCorners).AdjustRadius((int)delta).Result, 30),
                ]);
        }
    }
}
