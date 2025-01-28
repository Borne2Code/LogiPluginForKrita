namespace Loupedeck.KritaPlugin
{
    using System;
    using LoupedeckKritaApiClient.ClientBase;

    // This class can be used to connect the Loupedeck plugin to an application.

    public class KritaApplication : ClientApplication
    {
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
