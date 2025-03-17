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
            switch(Client.CurrentNode.LayerType().Result)
            {
                case "paintlayer":
                case "grouplayer":
                case "clonelayer":
                case "vectorlayer":
                    {
                        Dialog = Client.GetLayerPropertiesDialog().Result;
                        dialogDefinition = GetLayerPropertiesDialogDefinition();
                    }; break;
                case "filelayer":
                    {
                        Dialog = Client.GetFileLayerPropertiesDialog().Result;
                        dialogDefinition = GetFileLayerPropertiesDialogDefinition();
                    }; break;
                case "filterlayer":
                case "filtermask":
                    {
                        (Dialog, var filterName) = Client.GetFilterLayerPropertiesDialog().Result;

                        dialogDefinition = FilterDialogDefinition.GetDialogDefinition(filterName);
                        dialogDefinition.FixedCommands = [
                            new CommandDefinition(CancelButtonName, (dynamicFolder) => ((LoupedeckKritaApiClient.FiltersDialogs.FilterDialogBase)dynamicFolder.Dialog).Cancel(), true),
                            new CommandDefinition(OkButtonName, (dynamicFolder) => ((LoupedeckKritaApiClient.FiltersDialogs.FilterDialogBase)dynamicFolder.Dialog).Confirm(), true),
                            ];
                    }; break;
                case "filllayer":
                    {

                    }; break;
            }

            ButtonActionNamesChanged();
            EncoderActionNamesChanged();
            return true;
        }

        private static DialogDefinition GetLayerPropertiesDialogDefinition()
        {
            return new DialogDefinition(
                "Layer properties",
                [
                    new CommandDefinition("Visible", (dialog) => (dialog.Dialog as LoupedeckKritaApiClient.LayerPropertiesDialog).ToggleVIsible()),
                    new CommandDefinition("Locked", (dialog) => (dialog.Dialog as LoupedeckKritaApiClient.LayerPropertiesDialog).ToggleLocked()),
                    new CommandDefinition("Inherit Alpha", (dialog) => (dialog.Dialog as LoupedeckKritaApiClient.LayerPropertiesDialog).ToggleInheritAlpha()),
                    new CommandDefinition("Alpha Locked", (dialog) => (dialog.Dialog as LoupedeckKritaApiClient.LayerPropertiesDialog).ToggleAlphaLocked()),
                    new CommandDefinition("Channel Blue", (dialog) => (dialog.Dialog as LoupedeckKritaApiClient.LayerPropertiesDialog).ToggleChannelBlue()),
                    new CommandDefinition("Channel Green", (dialog) => (dialog.Dialog as LoupedeckKritaApiClient.LayerPropertiesDialog).ToggleChannelGreen()),
                    new CommandDefinition("Channel Red", (dialog) => (dialog.Dialog as LoupedeckKritaApiClient.LayerPropertiesDialog).ToggleChannelRed()),
                    new CommandDefinition("Channel Alpha", (dialog) => (dialog.Dialog as LoupedeckKritaApiClient.LayerPropertiesDialog).ToggleChannelAlpha()),
                ],
                [
                    new CommandDefinition(CancelButtonName, (dynamicFolder) => ((LoupedeckKritaApiClient.LayerPropertiesDialog)dynamicFolder.Dialog).Cancel(), true),
                    new CommandDefinition(OkButtonName, (dynamicFolder) => ((LoupedeckKritaApiClient.LayerPropertiesDialog)dynamicFolder.Dialog).Confirm(), true),
                ],
                [
                    new AdjustmentDefinition("Opacity", (dialog, diff) => (dialog.Dialog as LoupedeckKritaApiClient.LayerPropertiesDialog).AdjustOpacity((int)diff).Result, 255),
                ]);
        }

        private static DialogDefinition GetFileLayerPropertiesDialogDefinition()
        {
            return new DialogDefinition(
                "File Layer properties",
                [
                    new CommandDefinition("Choose file", (dialog) => (dialog.Dialog as LoupedeckKritaApiClient.FileLayerPropertiesDialog).OpenFileSelector()),
                    new CommandDefinition("No scale", (dialog) => (dialog.Dialog as LoupedeckKritaApiClient.FileLayerPropertiesDialog).SelectNoScale()),
                    new CommandDefinition("Scale to image", (dialog) => (dialog.Dialog as LoupedeckKritaApiClient.FileLayerPropertiesDialog).SelectScaleToImage()),
                    new CommandDefinition("Scale  to PPI", (dialog) => (dialog.Dialog as LoupedeckKritaApiClient.FileLayerPropertiesDialog).SelectScaleToPpi()),
                ],
                [
                    new CommandDefinition(CancelButtonName, (dynamicFolder) => ((LoupedeckKritaApiClient.FileLayerPropertiesDialog)dynamicFolder.Dialog).Cancel(), true),
                    new CommandDefinition(OkButtonName, (dynamicFolder) => ((LoupedeckKritaApiClient.FileLayerPropertiesDialog)dynamicFolder.Dialog).Confirm(), true),
                ],
                []);
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
