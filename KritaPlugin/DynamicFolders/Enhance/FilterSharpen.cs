using LoupedeckKritaApiClient.FiltersDialogs;

namespace Loupedeck.KritaPlugin.DynamicFolders
{
    public class FilterSharpen : FilterDialogBase
    {
        public FilterSharpen()
            : base(GetDefinition())
        {
        }

        static internal FilterDialogDefinition GetDefinition()
        {
            return new FilterDialogDefinition("Sharpen",
                FiltersEnum.Sharpen);
        }
    }
}
