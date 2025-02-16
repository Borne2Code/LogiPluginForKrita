using Loupedeck.KritaPlugin.DynamicFolders.FilterDefinitions;
using LoupedeckKritaApiClient.FiltersDialogs;

namespace Loupedeck.KritaPlugin.DynamicFolders
{
    public class FilterPosterize : FilterDialogBase
    {
        public FilterPosterize()
            : base(GetDefinition())
        {
        }

        static internal FilterDialogDefinition GetDefinition()
        {
            return new FilterDialogDefinition("Posterize",
                FiltersEnum.Posterize,
                [
                ],
                [
                    new FilterAdjustmentDefinition("Steps", (dialog, _, delta) => ((KritaFilterPosterize)dialog.Dialog).AdjustSteps(delta).Result),
                ]);
        }
    }
}
