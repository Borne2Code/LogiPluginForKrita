using LoupedeckKritaApiClient.ClientBase;

namespace Loupedeck.KritaPlugin
{
    // This class implements an example adjustment that counts the rotation ticks of a dial.

    public class LayerMergeWithBelow : PluginDynamicCommand
    {
        private KritaPlugin KritaPlugin => (KritaPlugin)Plugin;

        // Initializes the command class.
        public LayerMergeWithBelow()
            : base(displayName: "Merge with below", description: "Merge with layer below", groupName: ActionGroups.Layers)
        {
        }

        protected override BitmapImage GetCommandImage(string actionParameter, PluginImageSize imageSize)
        {
            return EmbeddedResources.ReadImage(EmbeddedResources.FindFile("LayerMergeWithBelow.png"));
        }

        protected override void RunCommand(string actionParameter)
        {
            KritaPlugin.Client.KritaInstance.ExecuteAction(ActionsNames.Merge_layer).Wait();
        }
    }
}
