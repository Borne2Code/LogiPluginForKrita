namespace Loupedeck.KritaPlugin
{
    using System;
    using System.IO.Compression;
    using System.Reflection;
    using LoupedeckKritaApiClient.ClientBase;

    // This class can be used to connect the Loupedeck plugin to an application.

    public class KritaApplication : ClientApplication
    {
        private Client _client;
        public Client Client
        {
            get
            {
                if (_client == null)
                {
                    var newClient = new Client();
                    newClient.Connect().Wait();
                    _client = newClient;
                }

                return _client;
            }
            private set
            {
                _client = value;
            }
        }

        public KritaApplication()
        {
        }

        // This method can be used to link the plugin to a Windows application.
        protected override String GetProcessName() => "Krita";

        // This method can be used to link the plugin to a macOS application.
        protected override String GetBundleName() => "";

        protected override string GetExecutablePath()
        {
            return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles), "Krita (x64)", "bin", "krita.exe");
        }

        // This method can be used to check whether the application is installed or not.
        public override ClientApplicationStatus GetApplicationStatus()
        {
            try
            {
                var kritaExePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles), "Krita (x64)", "bin", "krita.exe");
                if (File.Exists(kritaExePath))
                    return ClientApplicationStatus.Installed;
                else
                    return ClientApplicationStatus.NotInstalled;
            }
            catch
            {
                return ClientApplicationStatus.Unknown;
            }
        }

        public void CheckAndUpdateKritaExtension()
        {
            var kritaPluginsPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "krita", "pykrita");
            var pluginFile = new FileInfo(Path.Combine(kritaPluginsPath, "loopedeck_api_server", "loopedeckApiServer.py"));

            string plugInUpdateContent;
            var thisAssembly = Assembly.GetExecutingAssembly();
            using (var stream = thisAssembly.GetManifestResourceStream("Loupedeck.KritaPlugin.Resources.updatedAt.txt"))
            using (var reader = new StreamReader(stream))
            {
                plugInUpdateContent = reader.ReadToEnd();
            }

            if(!DateTime.TryParse(plugInUpdateContent, out var plugInUpdateDate))
            {
                return;
            }

            if (!pluginFile.Exists || pluginFile.LastWriteTime < plugInUpdateDate)
            {
                //install or update extension
                using (var stream = thisAssembly.GetManifestResourceStream("Loupedeck.KritaPlugin.Resources.KritaExtension.zip"))
                {
                    ZipFile.ExtractToDirectory(stream, kritaPluginsPath, true);
                }
            }
        }
    }
}
