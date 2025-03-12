using LoupedeckKritaApiClient.FiltersDialogs;

namespace Loupedeck.KritaPlugin.DynamicFolders
{
    public class FilterIndexColors : FilterDialogBase
    {
        public FilterIndexColors()
            : base(FilterNames.IndexColors)
        {
        }

        static internal DialogDefinition GetDefinition()
        {
            return new DialogDefinition("Index colors",
                FilterNames.IndexColors,
                [],
                []);
        }
    }
}
