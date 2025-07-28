using Logi.KritaPlugin.DynamicFolders;
using LogiKritaApiClient.ClientBase;
using Loupedeck;

namespace Logi.KritaPlugin.Constants
{
    public class EditToolsConstants
    {
        public static DynamicFolderCommandDefinition Copy => new DynamicFolderCommandDefinition("Copy", "Logi.KritaPlugin.images.Edit.Copy.png", ActionsNames.Edit_copy, false);
        public static DynamicFolderCommandDefinition Cut => new DynamicFolderCommandDefinition("Cut", "Logi.KritaPlugin.images.Edit.Cut.png", ActionsNames.Edit_cut, false);
        public static DynamicFolderCommandDefinition Paste => new DynamicFolderCommandDefinition("Paste", "Logi.KritaPlugin.images.Edit.Paste.png", ActionsNames.Edit_paste);
        public static DynamicFolderCommandDefinition Delete => new DynamicFolderCommandDefinition("Delete", "Logi.KritaPlugin.images.Edit.Delete.png", VirtualKeyCode.Delete);
        public static DynamicFolderCommandDefinition FillForeground => new DynamicFolderCommandDefinition("Fill with Foreground", "Logi.KritaPlugin.images.Edit.FillForeground.png", ActionsNames.Fill_selection_foreground_color);
        public static DynamicFolderCommandDefinition FillBackground => new DynamicFolderCommandDefinition("Fill with Background", "Logi.KritaPlugin.images.Edit.FillBackground.png", ActionsNames.Fill_selection_background_color);
        public static DynamicFolderCommandDefinition PasteIntoLayer => new DynamicFolderCommandDefinition("Paste into layer", "Logi.KritaPlugin.images.Edit.PasteIntoLayer.png", ActionsNames.Paste_into);
        public static DynamicFolderCommandDefinition PasteNewImage => new DynamicFolderCommandDefinition("Paste as new image", "Logi.KritaPlugin.images.Edit.PasteNewImage.png", ActionsNames.Paste_new);
        public static DynamicFolderCommandDefinition CopySharp => new DynamicFolderCommandDefinition("Copy Sharp", "Logi.KritaPlugin.images.Edit.CopySharp.png", ActionsNames.Copy_sharp, false);
        public static DynamicFolderCommandDefinition CutSharp => new DynamicFolderCommandDefinition("Cut Sharp", "Logi.KritaPlugin.images.Edit.CutSharp.png", ActionsNames.Cut_sharp, false);
        public static DynamicFolderCommandDefinition PasteCursor => new DynamicFolderCommandDefinition("Paste @cursor", "Logi.KritaPlugin.images.Edit.PasteAtCursor.png", ActionsNames.Paste_at);
        public static DynamicFolderCommandDefinition PasteAsRef => new DynamicFolderCommandDefinition("Paste as Ref.", "Logi.KritaPlugin.images.Edit.PasteAsRef.png", ActionsNames.Paste_as_reference);

        public static IDictionary<string, DynamicFolderActionDefinition> Tools => new Dictionary<string, DynamicFolderActionDefinition>
        {
            { Copy.Name, Copy },
            { Cut.Name, Cut },
            { Paste.Name, Paste },
            { Delete.Name, Delete },
            { FillForeground.Name, FillForeground },
            { FillBackground.Name, FillBackground },
            { PasteIntoLayer.Name, PasteIntoLayer },
            { PasteNewImage.Name, PasteNewImage },
            { CopySharp.Name, CopySharp },
            { CutSharp.Name, CutSharp },
            { PasteCursor.Name, PasteCursor },
            { PasteAsRef.Name, PasteAsRef },
        };
    }
}
