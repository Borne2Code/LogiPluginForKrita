using LoupedeckKritaApiClient.FiltersDialogs;

namespace Loupedeck.KritaPlugin.DynamicFolders
{
    public class FilterSharpen : FilterDialogBase
    {
        public FilterSharpen()
            : base(FilterNames.Sharpen)
        {
        }

        static internal DialogDefinition GetDefinition()
        {
            return new DialogDefinition("Sharpen",
                FilterNames.Sharpen);
        }
    }
}
