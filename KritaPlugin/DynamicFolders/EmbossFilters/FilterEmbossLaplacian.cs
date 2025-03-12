using LoupedeckKritaApiClient.FiltersDialogs;

namespace Loupedeck.KritaPlugin.DynamicFolders
{
    public class FilterEmbossLaplacian : FilterDialogBase
    {
        public FilterEmbossLaplacian()
            : base(FilterNames.EmbossLaplascian)
        {
        }

        static internal DialogDefinition GetDefinition()
        {
            return new DialogDefinition("Emboss Laplacian",
                FilterNames.EmbossLaplascian);
        }
    }
}
