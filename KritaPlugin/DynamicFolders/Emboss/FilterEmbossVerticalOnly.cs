using LoupedeckKritaApiClient.FiltersDialogs;

namespace Loupedeck.KritaPlugin.DynamicFolders
{
    public class FilterEmbossVerticalOnly : FilterDialogBase
    {
        public FilterEmbossVerticalOnly()
            : base(FilterNames.EmbossVerticalOnly)
        {
        }

        static internal FilterDialogDefinition GetDefinition()
        {
            return new FilterDialogDefinition("Emboss Vertical only",
                FilterNames.EmbossVerticalOnly);
        }
    }
}
