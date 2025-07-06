using LogiKritaApiClient.FiltersDialogs;

namespace Logi.KritaPlugin.DynamicFolders
{
    public class FilterGradientMap : FilterDialogBase
    {
        public FilterGradientMap()
            : base(FilterNames.GradientMap)
        {
        }

        static internal FilterDialogDefinition GetDefinition()
        {
            return new FilterDialogDefinition("Gradient Map",
                FilterNames.GradientMap,
                true,
                "Logi.KritaPlugin.images.Filters.filters-GradientMap.png",
                []);
        }
    }
}
