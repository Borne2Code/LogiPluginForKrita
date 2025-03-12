using LoupedeckKritaApiClient.FiltersDialogs;

namespace Loupedeck.KritaPlugin.DynamicFolders
{
    public class FilterEmboss : FilterDialogBase
    {
        public FilterEmboss()
            : base(FilterNames.Emboss)
        {
        }

        static internal DialogDefinition GetDefinition()
        {
            return new DialogDefinition("Emboss",
                FilterNames.Emboss,
                [],
                [
                    new AdjustmentDefinition("Depth", (dialog, delta) => (dialog.Dialog as KritaFilterEmboss).AdjustDepth((int)delta).Result, 30),
                ]);
        }
    }
}
