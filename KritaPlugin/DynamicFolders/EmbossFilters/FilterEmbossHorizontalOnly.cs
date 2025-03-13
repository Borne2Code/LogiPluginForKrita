using System.Reflection;
using LoupedeckKritaApiClient.FiltersDialogs;

namespace Loupedeck.KritaPlugin.DynamicFolders
{
    public class FilterEmbossHorizontalOnly : FilterDialogBase
    {
        public FilterEmbossHorizontalOnly()
            : base(FilterNames.EmbossHorizontalOnly)
        {
        }

        public override BitmapImage GetButtonImage(PluginImageSize imageSize)
        {
            return BitmapImage.FromResource(Assembly.GetExecutingAssembly(), "Loupedeck.KritaPlugin.images.filters-EmbossHorizontal.png");
        }

        static internal DialogDefinition GetDefinition()
        {
            return new DialogDefinition("Emboss Horizontal only",
                FilterNames.EmbossHorizontalOnly);
        }
    }
}
