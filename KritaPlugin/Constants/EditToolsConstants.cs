using Logi.KritaPlugin.DynamicFolders;
using LogiKritaApiClient.ClientBase;

namespace Logi.KritaPlugin.Constants
{
    public class EditToolsConstants
    {
        public static DynamicFolderCommandDefinition Copy => new DynamicFolderCommandDefinition("Copy", "Logi.KritaPlugin.images.Edit.Copy.png", ActionsNames.Edit_copy, false);
        public static DynamicFolderCommandDefinition Cut => new DynamicFolderCommandDefinition("Cut", "Logi.KritaPlugin.images.Edit.Cut.png", ActionsNames.Edit_cut, false);
        public static DynamicFolderCommandDefinition Paste => new DynamicFolderCommandDefinition("Paste", "Logi.KritaPlugin.images.Edit.Paste.png", ActionsNames.Edit_paste, false);
        public static DynamicFolderCommandDefinition PasteIntoLayer => new DynamicFolderCommandDefinition("Paste into layer", "Logi.KritaPlugin.images.Edit.PasteIntoLayer.png", ActionsNames.Paste_into, false);
        public static DynamicFolderCommandDefinition PasteNewImage => new DynamicFolderCommandDefinition("Paste as new image", "Logi.KritaPlugin.images.Edit.PasteIntoLayer.png", ActionsNames.Paste_new, false);
        public static DynamicFolderCommandDefinition CopySharp => new DynamicFolderCommandDefinition("Copy Sharp", "Logi.KritaPlugin.images.Edit.CopySharp.png", ActionsNames.Copy_sharp, false);
        public static DynamicFolderCommandDefinition CutSharp => new DynamicFolderCommandDefinition("Cut Sharp", "Logi.KritaPlugin.images.Edit.CutSharp.png", ActionsNames.Cut_sharp, false);
        public static DynamicFolderCommandDefinition PasteCursor => new DynamicFolderCommandDefinition("Paste @cursor", "Logi.KritaPlugin.images.Edit.PasteAtCursor.png", ActionsNames.Paste_at, false);
        public static DynamicFolderCommandDefinition PasteAsRef => new DynamicFolderCommandDefinition("Paste as Ref.", "Logi.KritaPlugin.images.Edit.PasteAsRef.png", ActionsNames.Paste_as_reference, false);

        public static IDictionary<string, DynamicFolderActionDefinition> Tools => new Dictionary<string, DynamicFolderActionDefinition>
        {
            { Copy.Name, Copy },
            { Cut.Name, Cut },
            { Paste.Name, Paste },
            { PasteIntoLayer.Name, PasteIntoLayer },
            { PasteNewImage.Name, PasteNewImage },
            { CopySharp.Name, CopySharp },
            { CutSharp.Name, CutSharp },
            { PasteCursor.Name, PasteCursor },
            { PasteAsRef.Name, PasteAsRef },
        };
    }
}
