using LoupedeckKritaApiClient.FiltersDialogs;

namespace Loupedeck.KritaPlugin.DynamicFolders
{
    public class FilterColorTransfer : FilterDialogBase
    {
        public FilterColorTransfer()
            : base(FilterNames.ColorTransfer)
        {
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
