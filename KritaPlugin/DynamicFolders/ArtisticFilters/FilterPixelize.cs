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
                    new FilterAdjustmentDefinition("Pixel width", (dialog, delta) => ((KritaFilterPixelize)dialog.Dialog).AdjustPixelWidth((int)delta).Result, 10),
                    new FilterAdjustmentDefinition("Pixel height", (dialog, delta) => ((KritaFilterPixelize)dialog.Dialog).AdjustPixelHeight((int)delta).Result, 10),
                ]);
        }
    }
}
