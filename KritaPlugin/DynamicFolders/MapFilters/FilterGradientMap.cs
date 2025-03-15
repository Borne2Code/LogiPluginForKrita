using System.Reflection;
using LoupedeckKritaApiClient.FiltersDialogs;

namespace Loupedeck.KritaPlugin.DynamicFolders
{
    public class FilterGradientMap : FilterDialogBase
    {
        public FilterGradientMap()
            : base(FilterNames.GradientMap)
        {
        }

        public override BitmapImage GetButtonImage(PluginImageSize imageSize)
        {
            return BitmapImage.FromResource(Assembly.GetExecutingAssembly(), "Loupedeck.KritaPlugin.images.Filters.filters-GradientMap.png");
        }

        static internal DialogDefinition GetDefinition()
        {
            return new DialogDefinition("Gradient Map",
                FilterNames.GradientMap,
                [],
                []);
        }
    }
}
