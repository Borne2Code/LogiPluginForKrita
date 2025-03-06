using LoupedeckKritaApiClient;

namespace Loupedeck.KritaPlugin.DynamicFolders
{
    public class FilterLayerDialog : FilterDialogBase
    {
        public FilterLayerDialog()
            : base()
        {
        }

        public override bool Activate()
        {
            ResetDialog();

            (Dialog, var filterName) = FilterDialog.GetFilterLayerDialog(this.Client).Result;

            if (filterName != null)
            {
                filterDialogDefinition = FilterDialogDefinitionsList.FilterDialogDefintionList[filterName];
                ButtonActionNamesChanged();
                EncoderActionNamesChanged();
                return true;
            }
            else
            {
                filterDialogDefinition = null;
                return false;
            }
        }
    }
}
