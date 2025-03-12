using LoupedeckKritaApiClient.FiltersDialogs;

namespace Loupedeck.KritaPlugin.DynamicFolders
{
    public class FilterEmbossVerticalOnly : FilterDialogBase
    {
        public FilterEmbossVerticalOnly()
            : base(FilterNames.EmbossVerticalOnly)
        {
        }

        static internal DialogDefinition GetDefinition()
        {
            return new DialogDefinition("Emboss Vertical only",
                FilterNames.EmbossVerticalOnly);
        }
    }
}
