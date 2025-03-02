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

        // This method can be used to check whether the application is installed or not.
        public override ClientApplicationStatus GetApplicationStatus() => ClientApplicationStatus.Installed;
    }
}
