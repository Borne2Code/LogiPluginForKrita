using LoupedeckKritaApiClient.FiltersDialogs;

namespace Loupedeck.KritaPlugin.DynamicFolders
{
    public class FilterInvert : FilterDialogBase
    {
        public FilterInvert()
            : base(FilterNames.Invert)
        {
        }

        static internal FilterDialogDefinition GetDefinition()
        {
            return new FilterDialogDefinition("Invert",
                FilterNames.Invert,
                true,
                "Loupedeck.KritaPlugin.images.Filters.filters-Invert.png");
        }
    }
}
