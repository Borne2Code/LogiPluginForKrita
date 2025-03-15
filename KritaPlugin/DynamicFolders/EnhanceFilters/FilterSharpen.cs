using System.Reflection;
using LoupedeckKritaApiClient.FiltersDialogs;

namespace Loupedeck.KritaPlugin.DynamicFolders
{
    public class FilterSharpen : FilterDialogBase
    {
        public FilterSharpen()
            : base(FilterNames.Sharpen)
        {
        }

        public override BitmapImage GetButtonImage(PluginImageSize imageSize)
        {
            return BitmapImage.FromResource(Assembly.GetExecutingAssembly(), "Loupedeck.KritaPlugin.images.Filters.filters-Sharpen.png");
        }

        static internal DialogDefinition GetDefinition()
        {
            return new DialogDefinition("Sharpen",
                FilterNames.Sharpen);
        }
    }
}
