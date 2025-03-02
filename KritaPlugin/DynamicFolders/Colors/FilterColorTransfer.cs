using LoupedeckKritaApiClient.FiltersDialogs;

namespace Loupedeck.KritaPlugin.DynamicFolders
{
    public class FilterColorTransfer : FilterDialogBase
    {
        public FilterColorTransfer()
            : base(GetDefinition())
        {
        }

        static internal FilterDialogDefinition GetDefinition()
        {
            return new FilterDialogDefinition("Color transfer",
                FiltersEnum.ColorTransfer,
                [
                    new FilterCommandDefinition("Select file...", (dialog) => ((KritaFilterColorTranfer)dialog.Dialog).OpenFileSelecionDialog()),
                ],
                []);
        }
    }
}
