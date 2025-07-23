using Logi.KritaPlugin.DynamicFolders;

namespace Logi.KritaPlugin.Constants
{
    public class SelectionModeToolsConstants
    {
        public static IDictionary<string, DynamicFolderActionDefinition> Tools => new Dictionary<string, DynamicFolderActionDefinition>
        {
            { SelectionToolsConstants.ModeReplace.Name, SelectionToolsConstants.ModeReplace },
            { SelectionToolsConstants.ModeAdd.Name, SelectionToolsConstants.ModeAdd },
            { SelectionToolsConstants.ModeSubstract.Name, SelectionToolsConstants.ModeSubstract },
            { SelectionToolsConstants.ModeIntersect.Name, SelectionToolsConstants.ModeIntersect },
        };
    }
}
