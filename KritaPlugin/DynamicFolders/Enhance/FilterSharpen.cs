using LoupedeckKritaApiClient.FiltersDialogs;

namespace Loupedeck.KritaPlugin.DynamicFolders
{
    public class FilterSharpen : FilterDialogBase
    {
        public FilterSharpen()
            : base(FilterNames.Sharpen)
        {
        }

        static internal FilterDialogDefinition GetDefinition()
        {
            return new FilterDialogDefinition("Sharpen",
                FilterNames.Sharpen);
        }
    }
}
