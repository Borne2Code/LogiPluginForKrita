using System.Reflection;
using LoupedeckKritaApiClient.FiltersDialogs;

namespace Loupedeck.KritaPlugin.DynamicFolders
{
    public class FilterColorTransfer : FilterDialogBase
    {
        public FilterColorTransfer()
            : base(FilterNames.ColorTransfer)
        {
        }

        public override BitmapImage GetButtonImage(PluginImageSize imageSize)
        {
            return BitmapImage.FromResource(Assembly.GetExecutingAssembly(), "Loupedeck.KritaPlugin.images.filters-ColorTransfer.png");
        }

        static internal DialogDefinition GetDefinition()
        {
            return new DialogDefinition("Color transfer",
                FilterNames.ColorTransfer,
                [
                    new CommandDefinition("Select file...", (dialog) => (dialog.Dialog as KritaFilterColorTranfer).OpenFileSelecionDialog()),
                ],
                []);
        }
    }
}
