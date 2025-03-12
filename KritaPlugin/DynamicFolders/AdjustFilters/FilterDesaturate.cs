using System.Reflection;
using LoupedeckKritaApiClient.FiltersDialogs;

namespace Loupedeck.KritaPlugin.DynamicFolders
{
    public class FilterDesaturate : FilterDialogBase
    {
        public FilterDesaturate()
            : base(FilterNames.Desaturate)
        {
        }

        public override BitmapImage GetButtonImage(PluginImageSize imageSize)
        {
            return BitmapImage.FromResource(Assembly.GetExecutingAssembly(), "Loupedeck.KritaPlugin.images.filters-Desaturate.png");
        }

        static internal DialogDefinition GetDefinition()
        {
            return new DialogDefinition("Desaturate",
                FilterNames.Desaturate,
                [
                    new CommandDefinition("Lightness", (dialog) => ((KritaFilterDesaturate)dialog.Dialog).SelectLightness()),
                    new CommandDefinition("Luminosity (BT709)", (dialog) => ((KritaFilterDesaturate)dialog.Dialog).SelectLuminosityBT709()),
                    new CommandDefinition("Luminosity (BT601)", (dialog) => ((KritaFilterDesaturate)dialog.Dialog).SelectLuminosityBT601()),
                    new CommandDefinition("Average", (dialog) => ((KritaFilterDesaturate)dialog.Dialog).SelectAverage()),
                    new CommandDefinition("Minimum", (dialog) => ((KritaFilterDesaturate)dialog.Dialog).SelectMin()),
                    new CommandDefinition("Maximum", (dialog) => ((KritaFilterDesaturate)dialog.Dialog).SelectMax()),
                ],
                []);
        }
    }
}
