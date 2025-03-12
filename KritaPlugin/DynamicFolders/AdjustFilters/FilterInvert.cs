using System.Reflection;
using LoupedeckKritaApiClient.FiltersDialogs;

namespace Loupedeck.KritaPlugin.DynamicFolders
{
    public class FilterInvert : FilterDialogBase
    {
        public FilterInvert()
            : base(FilterNames.Invert)
        {
        }

        public override BitmapImage GetButtonImage(PluginImageSize imageSize)
        {
            return BitmapImage.FromResource(Assembly.GetExecutingAssembly(), "Loupedeck.KritaPlugin.images.filters-Invert.png");
        }

        static internal DialogDefinition GetDefinition()
        {
            return new DialogDefinition("Invert",
                FilterNames.Invert);
        }
    }
}
