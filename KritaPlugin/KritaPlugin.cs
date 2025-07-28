using System.Reflection;
using Loupedeck;

namespace Logi.KritaPlugin
{
    // This class contains the plugin-level logic of the Loupedeck plugin.
    public class KritaPlugin : Plugin
    {
        // Gets a value indicating whether this is an API-only plugin.
        public override bool UsesApplicationApiOnly => false;

        // Gets a value indicating whether this is a Universal plugin or an Application plugin.
        public override bool HasNoApplication => false;

        public KritaApplication KritaApplication { get => (KritaApplication)ClientApplication; }

        // Initializes a new instance of the plugin class.
        public KritaPlugin()
        {
            // Initialize the plugin log.
            PluginLog.Init(Log);

            // Initialize the plugin resources.
            PluginResources.Init(Assembly);
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
            var kritaPluginsPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Krita", "pykrita");
            var thisAssembly = Assembly.GetExecutingAssembly();
            thisAssembly.ExtractFileToDirectory("Logi.KritaPlugin.Resources.logi_api_server.desktop", kritaPluginsPath);

            var kritaLogiPluginPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Krita", "pykrita", "logi_api_server");
            thisAssembly.ExtractFileToDirectory("Logi.KritaPlugin.Resources.__init__.py", kritaLogiPluginPath);
            thisAssembly.ExtractFileToDirectory("Logi.KritaPlugin.Resources.logiApiServer.py", kritaLogiPluginPath);

            return true;
        }

        public override bool Uninstall()
        {
            var kritaPluginsPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Krita", "pykrita");

            var kritaplugInDesktopFile = Path.Combine(kritaPluginsPath, "logi_api_server.desktop");
            if (File.Exists(kritaplugInDesktopFile))
            {
                File.Delete(kritaplugInDesktopFile);
            }

            var kritaLogiPluginPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Krita", "pykrita", "logi_api_server");
            if(Directory.Exists(kritaLogiPluginPath))
            {
                var kritaplugInInitFile = Path.Combine(kritaLogiPluginPath, "__init__.py");
                if (File.Exists(kritaplugInInitFile))
                {
                    File.Delete(kritaplugInInitFile);
                }

                var kritaplugInSourceFile = Path.Combine(kritaLogiPluginPath, "logiApiServer.py");
                if (File.Exists(kritaplugInSourceFile))
                {
                    File.Delete(kritaplugInSourceFile);
                }
            }

            return true;
        }
    }
}
