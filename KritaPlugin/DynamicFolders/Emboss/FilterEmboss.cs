using LoupedeckKritaApiClient.FiltersDialogs;

namespace Loupedeck.KritaPlugin.DynamicFolders
{
    public class FilterEmboss : FilterDialogBase
    {
        public FilterEmboss()
            : base(GetDefinition())
        {
        }

        static internal FilterDialogDefinition GetDefinition()
        {
            return new FilterDialogDefinition("Emboss",
                FiltersEnum.Emboss,
                [],
                [
                    new FilterAdjustmentDefinition("Depth", (dialog, delta) => ((KritaFilterEmboss)dialog.Dialog).AdjustDepth((int)delta).Result, 30),
                ]);
        }
    }
}
