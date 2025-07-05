using LoupedeckKritaApiClient.FiltersDialogs;

namespace Loupedeck.KritaPlugin.DynamicFolders
{
    public class FilterEmbossVerticalAndHorizontal
    {
        static internal FilterDialogDefinition GetDefinition()
        {
            return new FilterDialogDefinition("Emboss Vertical & Horizontal",
                FilterNames.EmbossHorizontalAndVertical,
                true,
                "Loupedeck.KritaPlugin.images.Filters.filters-EmbossHorizontalAndVertical.png");
        }
    }
}
