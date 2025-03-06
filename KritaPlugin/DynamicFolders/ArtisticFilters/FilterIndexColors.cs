using LoupedeckKritaApiClient.FiltersDialogs;

namespace Loupedeck.KritaPlugin.DynamicFolders
{
    public class FilterIndexColors : FilterDialogBase
    {
        public FilterIndexColors()
            : base(FilterNames.IndexColors)
        {
        }

        static internal FilterDialogDefinition GetDefinition()
        {
            return new FilterDialogDefinition("Index colors",
                FilterNames.IndexColors,
                [],
                []);
        }
    }
}
