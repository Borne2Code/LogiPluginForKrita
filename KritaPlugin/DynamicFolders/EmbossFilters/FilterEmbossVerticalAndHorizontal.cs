using System.Reflection;
using LoupedeckKritaApiClient.FiltersDialogs;

namespace Loupedeck.KritaPlugin.DynamicFolders
{
    public class FilterEmbossVerticalAndHorizontal : FilterDialogBase
    {
        public FilterEmbossVerticalAndHorizontal()
            : base(FilterNames.EmbossHorizontalAndVertical)
        {
        }

        public override BitmapImage GetButtonImage(PluginImageSize imageSize)
        {
            return BitmapImage.FromResource(Assembly.GetExecutingAssembly(), "Loupedeck.KritaPlugin.images.Filters.filters-EmbossHorizontalAndVertical.png");
        }

        static internal DialogDefinition GetDefinition()
        {
            return new DialogDefinition("Emboss Vertical & Horizontal",
                FilterNames.EmbossHorizontalAndVertical);
        }
    }
}
