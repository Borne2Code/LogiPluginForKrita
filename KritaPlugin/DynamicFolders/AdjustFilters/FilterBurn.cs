using System.Reflection;
using LoupedeckKritaApiClient.FiltersDialogs;

namespace Loupedeck.KritaPlugin.DynamicFolders
{
    public class FilterBurn : FilterDialogBase
    {
        public FilterBurn()
            : base(FilterNames.Burn)
        {
        }

        public override BitmapImage GetButtonImage(PluginImageSize imageSize)
        {
            return BitmapImage.FromResource(Assembly.GetExecutingAssembly(), "Loupedeck.KritaPlugin.images.filters-Burn.png");
        }

        static internal DialogDefinition GetDefinition()
        {
            return new DialogDefinition("Burn",
                FilterNames.Burn,
                [
                    new CommandDefinition("Shadows", (dialog) => ((KritaFilterBurn)dialog.Dialog).SelectShadows()),
                    new CommandDefinition("Midtones", (dialog) => ((KritaFilterBurn)dialog.Dialog).SelectMidTones()),
                    new CommandDefinition("Highlights", (dialog) => ((KritaFilterBurn)dialog.Dialog).SelectHighLights())
                ],
                [
                    new AdjustmentDefinition("Exposure", (dialog, delta) => ((KritaFilterBurn)dialog.Dialog).AdjustExposureValue((int)delta).Result, 50)
                ]);
        }
    }
}
