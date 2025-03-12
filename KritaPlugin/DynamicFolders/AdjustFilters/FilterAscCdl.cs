using System.Reflection;
using LoupedeckKritaApiClient.FiltersDialogs;

namespace Loupedeck.KritaPlugin.DynamicFolders
{
    public class FilterAscCdl : FilterDialogBase
    {
        public FilterAscCdl()
            : base(FilterNames.AscCdl)
        {
        }

        public override BitmapImage GetButtonImage(PluginImageSize imageSize)
        {
            return BitmapImage.FromResource(Assembly.GetExecutingAssembly(), "Loupedeck.KritaPlugin.images.filters-AscCdl.png");
        }

        static internal DialogDefinition GetDefinition()
        {
            return new DialogDefinition("Slope / Offset / Power (Asc-Cdl)",
                FilterNames.AscCdl,
                [],
                []);
        }
    }
}
