using LoupedeckKritaApiClient.FiltersDialogs;

namespace Loupedeck.KritaPlugin.DynamicFolders
{
    public class FilterEmbossLaplacian : FilterDialogBase
    {
        public FilterEmbossLaplacian()
            : base(FilterNames.EmbossLaplascian)
        {
        }

        static internal FilterDialogDefinition GetDefinition()
        {
            return new FilterDialogDefinition("Emboss Laplacian",
                FilterNames.EmbossLaplascian);
        }
    }
}
