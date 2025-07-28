using LogiKritaApiClient.FiltersDialogs;

namespace Logi.KritaPlugin.DynamicFolders
{
    public class FilterEmbossVerticalAndHorizontal
    {
        static internal FilterDialogDefinition GetDefinition()
        {
            return new FilterDialogDefinition("Emboss Vertical & Horizontal",
                FilterNames.EmbossHorizontalAndVertical,
                true,
                "Logi.KritaPlugin.images.Filters.filters-EmbossHorizontalAndVertical.png");
        }
    }
}
