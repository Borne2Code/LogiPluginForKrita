
using System.Reflection;

namespace Loupedeck.KritaPlugin.DynamicFolders
{
    public abstract class FilterDialogBase : DynamicFolderBase
    {
        internal FilterDialogBase(string filterName): base(
            FilterDialogDefinitionsList.FilterDialogDefintionList[filterName].Name,
            null,
            ActionGroups.Filters)
        {
            dialogDefinition = FilterDialogDefinitionsList.FilterDialogDefintionList[filterName];
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
