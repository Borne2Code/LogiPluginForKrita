using Logi.KritaPlugin;
using LogiKritaApiClient;
using LogiKritaApiClient.ClientBase;
using LogiKritaApiClient.FiltersDialogs;

namespace Logi.KritaPlugin.DynamicFolders
{
    public class LayerPropertiesDialog : DynamicFolderBase
    {
        private const string CancelButtonName = "Cancel";
        private const string OkButtonName = "OK";

        public LayerPropertiesDialog()
            : base("Layer Properties (dynamic)",
                  "Logi.KritaPlugin.images.Layers.Properties.png",
                  ActionGroups.Layers)
        {
        }

        protected override bool ShowDialog()
        {
            if (Client == null) return false;

            Client.KritaInstance.ExecuteAction(ActionsNames.Layer_properties).Wait();

            switch (Client.CurrentNode.LayerType().Result)
            {
                case "paintlayer":
                case "grouplayer":
                case "clonelayer":
                case "vectorlayer":
                    {
                        Dialog = new LogiKritaApiClient.LayerPropertiesDialog(Client);
                        Dialog.AttachDialog().Wait();
                        dialogDefinition = GetLayerPropertiesDialogDefinition();
                    }; break;
                case "filelayer":
                    {
                        Dialog = new FileLayerPropertiesDialog(Client);
                        Dialog.AttachDialog().Wait();
                        dialogDefinition = GetFileLayerPropertiesDialogDefinition();
                    }; break;
                case "filterlayer":
                case "filtermask":
                    {
                        var filter = Client.CurrentNode.Filter().Result;
                        try
                        {
                            var filterName = filter.name().Result;
                            Dialog = FilterNames.GetFilterDialogByFilterName(Client, filterName, true);
                            Dialog.AttachDialog().Wait();

                            dialogDefinition = FilterDialogDefinition.GetDialogDefinition(filterName);
                            dialogDefinition.FixedCommands = [
                                new CommandDefinition(CancelButtonName, (dynamicFolder) => ((LogiKritaApiClient.FiltersDialogs.FilterDialogBase)dynamicFolder.Dialog).Cancel(), true),
                                new CommandDefinition(OkButtonName, (dynamicFolder) => ((LogiKritaApiClient.FiltersDialogs.FilterDialogBase)dynamicFolder.Dialog).Confirm(), true),
                                ];
                        }
                        finally
                        {
                            filter.DisposeAsync().AsTask().Wait();
                        }
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
                    new AdjustmentDefinition("Opacity", (dialog, diff) => (dialog.Dialog as LogiKritaApiClient.LayerPropertiesDialog).AdjustOpacity((int)diff).Result, 255),

                    new CommandDefinition("Visible", (dialog) => (dialog.Dialog as LogiKritaApiClient.LayerPropertiesDialog).ToggleVIsible()),
                    new CommandDefinition("Locked", (dialog) => (dialog.Dialog as LogiKritaApiClient.LayerPropertiesDialog).ToggleLocked()),
                    new CommandDefinition("Inherit Alpha", (dialog) => (dialog.Dialog as LogiKritaApiClient.LayerPropertiesDialog).ToggleInheritAlpha()),
                    new CommandDefinition("Alpha Locked", (dialog) => (dialog.Dialog as LogiKritaApiClient.LayerPropertiesDialog).ToggleAlphaLocked()),
                    new CommandDefinition("Channel Blue", (dialog) => (dialog.Dialog as LogiKritaApiClient.LayerPropertiesDialog).ToggleChannelBlue()),
                    new CommandDefinition("Channel Green", (dialog) => (dialog.Dialog as LogiKritaApiClient.LayerPropertiesDialog).ToggleChannelGreen()),
                    new CommandDefinition("Channel Red", (dialog) => (dialog.Dialog as LogiKritaApiClient.LayerPropertiesDialog).ToggleChannelRed()),
                    new CommandDefinition("Channel Alpha", (dialog) => (dialog.Dialog as LogiKritaApiClient.LayerPropertiesDialog).ToggleChannelAlpha()),
                ],
                [
                    new CommandDefinition(CancelButtonName, (dynamicFolder) => ((LogiKritaApiClient.LayerPropertiesDialog)dynamicFolder.Dialog).Cancel(), true),
                    new CommandDefinition(OkButtonName, (dynamicFolder) => ((LogiKritaApiClient.LayerPropertiesDialog)dynamicFolder.Dialog).Confirm(), true),
                ]);
        }

        private static DialogDefinition GetFileLayerPropertiesDialogDefinition()
        {
            return new DialogDefinition(
                "File Layer properties",
                [
                    new CommandDefinition("Choose file", (dialog) => (dialog.Dialog as LogiKritaApiClient.FileLayerPropertiesDialog).OpenFileSelector()),
                    new CommandDefinition("No scale", (dialog) => (dialog.Dialog as LogiKritaApiClient.FileLayerPropertiesDialog).SelectNoScale()),
                    new CommandDefinition("Scale to image", (dialog) => (dialog.Dialog as LogiKritaApiClient.FileLayerPropertiesDialog).SelectScaleToImage()),
                    new CommandDefinition("Scale  to PPI", (dialog) => (dialog.Dialog as LogiKritaApiClient.FileLayerPropertiesDialog).SelectScaleToPpi()),
                ],
                [
                    new CommandDefinition(CancelButtonName, (dynamicFolder) => ((LogiKritaApiClient.FileLayerPropertiesDialog)dynamicFolder.Dialog).Cancel(), true),
                    new CommandDefinition(OkButtonName, (dynamicFolder) => ((LogiKritaApiClient.FileLayerPropertiesDialog)dynamicFolder.Dialog).Confirm(), true),
                ]);
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
