using Loupedeck.KritaPlugin.DynamicFolders.FilterDefinitions;
using LoupedeckKritaApiClient.FiltersDialogs;

namespace Loupedeck.KritaPlugin.DynamicFolders
{
    public class FilterEmbossAllDirections : FilterDialogBase
    {
        public FilterEmbossAllDirections()
            : base(GetDefinition())
        {
        }

        static internal FilterDialogDefinition GetDefinition()
        {
            return new FilterDialogDefinition("Emboss All directions",
                FiltersEnum.EmbossAllDirections);
        }
    }
}
