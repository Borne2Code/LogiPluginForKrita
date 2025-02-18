using LoupedeckKritaApiClient.ClientBase;

namespace Loupedeck.KritaPlugin
{
    // This class implements an example adjustment that counts the rotation ticks of a dial.

    public class LayerQuickGroup : PluginDynamicCommand
    {
        private KritaPlugin KritaPlugin => (KritaPlugin)Plugin;

        // Initializes the command class.
        public LayerQuickGroup()
            : base(displayName: "Quick group", description: "Quick group", groupName: ActionGroups.Layers)
        {
        }

        protected override BitmapImage GetCommandImage(string actionParameter, PluginImageSize imageSize)
        {
            return EmbeddedResources.ReadImage(EmbeddedResources.FindFile("LayerQuickGroup.png"));
        }

        protected override void RunCommand(string actionParameter)
        {
            KritaPlugin.Client.KritaInstance.ExecuteAction(ActionsNames.Create_quick_group).Wait();
        }
    }
}
