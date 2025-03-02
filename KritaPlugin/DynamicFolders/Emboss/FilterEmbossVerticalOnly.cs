using LoupedeckKritaApiClient.FiltersDialogs;

namespace Loupedeck.KritaPlugin.DynamicFolders
{
    public class FilterEmbossVerticalOnly : FilterDialogBase
    {
        public FilterEmbossVerticalOnly()
            : base(GetDefinition())
        {
        }

        static internal FilterDialogDefinition GetDefinition()
        {
            return new FilterDialogDefinition("Emboss Vertical only",
                FiltersEnum.EmbossVerticalOnly);
        }
    }
}
