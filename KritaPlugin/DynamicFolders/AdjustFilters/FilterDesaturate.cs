using System.Runtime.CompilerServices;
using LoupedeckKritaApiClient.FiltersDialogs;

namespace Loupedeck.KritaPlugin.DynamicFolders
{
    public class FilterDesaturate : FilterDialogBase
    {
        public FilterDesaturate()
            : base(GetDefinition())
        {
        }

        static internal FilterDialogDefinition GetDefinition()
        {
            return new FilterDialogDefinition("Desaturate",
                FiltersEnum.Desaturate,
                [
                    new FilterCommandDefinition("Lightness", (dialog) => ((KritaFilterDesaturate)dialog.Dialog).SelectLightness()),
                    new FilterCommandDefinition("Luminosity (BT709)", (dialog) => ((KritaFilterDesaturate)dialog.Dialog).SelectLuminosityBT709()),
                    new FilterCommandDefinition("Luminosity (BT601)", (dialog) => ((KritaFilterDesaturate)dialog.Dialog).SelectLuminosityBT601()),
                    new FilterCommandDefinition("Average", (dialog) => ((KritaFilterDesaturate)dialog.Dialog).SelectAverage()),
                    new FilterCommandDefinition("Minimum", (dialog) => ((KritaFilterDesaturate)dialog.Dialog).SelectMin()),
                    new FilterCommandDefinition("Maximum", (dialog) => ((KritaFilterDesaturate)dialog.Dialog).SelectMax()),
                ],
                []);
        }
    }
}
