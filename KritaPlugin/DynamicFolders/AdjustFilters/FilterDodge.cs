using System.Reflection;
using LoupedeckKritaApiClient.FiltersDialogs;

namespace Loupedeck.KritaPlugin.DynamicFolders
{
    public class FilterDodge : FilterDialogBase
    {
        public FilterDodge()
            : base(FilterNames.Dodge)
        {
        }

        public override BitmapImage GetButtonImage(PluginImageSize imageSize)
        {
            return BitmapImage.FromResource(Assembly.GetExecutingAssembly(), "Loupedeck.KritaPlugin.images.Filters.filters-Dodge.png");
        }

        static internal DialogDefinition GetDefinition()
        {
            return new DialogDefinition("Dodge",
                FilterNames.Dodge,
                [
                    new CommandDefinition("Shadows", (dialog) => ((KritaFilterDodge)dialog.Dialog).SelectShadows()),
                    new CommandDefinition("Midtones", (dialog) => ((KritaFilterDodge)dialog.Dialog).SelectMidTones()),
                    new CommandDefinition("Highlights", (dialog) => ((KritaFilterDodge)dialog.Dialog).SelectHighLights())
                ],
                [
                    new AdjustmentDefinition("Exposure", (dialog, delta) => ((KritaFilterDodge)dialog.Dialog).AdjustExposureValue((int)delta).Result, 50)
                ]);
        }
    }
}
