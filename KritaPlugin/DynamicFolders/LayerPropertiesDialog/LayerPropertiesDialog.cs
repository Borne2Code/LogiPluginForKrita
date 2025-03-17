using LoupedeckKritaApiClient.ClientBase;

namespace Loupedeck.KritaPlugin.DynamicFolders
{
    public class LayerPropertiesDialog : DynamicFolderBase
    {
        private const string CancelButtonName = "Cancel";
        private const string OkButtonName = "OK";

        public LayerPropertiesDialog()
            : base("Layer Properties (dynamic)",
                  "Loupedeck.KritaPlugin.images.Layers.Properties.png",
                  ActionGroups.Layers)
        {
        }

        protected override bool ShowDialog()
        {
            (Dialog, var filterName) = Client.GetLayerPropertiesDialog().Result;

            if (filterName != null)
            {
                dialogDefinition = FilterDialogDefinition.GetDialogDefinition(filterName);
                dialogDefinition.FixedCommands = [
                    new CommandDefinition(CancelButtonName, (dynamicFolder) => ((LoupedeckKritaApiClient.FiltersDialogs.FilterDialogBase)dynamicFolder.Dialog).Cancel(), true),
                    new CommandDefinition(OkButtonName, (dynamicFolder) => ((LoupedeckKritaApiClient.FiltersDialogs.FilterDialogBase)dynamicFolder.Dialog).Confirm(), true),
                ];
                ButtonActionNamesChanged();
                EncoderActionNamesChanged();
                return true;
            }
            else
            {
                dialogDefinition = null;
                return false;
            }
        }

        protected override void ResetDialog()
        {
            if (Dialog != null)
            {
                try
                {
                    Dialog.DisposeAsync().AsTask().Wait();
                }
                finally
                {
                    Dialog = null;
                }
            }
        }
    }
}
