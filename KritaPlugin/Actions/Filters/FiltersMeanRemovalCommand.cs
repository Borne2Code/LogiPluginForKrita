using System.Reflection;
using LoupedeckKritaApiClient.ClientBase;

namespace Loupedeck.KritaPlugin
{
    // This class implements an example adjustment that counts the rotation ticks of a dial.

    public class FiltersMeanRemovalCommand : PluginDynamicCommand
    {
        private Client Client => ((KritaApplication)Plugin.ClientApplication).Client;

        // Initializes the command class.
        public FiltersMeanRemovalCommand()
            : base(displayName: "Mean Removal", description: "Apply Mean Removal filter (Enhance)", groupName: ActionGroups.Filters)
        {
        }

        protected override BitmapImage GetCommandImage(string actionParameter, PluginImageSize imageSize)
        {
            return PluginResources.BitmapFromEmbaddedRessource("Loupedeck.KritaPlugin.images.Filters.filters-MeanRemoval.png");
        }

        protected override void RunCommand(string actionParameter)
        {
            if (Client == null) return;

            Client.KritaInstance.ExecuteAction(ActionsNames.Krita_filter_mean_removal).Wait();
        }
    }
}
