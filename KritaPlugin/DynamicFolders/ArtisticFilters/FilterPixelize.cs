using Loupedeck.KritaPlugin.DynamicFolders.FilterDefinitions;
using LoupedeckKritaApiClient.FiltersDialogs;

namespace Loupedeck.KritaPlugin.DynamicFolders
{
    public class FilterPixelize : FilterDialogBase
    {
        public FilterPixelize()
            : base(GetDefinition())
        {
        }

        static internal FilterDialogDefinition GetDefinition()
        {
            return new FilterDialogDefinition("Pixelize",
                FiltersEnum.Pixelize,
                [
                ],
                [
                    new FilterAdjustmentDefinition("Pixel width", (dialog, _, delta) => ((KritaFilterPixelize)dialog.Dialog).AdjustPixelWidth(delta).Result),
                    new FilterAdjustmentDefinition("Pixel height", (dialog, _, delta) => ((KritaFilterPixelize)dialog.Dialog).AdjustPixelHeight(delta).Result),
                ]);
        }
    }
}
