using System.Reflection;
using LoupedeckKritaApiClient.FiltersDialogs;

namespace Loupedeck.KritaPlugin.DynamicFolders
{
    public class FilterEmbossVerticalOnly : FilterDialogBase
    {
        public FilterEmbossVerticalOnly()
            : base(FilterNames.EmbossVerticalOnly)
        {
        }

        public override BitmapImage GetButtonImage(PluginImageSize imageSize)
        {
            return BitmapImage.FromResource(Assembly.GetExecutingAssembly(), "Loupedeck.KritaPlugin.images.Filters.filters-EmbossVertical.png");
        }

        static internal DialogDefinition GetDefinition()
        {
            return new DialogDefinition("Emboss Vertical only",
                FilterNames.EmbossVerticalOnly);
        }
    }
}
