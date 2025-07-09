namespace Logi.KritaPlugin.DynamicFolders
{
    public abstract class DynamicFolderActionDefinition
    {
        public string Name { get; }
        public string BitMapImageName { get; }

        public DynamicFolderActionDefinition(string name, string bitmapImageName)
        {
            Name = name;
            BitMapImageName = bitmapImageName;
        }
    }
}
