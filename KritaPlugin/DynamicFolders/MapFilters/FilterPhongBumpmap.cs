using LoupedeckKritaApiClient.FiltersDialogs;

namespace Loupedeck.KritaPlugin.DynamicFolders
{
    public class FilterPhongBumpmap : FilterDialogBase
    {
        public FilterPhongBumpmap()
            : base(FilterNames.PhongBumpMap)
        {
        }

        static internal DialogDefinition GetDefinition()
        {
            return new DialogDefinition("Phong Bumpmap",
                FilterNames.PhongBumpMap,
                [],
                []);
        }
    }
}
