using System.Reflection;
using LoupedeckKritaApiClient.FiltersDialogs;

namespace Loupedeck.KritaPlugin.DynamicFolders
{
    public class FilterPalettize : FilterDialogBase
    {
        public FilterPalettize()
            : base(FilterNames.Palettize)
        {
        }

        public override BitmapImage GetButtonImage(PluginImageSize imageSize)
        {
            return BitmapImage.FromResource(Assembly.GetExecutingAssembly(), "Loupedeck.KritaPlugin.images.filters-Paletize.png");
        }

        static internal DialogDefinition GetDefinition()
        {
            return new DialogDefinition("Palettize",
                FilterNames.Palettize,
                [],
                []);
        }
    }
}
