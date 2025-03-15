using System.Reflection;
using LoupedeckKritaApiClient.FiltersDialogs;

namespace Loupedeck.KritaPlugin.DynamicFolders
{
    public class FilterEmbossAllDirections : FilterDialogBase
    {
        public FilterEmbossAllDirections()
            : base(FilterNames.EmbossAllDirections)
        {
        }

        public override BitmapImage GetButtonImage(PluginImageSize imageSize)
        {
            return BitmapImage.FromResource(Assembly.GetExecutingAssembly(), "Loupedeck.KritaPlugin.images.Filters.filters-EmbossAllDirections.png");
        }

        static internal DialogDefinition GetDefinition()
        {
            return new DialogDefinition("Emboss All directions",
                FilterNames.EmbossAllDirections);
        }
    }
}
