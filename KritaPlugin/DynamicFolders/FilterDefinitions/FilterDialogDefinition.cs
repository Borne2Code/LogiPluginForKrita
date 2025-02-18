using LoupedeckKritaApiClient.FiltersDialogs;

namespace Loupedeck.KritaPlugin.DynamicFolders.FilterDefinitions
{
    internal class FilterDialogDefinition
    {
        public FilterDialogDefinition(string name,
            FiltersEnum filterType,
            FilterCommandDefinition[] commands,
            FilterAdjustmentDefinition[] adjustments)
        {
            Name = name;
            FilterType = filterType;
            HasDialog = true;
            Commands = commands;
            Adjustments = adjustments;
        }

        public FilterDialogDefinition(string name,
            FiltersEnum filterType)
        {
            Name = name;
            FilterType = filterType;
            HasDialog = false;
            Commands = null;
            Adjustments = null;
        }

        public string Name { get; }
        public FiltersEnum FilterType { get; }
        public bool HasDialog { get; }
        public FilterCommandDefinition[] Commands { get; }
        public FilterAdjustmentDefinition[] Adjustments { get; }
    }
}
