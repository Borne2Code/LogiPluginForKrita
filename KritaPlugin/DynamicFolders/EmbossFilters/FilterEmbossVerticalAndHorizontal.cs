using LoupedeckKritaApiClient.FiltersDialogs;

namespace Loupedeck.KritaPlugin.DynamicFolders
{
    public class FilterEmbossVerticalAndHorizontal : FilterDialogBase
    {
        public FilterEmbossVerticalAndHorizontal()
            : base(FilterNames.EmbossHorizontalAndVertical)
        {
        }

        static internal DialogDefinition GetDefinition()
        {
            return new DialogDefinition("Emboss Vertical & Horizontal",
                FilterNames.EmbossHorizontalAndVertical);
        }
    }
}
