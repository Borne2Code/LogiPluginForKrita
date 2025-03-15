using System.Reflection;
using LoupedeckKritaApiClient.FiltersDialogs;

namespace Loupedeck.KritaPlugin.DynamicFolders
{
    public class FilterColorMinimize : FilterDialogBase
    {
        public FilterColorMinimize()
            : base(FilterNames.Minimize)
        {
        }

        public override BitmapImage GetButtonImage(PluginImageSize imageSize)
        {
            return BitmapImage.FromResource(Assembly.GetExecutingAssembly(), "Loupedeck.KritaPlugin.images.Filters.filters-Minimize.png");
        }

        static internal DialogDefinition GetDefinition()
        {
            return new DialogDefinition("Minimize channels",
                FilterNames.Minimize);
        }
    }
}
