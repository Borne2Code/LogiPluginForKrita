using Logi.KritaPlugin.Constants;

namespace Logi.KritaPlugin.DynamicFolders
{
    public class ColorSelectorToolsDynamicFolder : ToolsDynamicFolderBase
    {
        public ColorSelectorToolsDynamicFolder()
            : base("ColorSelector Tools", ActionGroups.ColorSelector, ColorSelectorToolsConstants.Tools, "Logi.KritaPlugin.images.Color.Hue.png")
        {
        }
    }
}
