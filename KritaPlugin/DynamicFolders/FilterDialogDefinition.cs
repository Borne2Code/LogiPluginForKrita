namespace Loupedeck.KritaPlugin.DynamicFolders
{
    public class FilterDialogDefinition: DialogDefinition
    {
        private const string ShowCreateFilterMaskName = "Set as mask";

        public FilterDialogDefinition(string name,
            string filterName,
            string iconResourceName = null,
            CommandDefinition[] commands = null,
            AdjustmentDefinition[] adjustments = null):

            base(name, 
                commands, 
                new[] { 
                    new CommandDefinition(ShowCreateFilterMaskName, (dynamicFolder) => ((LoupedeckKritaApiClient.FiltersDialogs.FilterDialogBase)dynamicFolder.Dialog).CreateMask(), true),
                    CommandDefinition.Empty
                },
                adjustments)
        {
            FilterName = filterName;
            IconResourceName = iconResourceName;
            HasDialog = commands != null;
        }

        public string FilterName { get; }
        public string IconResourceName { get; }
        public bool HasDialog { get; }
    }
}
