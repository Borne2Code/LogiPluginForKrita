using LoupedeckKritaApiClient.FiltersDialogs;

namespace Loupedeck.KritaPlugin.DynamicFolders
{
    public class FilterAutoContrast : FilterDialogBase
    {
        public FilterAutoContrast()
            : base(FilterNames.AutoConstrast)
        {
        }

        static internal FilterDialogDefinition GetDefinition()
        {
            return new FilterDialogDefinition("Auto Contrast",
                FilterNames.AutoConstrast,
                "Loupedeck.KritaPlugin.images.Filters.filters-AutoContrast.png");
        }
    }
}
