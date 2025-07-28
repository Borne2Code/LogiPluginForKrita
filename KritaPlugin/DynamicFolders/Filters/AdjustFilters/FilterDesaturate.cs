using LogiKritaApiClient.FiltersDialogs;

namespace Logi.KritaPlugin.DynamicFolders
{
    public class FilterDesaturate : FilterDialogBase
    {
        public FilterDesaturate()
            : base(FilterNames.Desaturate)
        {
        }

        static internal FilterDialogDefinition GetDefinition()
        {
            return new FilterDialogDefinition("Desaturate",
                FilterNames.Desaturate,
                true,
                "Logi.KritaPlugin.images.Filters.filters-Desaturate.png",
                [
                    new CommandDefinition("Lightness", (dialog) => ((KritaFilterDesaturate)dialog.Dialog).SelectLightness()),
                    new CommandDefinition("Luminosity (BT709)", (dialog) => ((KritaFilterDesaturate)dialog.Dialog).SelectLuminosityBT709()),
                    new CommandDefinition("Luminosity (BT601)", (dialog) => ((KritaFilterDesaturate)dialog.Dialog).SelectLuminosityBT601()),
                    new CommandDefinition("Average", (dialog) => ((KritaFilterDesaturate)dialog.Dialog).SelectAverage()),
                    new CommandDefinition("Minimum", (dialog) => ((KritaFilterDesaturate)dialog.Dialog).SelectMin()),
                    new CommandDefinition("Maximum", (dialog) => ((KritaFilterDesaturate)dialog.Dialog).SelectMax()),
                ]);
        }
    }
}
