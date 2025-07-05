using LoupedeckKritaApiClient.FiltersDialogs;

namespace Loupedeck.KritaPlugin.DynamicFolders
{
    public class FilterPhongBumpmap : FilterDialogBase
    {
        public FilterPhongBumpmap()
            : base(FilterNames.PhongBumpMap)
        {
        }

        static internal FilterDialogDefinition GetDefinition()
        {
            return new FilterDialogDefinition("Phong Bumpmap",
                FilterNames.PhongBumpMap,
                true,
                "Loupedeck.KritaPlugin.images.Filters.filters-PhongBumpMap.png",
                [],
                []);
        }
    }
}
