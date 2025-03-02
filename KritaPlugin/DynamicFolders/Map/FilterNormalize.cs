using LoupedeckKritaApiClient.FiltersDialogs;

namespace Loupedeck.KritaPlugin.DynamicFolders
{
    public class FilterNormalize : FilterDialogBase
    {
        public FilterNormalize()
            : base(GetDefinition())
        {
        }

        static internal FilterDialogDefinition GetDefinition()
        {
            return new FilterDialogDefinition("Normalize",
                FiltersEnum.Normalize);
        }
    }
}
