using Loupedeck.KritaPlugin.DynamicFolders.FilterDefinitions;
using LoupedeckKritaApiClient.FiltersDialogs;

namespace Loupedeck.KritaPlugin.DynamicFolders
{
    public class FilterEmbossHorizontalOnly : FilterDialogBase
    {
        public FilterEmbossHorizontalOnly()
            : base(GetDefinition())
        {
        }

        static internal FilterDialogDefinition GetDefinition()
        {
            return new FilterDialogDefinition("Emboss Horizontal only",
                FiltersEnum.EmbossHorizontalOnly);
        }
    }
}
