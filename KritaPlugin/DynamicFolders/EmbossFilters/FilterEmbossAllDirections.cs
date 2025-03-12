using LoupedeckKritaApiClient.FiltersDialogs;

namespace Loupedeck.KritaPlugin.DynamicFolders
{
    public class FilterEmbossAllDirections : FilterDialogBase
    {
        public FilterEmbossAllDirections()
            : base(FilterNames.EmbossAllDirections)
        {
        }

        static internal DialogDefinition GetDefinition()
        {
            return new DialogDefinition("Emboss All directions",
                FilterNames.EmbossAllDirections);
        }
    }
}
