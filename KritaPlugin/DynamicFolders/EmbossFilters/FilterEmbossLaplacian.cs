using System.Reflection;
using LoupedeckKritaApiClient.FiltersDialogs;

namespace Loupedeck.KritaPlugin.DynamicFolders
{
    public class FilterEmbossLaplacian : FilterDialogBase
    {
        public FilterEmbossLaplacian()
            : base(FilterNames.EmbossLaplascian)
        {
        }

        public override BitmapImage GetButtonImage(PluginImageSize imageSize)
        {
            return BitmapImage.FromResource(Assembly.GetExecutingAssembly(), "Loupedeck.KritaPlugin.images.filters-EmbossLaplacian.png");
        }

        static internal DialogDefinition GetDefinition()
        {
            return new DialogDefinition("Emboss Laplacian",
                FilterNames.EmbossLaplascian);
        }
    }
}
