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
            Commands = commands;
            Adjustments = adjustments;
        }

        public string Name { get; }
        public FiltersEnum FilterType { get; }
        public FilterCommandDefinition[] Commands { get; }
        public FilterAdjustmentDefinition[] Adjustments { get; }
    }
}
