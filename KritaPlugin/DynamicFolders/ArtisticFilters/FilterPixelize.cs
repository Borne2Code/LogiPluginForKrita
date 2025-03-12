using System.Reflection;
using LoupedeckKritaApiClient.FiltersDialogs;

namespace Loupedeck.KritaPlugin.DynamicFolders
{
    public class FilterPixelize : FilterDialogBase
    {
        public FilterPixelize()
            : base(FilterNames.Pixelize)
        {
        }

        public override BitmapImage GetButtonImage(PluginImageSize imageSize)
        {
            return BitmapImage.FromResource(Assembly.GetExecutingAssembly(), "Loupedeck.KritaPlugin.images.filters-Pixelize.png");
        }

        static internal DialogDefinition GetDefinition()
        {
            return new DialogDefinition("Pixelize",
                FilterNames.Pixelize,
                [
                ],
                [
                    new AdjustmentDefinition("Pixel width", (dialog, delta) => (dialog.Dialog as KritaFilterPixelize).AdjustPixelWidth((int)delta).Result, 10),
                    new AdjustmentDefinition("Pixel height", (dialog, delta) => (dialog.Dialog as KritaFilterPixelize).AdjustPixelHeight((int)delta).Result, 10),
                ]);
        }
    }
}
