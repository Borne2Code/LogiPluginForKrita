using LoupedeckKritaApiClient.FiltersDialogs;

namespace Loupedeck.KritaPlugin.DynamicFolders
{
    public class FilterColorMaximize : FilterDialogBase
    {
        public FilterColorMaximize()
            : base(FilterNames.Maximize)
        {
        }

        static internal DialogDefinition GetDefinition()
        {
            return new DialogDefinition("Maximize channels",
                FilterNames.Maximize);
        }
    }
}
