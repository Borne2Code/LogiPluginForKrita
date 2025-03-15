using System.Reflection;
using LoupedeckKritaApiClient.FiltersDialogs;

namespace Loupedeck.KritaPlugin.DynamicFolders
{
    public class FilterPhongBumpmap : FilterDialogBase
    {
        public FilterPhongBumpmap()
            : base(FilterNames.PhongBumpMap)
        {
        }

        public override BitmapImage GetButtonImage(PluginImageSize imageSize)
        {
            return BitmapImage.FromResource(Assembly.GetExecutingAssembly(), "Loupedeck.KritaPlugin.images.Filters.filters-PhongBumpMap.png");
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
