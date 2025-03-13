using System.Reflection;
using LoupedeckKritaApiClient.FiltersDialogs;

namespace Loupedeck.KritaPlugin.DynamicFolders
{
    public class FilterSmallTiles : FilterDialogBase
    {
        public FilterSmallTiles()
            : base(FilterNames.SmallTiles)
        {
        }

        public override BitmapImage GetButtonImage(PluginImageSize imageSize)
        {
            return BitmapImage.FromResource(Assembly.GetExecutingAssembly(), "Loupedeck.KritaPlugin.images.filters-SmallTiles.png");
        }

        static internal DialogDefinition GetDefinition()
        {
            return new DialogDefinition("Small Tiles",
                FilterNames.SmallTiles,
                [],
                [
                    new AdjustmentDefinition("Number", (dialog, delta) => (dialog.Dialog as KritaFilterSmallTiles).AdjustNumberOfTiles((int)delta).Result, 2),
                ]);
        }
    }
}
