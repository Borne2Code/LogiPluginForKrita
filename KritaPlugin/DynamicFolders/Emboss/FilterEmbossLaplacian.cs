using LoupedeckKritaApiClient.FiltersDialogs;

namespace Loupedeck.KritaPlugin.DynamicFolders
{
    public class FilterEmbossLaplacian : FilterDialogBase
    {
        public FilterEmbossLaplacian()
            : base(GetDefinition())
        {
        }

        static internal FilterDialogDefinition GetDefinition()
        {
            return new FilterDialogDefinition("Emboss Laplacian",
                FiltersEnum.EmbossLaplascian);
        }
    }
}
