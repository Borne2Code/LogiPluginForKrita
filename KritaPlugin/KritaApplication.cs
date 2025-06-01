namespace Loupedeck.KritaPlugin
{
    using System;
    using LoupedeckKritaApiClient.ClientBase;

    // This class can be used to connect the Loupedeck plugin to an application.

    public class KritaApplication : ClientApplication
    {
        private Client _client;
        public Client Client
        {
            get
            {
                try
                {
                    if (_client == null)
                    {
                        var newClient = new Client();
                        newClient.Connect().Wait();
                        _client = newClient;
                    }
                }
                catch
                {
                    PluginLog.Info("Plugin could not connect to the server API.");
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
    }
}
