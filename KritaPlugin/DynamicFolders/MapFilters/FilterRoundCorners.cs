using System.Reflection;
using LoupedeckKritaApiClient.FiltersDialogs;

namespace Loupedeck.KritaPlugin.DynamicFolders
{
    public class FilterRoundCorners : FilterDialogBase
    {
        public FilterRoundCorners()
            : base(FilterNames.RoundCorners)
        {
        }

        public override BitmapImage GetButtonImage(PluginImageSize imageSize)
        {
            return BitmapImage.FromResource(Assembly.GetExecutingAssembly(), "Loupedeck.KritaPlugin.images.Filters.filters-RoundCorners.png");
        }

        static internal DialogDefinition GetDefinition()
        {
            return new DialogDefinition("Round Corners",
                FilterNames.RoundCorners,
                [],
                [
                    new AdjustmentDefinition("Radius", (dialog, delta) => (dialog.Dialog as KritaFilterRoundCorners).AdjustRadius((int)delta).Result, 30),
                ]);
        }
    }
}
