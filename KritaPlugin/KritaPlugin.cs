using System.IO.Compression;
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
            thisAssembly.ExtractFileToDirectory("Loupedeck.KritaPlugin.Resources.loopedeck_api_server.desktop", kritaPluginsPath);

            var kritaLoopedeckPluginPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "krita", "pykrita", "loopedeck_api_server");
            thisAssembly.ExtractFileToDirectory("Loupedeck.KritaPlugin.Resources.__init__.py", kritaLoopedeckPluginPath);
            thisAssembly.ExtractFileToDirectory("Loupedeck.KritaPlugin.Resources.loopedeckApiServer.py", kritaLoopedeckPluginPath);

            return true;
        }

        public override bool Uninstall()
        {
            var kritaPluginsPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "krita", "pykrita");

            var kritaplugInDesktopFile = Path.Combine(kritaPluginsPath, "loopedeck_api_server.desktop");
            if (File.Exists(kritaplugInDesktopFile))
            {
                File.Delete(kritaplugInDesktopFile);
            }

            var kritaLoopedeckPluginPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "krita", "pykrita", "loopedeck_api_server");
            if(Directory.Exists(kritaLoopedeckPluginPath))
            {
                var kritaplugInInitFile = Path.Combine(kritaLoopedeckPluginPath, "__init__.py");
                if (File.Exists(kritaplugInInitFile))
                {
                    File.Delete(kritaplugInInitFile);
                }

                var kritaplugInSourceFile = Path.Combine(kritaLoopedeckPluginPath, "loopedeckApiServer.py");
                if (File.Exists(kritaplugInSourceFile))
                {
                    File.Delete(kritaplugInSourceFile);
                }
            }

            return true;
        }
    }
}
