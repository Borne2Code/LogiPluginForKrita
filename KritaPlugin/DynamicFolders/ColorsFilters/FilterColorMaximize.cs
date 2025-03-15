using System.Reflection;
using LoupedeckKritaApiClient.FiltersDialogs;

namespace Loupedeck.KritaPlugin.DynamicFolders
{
    public class FilterColorMaximize : FilterDialogBase
    {
        public FilterColorMaximize()
            : base(FilterNames.Maximize)
        {
        }

        public override BitmapImage GetButtonImage(PluginImageSize imageSize)
        {
            return BitmapImage.FromResource(Assembly.GetExecutingAssembly(), "Loupedeck.KritaPlugin.images.Filters.filters-Maximize.png");
        }

        static internal DialogDefinition GetDefinition()
        {
            return new DialogDefinition("Maximize channels",
                FilterNames.Maximize);
        }
    }
}
