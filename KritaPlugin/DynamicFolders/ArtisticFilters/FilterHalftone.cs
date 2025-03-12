using System.Reflection;
using LoupedeckKritaApiClient.FiltersDialogs;

namespace Loupedeck.KritaPlugin.DynamicFolders
{
    public class FilterHalftone : FilterDialogBase
    {
        public FilterHalftone()
            : base(FilterNames.Halftone)
        {
        }

        public override BitmapImage GetButtonImage(PluginImageSize imageSize)
        {
            return BitmapImage.FromResource(Assembly.GetExecutingAssembly(), "Loupedeck.KritaPlugin.images.filters-Halftone.png");
        }

        static internal DialogDefinition GetDefinition()
        {
            return new DialogDefinition("Halftone",
                FilterNames.Halftone,
                [],
                []);
        }
    }
}
