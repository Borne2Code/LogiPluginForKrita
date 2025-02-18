using LoupedeckKritaApiClient.ClientBase;

namespace Loupedeck.KritaPlugin
{
    // This class implements an example adjustment that counts the rotation ticks of a dial.

    public class LayerQuickClippingGroup : PluginDynamicCommand
    {
        private KritaPlugin KritaPlugin => (KritaPlugin)Plugin;

        // Initializes the command class.
        public LayerQuickClippingGroup()
            : base(displayName: "Quick clipping group", description: "Quick clipping group", groupName: ActionGroups.Layers)
        {
        }

        protected override BitmapImage GetCommandImage(string actionParameter, PluginImageSize imageSize)
        {
            return EmbeddedResources.ReadImage(EmbeddedResources.FindFile("LayerQuickClippingGroup.png"));
        }

        protected override void RunCommand(string actionParameter)
        {
            KritaPlugin.Client.KritaInstance.ExecuteAction(ActionsNames.Create_quick_clipping_group).Wait();
        }
    }
}
