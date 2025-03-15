using System.Reflection;
using LoupedeckKritaApiClient.FiltersDialogs;

namespace Loupedeck.KritaPlugin.DynamicFolders
{
    public class FilterIndexColors : FilterDialogBase
    {
        public FilterIndexColors()
            : base(FilterNames.IndexColors)
        {
        }

        public override BitmapImage GetButtonImage(PluginImageSize imageSize)
        {
            return BitmapImage.FromResource(Assembly.GetExecutingAssembly(), "Loupedeck.KritaPlugin.images.Filters.filters-IndexColors.png");
        }

        static internal DialogDefinition GetDefinition()
        {
            return new DialogDefinition("Index colors",
                FilterNames.IndexColors,
                [],
                []);
        }
    }
}
