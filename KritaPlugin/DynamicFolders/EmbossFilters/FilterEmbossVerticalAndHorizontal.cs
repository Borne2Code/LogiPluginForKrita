using LoupedeckKritaApiClient.FiltersDialogs;

namespace Loupedeck.KritaPlugin.DynamicFolders
{
    public class FilterEmbossVerticalAndHorizontal : FilterDialogBase
    {
        public FilterEmbossVerticalAndHorizontal()
            : base(FilterNames.EmbossHorizontalAndVertical)
        {
        }

        static internal FilterDialogDefinition GetDefinition()
        {
            return new FilterDialogDefinition("Emboss Vertical & Horizontal",
                FilterNames.EmbossHorizontalAndVertical,
                "Loupedeck.KritaPlugin.images.Filters.filters-EmbossHorizontalAndVertical.png");
        }
    }
}
