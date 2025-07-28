using LogiKritaApiClient.FiltersDialogs;

namespace Logi.KritaPlugin.DynamicFolders
{
    public class FilterIndexColors : FilterDialogBase
    {
        public FilterIndexColors()
            : base(FilterNames.IndexColors)
        {
        }

        static internal FilterDialogDefinition GetDefinition()
        {
            return new FilterDialogDefinition("Index colors",
                FilterNames.IndexColors,
                true,
                "Logi.KritaPlugin.images.Filters.filters-IndexColors.png",
                []);
        }
    }
}
