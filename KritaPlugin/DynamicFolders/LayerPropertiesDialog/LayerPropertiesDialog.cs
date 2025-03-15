using LoupedeckKritaApiClient.ClientBase;

namespace Loupedeck.KritaPlugin.DynamicFolders
{
    public class LayerPropertiesDialog : DynamicFolderBase
    {
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
                dialogDefinition = FilterDialogDefinitionsList.FilterDialogDefintionList[filterName];
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

        protected override void ValidateDialog()
        {
            Dialog.Confirm().Wait();
        }

        protected override void CancelDialog()
        {
            Dialog.Cancel().Wait();
        }
    }
}
