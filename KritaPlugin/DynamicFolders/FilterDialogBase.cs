using System.Reflection;
using LoupedeckKritaApiClient.FiltersDialogs;

namespace Loupedeck.KritaPlugin.DynamicFolders
{
    public abstract class FilterDialogBase : DynamicFolderBase
    {
        private const string ShowCreateFilterMaskName = "Set as mask";
        private const string CancelButtonName = "Cancel";
        private const string OkButtonName = "OK";

        internal FilterDialogBase(string filterName): base(
            null,
            null,
            ActionGroups.Filters)
        {
            dialogDefinition = FilterDialogDefinition.GetDialogDefinition(filterName);
            DisplayName = dialogDefinition.Name;
            if ((dialogDefinition as FilterDialogDefinition).IsMaskEnabled)
                dialogDefinition.FixedCommands = [
                        new CommandDefinition(ShowCreateFilterMaskName, (dynamicFolder) => ((LoupedeckKritaApiClient.FiltersDialogs.FilterDialogBase)dynamicFolder.Dialog).CreateMask(), true),
                        new CommandDefinition(CancelButtonName, (dynamicFolder) => ((LoupedeckKritaApiClient.FiltersDialogs.FilterDialogBase)dynamicFolder.Dialog).Cancel(), true),
                        new CommandDefinition(OkButtonName, (dynamicFolder) => ((LoupedeckKritaApiClient.FiltersDialogs.FilterDialogBase)dynamicFolder.Dialog).Confirm(), true),
                    ];
            else
                dialogDefinition.FixedCommands = [
                        new CommandDefinition(CancelButtonName, (dynamicFolder) => ((LoupedeckKritaApiClient.FiltersDialogs.FilterDialogBase)dynamicFolder.Dialog).Cancel(), true),
                        new CommandDefinition(OkButtonName, (dynamicFolder) => ((LoupedeckKritaApiClient.FiltersDialogs.FilterDialogBase)dynamicFolder.Dialog).Confirm(), true),
                    ];
        }

        public override BitmapImage GetButtonImage(PluginImageSize imageSize)
        {
            return PluginResources.BitmapFromEmbaddedRessource((dialogDefinition as FilterDialogDefinition).IconResourceName);
        }

        protected override bool ShowDialog()
        {
            if (Client == null) return false;

            Dialog = FilterNames.GetFilterDialogByFilterName(Client, (dialogDefinition as FilterDialogDefinition).FilterName, false);
            Client.KritaInstance.ExecuteAction((Dialog as LoupedeckKritaApiClient.FiltersDialogs.FilterDialogBase).ActionName).Wait();
            Dialog.AttachDialog().Wait();

            return true;
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
