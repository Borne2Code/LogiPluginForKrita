using LoupedeckKritaApiClient.FiltersDialogs;

namespace Loupedeck.KritaPlugin.DynamicFolders
{
    public class FilterColorTransfer : FilterDialogBase
    {
        public FilterColorTransfer()
            : base(FilterNames.ColorTransfer)
        {
        }

        static internal FilterDialogDefinition GetDefinition()
        {
            return new FilterDialogDefinition("Color transfer",
                FilterNames.ColorTransfer,
                [
                    new FilterCommandDefinition("Select file...", (dialog) => ((KritaFilterColorTranfer)dialog.Dialog).OpenFileSelecionDialog()),
                ],
                []);
        }
    }
}
