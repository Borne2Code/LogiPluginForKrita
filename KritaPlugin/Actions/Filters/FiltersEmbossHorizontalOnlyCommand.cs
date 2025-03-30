using System.Reflection;
using LoupedeckKritaApiClient.ClientBase;

namespace Loupedeck.KritaPlugin
{
    // This class implements an example adjustment that counts the rotation ticks of a dial.

    public class FiltersEmbossHorizontalOnlyCommand : PluginDynamicCommand
    {
        private Client Client => ((KritaApplication)Plugin.ClientApplication).Client;

        // Initializes the command class.
        public FiltersEmbossHorizontalOnlyCommand()
            : base(displayName: "Emboss Horizontal Only", description: "Apply Emboss Horizontal Only filter (Emboss)", groupName: ActionGroups.Filters)
        {
        }

        protected override BitmapImage GetCommandImage(string actionParameter, PluginImageSize imageSize)
        {
            return BitmapImage.FromResource(Assembly.GetExecutingAssembly(), "Loupedeck.KritaPlugin.images.Filters.filters-EmbossHorizontal.png");
        }

        protected override void RunCommand(string actionParameter)
        {
            Client.KritaInstance.ExecuteAction(ActionsNames.Krita_filter_emboss_horizontal_only).Wait();
        }
    }
}
