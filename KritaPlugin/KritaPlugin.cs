using System.Reflection;

namespace Loupedeck.KritaPlugin
{
    // This class contains the plugin-level logic of the Loupedeck plugin.
    public class KritaPlugin : Plugin
    {
        // Gets a value indicating whether this is an API-only plugin.
        public override Boolean UsesApplicationApiOnly => false;

        // Gets a value indicating whether this is a Universal plugin or an Application plugin.
        public override Boolean HasNoApplication => false;

        public KritaApplication KritaApplication { get => (KritaApplication)ClientApplication; }

        // Initializes a new instance of the plugin class.
        public KritaPlugin()
        {
            // Initialize the plugin log.
            PluginLog.Init(this.Log);

            // Initialize the plugin resources.
            PluginResources.Init(this.Assembly);
        }

        // This method is called when the plugin is loaded.
        public override void Load()
        {
        }

        // This method is called when the plugin is unloaded.
        public override async void Unload()
        {
            if (KritaApplication.Client != null)
            {
                await KritaApplication.Client.DisposeAsync();
            }
        }

        public override bool Install()
        {
            var kritaPluginsPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "krita", "pykrita");
            var thisAssembly = Assembly.GetExecutingAssembly();
            thisAssembly.ExtractFileToDirectory("Loupedeck.KritaPlugin.Resources.loupedeck_api_server.desktop", kritaPluginsPath);

            var kritaLoupedeckPluginPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "krita", "pykrita", "loupedeck_api_server");
            thisAssembly.ExtractFileToDirectory("Loupedeck.KritaPlugin.Resources.__init__.py", kritaLoupedeckPluginPath);
            thisAssembly.ExtractFileToDirectory("Loupedeck.KritaPlugin.Resources.loupedeckApiServer.py", kritaLoupedeckPluginPath);

            return true;
        }

        public override bool Uninstall()
        {
            var kritaPluginsPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "krita", "pykrita");

            var kritaplugInDesktopFile = Path.Combine(kritaPluginsPath, "loupedeck_api_server.desktop");
            if (File.Exists(kritaplugInDesktopFile))
            {
                File.Delete(kritaplugInDesktopFile);
            }

            var kritaLoupedeckPluginPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "krita", "pykrita", "loupedeck_api_server");
            if(Directory.Exists(kritaLoupedeckPluginPath))
            {
                var kritaplugInInitFile = Path.Combine(kritaLoupedeckPluginPath, "__init__.py");
                if (File.Exists(kritaplugInInitFile))
                {
                    File.Delete(kritaplugInInitFile);
                }

                var kritaplugInSourceFile = Path.Combine(kritaLoupedeckPluginPath, "loupedeckApiServer.py");
                if (File.Exists(kritaplugInSourceFile))
                {
                    File.Delete(kritaplugInSourceFile);
                }
            }

            return true;
        }
    }
}
