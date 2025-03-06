using LoupedeckKritaApiClient.FiltersDialogs;

namespace Loupedeck.KritaPlugin.DynamicFolders
{
    public class FilterEmboss : FilterDialogBase
    {
        public FilterEmboss()
            : base(FilterNames.Emboss)
        {
        }

        static internal FilterDialogDefinition GetDefinition()
        {
            return new FilterDialogDefinition("Emboss",
                FilterNames.Emboss,
                [],
                [
                    new FilterAdjustmentDefinition("Depth", (dialog, delta) => ((KritaFilterEmboss)dialog.Dialog).AdjustDepth((int)delta).Result, 30),
                ]);
        }
    }
}
