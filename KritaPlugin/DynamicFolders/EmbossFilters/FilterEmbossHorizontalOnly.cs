using LoupedeckKritaApiClient.FiltersDialogs;

namespace Loupedeck.KritaPlugin.DynamicFolders
{
    public class FilterEmbossHorizontalOnly : FilterDialogBase
    {
        public FilterEmbossHorizontalOnly()
            : base(FilterNames.EmbossHorizontalOnly)
        {
        }

        static internal FilterDialogDefinition GetDefinition()
        {
            return new FilterDialogDefinition("Emboss Horizontal only",
                FilterNames.EmbossHorizontalOnly,
                "Loupedeck.KritaPlugin.images.Filters.filters-EmbossHorizontal.png");
        }
    }
}
