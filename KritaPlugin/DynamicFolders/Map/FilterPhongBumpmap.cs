using LoupedeckKritaApiClient.FiltersDialogs;

namespace Loupedeck.KritaPlugin.DynamicFolders
{
    public class FilterPhongBumpmap : FilterDialogBase
    {
        public FilterPhongBumpmap()
            : base(GetDefinition())
        {
        }

        static internal FilterDialogDefinition GetDefinition()
        {
            return new FilterDialogDefinition("Phong Bumpmap",
                FiltersEnum.PhongBumpMap,
                [],
                []);
        }
    }
}
