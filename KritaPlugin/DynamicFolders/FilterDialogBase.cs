
using System.Reflection;

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
            dialogDefinition.FixedCommands = [
                    new CommandDefinition(ShowCreateFilterMaskName, (dynamicFolder) => ((LoupedeckKritaApiClient.FiltersDialogs.FilterDialogBase)dynamicFolder.Dialog).CreateMask(), true),
                    CommandDefinition.Empty,
                    new CommandDefinition(CancelButtonName, (dynamicFolder) => ((LoupedeckKritaApiClient.FiltersDialogs.FilterDialogBase)dynamicFolder.Dialog).Cancel(), true),
                    new CommandDefinition(OkButtonName, (dynamicFolder) => ((LoupedeckKritaApiClient.FiltersDialogs.FilterDialogBase)dynamicFolder.Dialog).Confirm(), true),
                ];
        }

        public override BitmapImage GetButtonImage(PluginImageSize imageSize)
        {
            return BitmapImage.FromResource(Assembly.GetExecutingAssembly(), (dialogDefinition as FilterDialogDefinition).IconResourceName);
        }

        protected override bool ShowDialog()
        {
            Dialog = Client.GetFilterDialog((dialogDefinition as FilterDialogDefinition).FilterName).Result;
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
