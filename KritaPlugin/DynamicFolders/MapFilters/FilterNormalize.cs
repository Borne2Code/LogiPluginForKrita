using System.Reflection;
using LoupedeckKritaApiClient.FiltersDialogs;

namespace Loupedeck.KritaPlugin.DynamicFolders
{
    public class FilterNormalize : FilterDialogBase
    {
        public FilterNormalize()
            : base(FilterNames.Normalize)
        {
        }

        public override BitmapImage GetButtonImage(PluginImageSize imageSize)
        {
            return BitmapImage.FromResource(Assembly.GetExecutingAssembly(), "Loupedeck.KritaPlugin.images.filters-Normalize.png");
        }

        static internal DialogDefinition GetDefinition()
        {
            return new DialogDefinition("Normalize",
                FilterNames.Normalize);
        }
    }
}
