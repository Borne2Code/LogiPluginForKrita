using LoupedeckKritaApiClient.FiltersDialogs;

namespace Loupedeck.KritaPlugin.DynamicFolders
{
    public class FilterEmbossAllDirections : FilterDialogBase
    {
        public FilterEmbossAllDirections()
            : base(FilterNames.EmbossAllDirections)
        {
        }

        static internal FilterDialogDefinition GetDefinition()
        {
            return new FilterDialogDefinition("Emboss All directions",
                FilterNames.EmbossAllDirections);
        }
    }
}
