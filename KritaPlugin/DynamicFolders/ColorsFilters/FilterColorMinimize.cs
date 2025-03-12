using LoupedeckKritaApiClient.FiltersDialogs;

namespace Loupedeck.KritaPlugin.DynamicFolders
{
    public class FilterColorMinimize : FilterDialogBase
    {
        public FilterColorMinimize()
            : base(FilterNames.Minimize)
        {
        }

        static internal DialogDefinition GetDefinition()
        {
            return new DialogDefinition("Minimize channels",
                FilterNames.Minimize);
        }
    }
}
