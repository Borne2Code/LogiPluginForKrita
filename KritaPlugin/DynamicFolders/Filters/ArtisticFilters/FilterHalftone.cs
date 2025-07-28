using LogiKritaApiClient.FiltersDialogs;

namespace Logi.KritaPlugin.DynamicFolders
{
    public class FilterHalftone : FilterDialogBase
    {
        public FilterHalftone()
            : base(FilterNames.Halftone)
        {
        }

        static internal FilterDialogDefinition GetDefinition()
        {
            return new FilterDialogDefinition("Halftone",
                FilterNames.Halftone,
                true,
                "Logi.KritaPlugin.images.Filters.filters-Halftone.png",
                []);
        }
    }
}
