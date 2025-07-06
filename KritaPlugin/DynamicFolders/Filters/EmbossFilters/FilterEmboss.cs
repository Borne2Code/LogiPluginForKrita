using LogiKritaApiClient.FiltersDialogs;

namespace Logi.KritaPlugin.DynamicFolders
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
                false,
                "Logi.KritaPlugin.images.Filters.filters-Emboss.png",
                [
                    new AdjustmentDefinition("Depth", (dialog, delta) => (dialog.Dialog as KritaFilterEmboss).AdjustDepth((int)delta).Result, 30),
                ]);
        }
    }
}
