using System.Reflection;
using LoupedeckKritaApiClient.FiltersDialogs;

namespace Loupedeck.KritaPlugin.DynamicFolders
{
    public class FilterEmboss : FilterDialogBase
    {
        public FilterEmboss()
            : base(FilterNames.Emboss)
        {
        }

        public override BitmapImage GetButtonImage(PluginImageSize imageSize)
        {
            return BitmapImage.FromResource(Assembly.GetExecutingAssembly(), "Loupedeck.KritaPlugin.images.Filters.filters-Emboss.png");
        }

        static internal DialogDefinition GetDefinition()
        {
            return new DialogDefinition("Emboss",
                FilterNames.Emboss,
                [],
                [
                    new AdjustmentDefinition("Depth", (dialog, delta) => (dialog.Dialog as KritaFilterEmboss).AdjustDepth((int)delta).Result, 30),
                ]);
        }
    }
}
