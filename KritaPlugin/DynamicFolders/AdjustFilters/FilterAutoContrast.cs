using System.Reflection;
using LoupedeckKritaApiClient.FiltersDialogs;

namespace Loupedeck.KritaPlugin.DynamicFolders
{
    public class FilterAutoContrast : FilterDialogBase
    {
        public FilterAutoContrast()
            : base(FilterNames.AutoConstrast)
        {
        }

        public override BitmapImage GetButtonImage(PluginImageSize imageSize)
        {
            return BitmapImage.FromResource(Assembly.GetExecutingAssembly(), "Loupedeck.KritaPlugin.images.filters-AutoContrast.png");
        }

        static internal DialogDefinition GetDefinition()
        {
            return new DialogDefinition("Auto Contrast",
                FilterNames.AutoConstrast);
        }
    }
}
