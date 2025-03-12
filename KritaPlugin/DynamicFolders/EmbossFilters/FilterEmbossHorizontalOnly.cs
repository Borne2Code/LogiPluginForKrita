using LoupedeckKritaApiClient.FiltersDialogs;

namespace Loupedeck.KritaPlugin.DynamicFolders
{
    public class FilterEmbossHorizontalOnly : FilterDialogBase
    {
        public FilterEmbossHorizontalOnly()
            : base(FilterNames.EmbossHorizontalOnly)
        {
        }

        static internal DialogDefinition GetDefinition()
        {
            return new DialogDefinition("Emboss Horizontal only",
                FilterNames.EmbossHorizontalOnly);
        }
    }
}
