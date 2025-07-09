using Logi.KritaPlugin.DynamicFolders;
using LogiKritaApiClient.ClientBase;

namespace Logi.KritaPlugin.Constants
{
    public class TransformToolsConstants
    {
        public static DynamicFolderCommandDefinition Move => new DynamicFolderCommandDefinition("Move", "Logi.KritaPlugin.images.Tools.Move.png", ActionsNames.KritaTransform_KisToolMove);
        public static DynamicFolderCommandDefinition Transform => new DynamicFolderCommandDefinition("Transform", "Logi.KritaPlugin.images.Tools.Transform.png", ActionsNames.KisToolTransform);
        public static DynamicFolderCommandDefinition Crop => new DynamicFolderCommandDefinition("Crop", "Logi.KritaPlugin.images.Tools.Crop.png", ActionsNames.KisToolCrop);

        public static IDictionary<string, DynamicFolderActionDefinition> Tools => new Dictionary<string, DynamicFolderActionDefinition>
        {
            { Move.Name, Move },
            { Transform.Name, Transform },
            { Crop.Name, Crop },
        };
    }
}
