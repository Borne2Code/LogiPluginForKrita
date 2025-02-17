using Loupedeck.KritaPlugin.DynamicFolders.FilterDefinitions;
using LoupedeckKritaApiClient.FiltersDialogs;

namespace Loupedeck.KritaPlugin.DynamicFolders
{
    public class FilterEmbossVerticalAndHorizontal : FilterDialogBase
    {
        public FilterEmbossVerticalAndHorizontal()
            : base(GetDefinition())
        {
        }

        static internal FilterDialogDefinition GetDefinition()
        {
            return new FilterDialogDefinition("Emboss Vertical & Horizontal",
                FiltersEnum.EmbossHorizontalAndVertical,
                [],
                []);
        }
    }
}
