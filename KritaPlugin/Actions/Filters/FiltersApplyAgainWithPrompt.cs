using LoupedeckKritaApiClient.ClientBase;

namespace Loupedeck.KritaPlugin
{
    // This class implements an example adjustment that counts the rotation ticks of a dial.

    public class FiltersApplyAgainWithPrompt : PluginDynamicCommand
    {
        private KritaPlugin KritaPlugin => (KritaPlugin)Plugin;

        // Initializes the command class.
        public FiltersApplyAgainWithPrompt()
            : base(displayName: "Apply filter again...", description: "Apply again the previous filter with new prompt", groupName: ActionGroups.Filters)
        {
        }

        protected override BitmapImage GetCommandImage(string actionParameter, PluginImageSize imageSize)
        {
            return EmbeddedResources.ReadImage(EmbeddedResources.FindFile("FilterApplyAgainWithPrompt.png"));
        }

        protected override void RunCommand(string actionParameter)
        {
            KritaPlugin.Client.KritaInstance.ExecuteAction(ActionsNames.Filter_apply_reprompt).Wait();
        }
    }
}
