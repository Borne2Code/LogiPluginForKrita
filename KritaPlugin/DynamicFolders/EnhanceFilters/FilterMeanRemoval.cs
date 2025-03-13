using System.Reflection;
using LoupedeckKritaApiClient.FiltersDialogs;

namespace Loupedeck.KritaPlugin.DynamicFolders
{
    public class FilterMeanRemoval : FilterDialogBase
    {
        public FilterMeanRemoval()
            : base(FilterNames.MeanRemoval)
        {
        }

        public override BitmapImage GetButtonImage(PluginImageSize imageSize)
        {
            return BitmapImage.FromResource(Assembly.GetExecutingAssembly(), "Loupedeck.KritaPlugin.images.filters-MeanRemoval.png");
        }

        static internal DialogDefinition GetDefinition()
        {
            return new DialogDefinition("Mean removal",
                FilterNames.MeanRemoval);
        }
    }
}
