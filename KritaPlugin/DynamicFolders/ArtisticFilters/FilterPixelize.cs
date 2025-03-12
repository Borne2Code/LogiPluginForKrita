using LoupedeckKritaApiClient.FiltersDialogs;

namespace Loupedeck.KritaPlugin.DynamicFolders
{
    public class FilterPixelize : FilterDialogBase
    {
        public FilterPixelize()
            : base(FilterNames.Pixelize)
        {
        }

        static internal DialogDefinition GetDefinition()
        {
            return new DialogDefinition("Pixelize",
                FilterNames.Pixelize,
                [
                ],
                [
                    new AdjustmentDefinition("Pixel width", (dialog, delta) => (dialog.Dialog as KritaFilterPixelize).AdjustPixelWidth((int)delta).Result, 10),
                    new AdjustmentDefinition("Pixel height", (dialog, delta) => (dialog.Dialog as KritaFilterPixelize).AdjustPixelHeight((int)delta).Result, 10),
                ]);
        }
    }
}
