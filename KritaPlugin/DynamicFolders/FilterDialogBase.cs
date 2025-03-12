namespace Loupedeck.KritaPlugin.DynamicFolders
{
    public abstract class FilterDialogBase : DynamicFolderBase
    {
        private const string ShowCreateFilterMaskName = "Set as mask";

        internal FilterDialogBase(string filterName): base(string.Empty, ActionGroups.Filters, 
            new CommandDefinition(ShowCreateFilterMaskName, (dynamicFolder) => ((LoupedeckKritaApiClient.FiltersDialogs.FilterDialogBase)dynamicFolder.Dialog).CreateMask(), true), CommandDefinition.Empty)
        {
            dialogDefinition = FilterDialogDefinitionsList.FilterDialogDefintionList[filterName];
            DisplayName = dialogDefinition.Name;
        }

        public override PluginDynamicFolderNavigation GetNavigationArea(DeviceType _)
        {
            return PluginDynamicFolderNavigation.None;
        }

        protected override bool ShowDialog()
        {
            Dialog = Client.GetFilterDialog(dialogDefinition.FilterName).Result;
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
