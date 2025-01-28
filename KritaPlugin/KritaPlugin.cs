namespace Loupedeck.KritaPlugin
{
    using System;
    using LoupedeckKritaApiClient.ClientBase;

    // This class contains the plugin-level logic of the Loupedeck plugin.

    public class KritaPlugin : Plugin
    {
        public Client Client { get; private set; }

        // Gets a value indicating whether this is an API-only plugin.
        public override Boolean UsesApplicationApiOnly => false;

        // Gets a value indicating whether this is a Universal plugin or an Application plugin.
        public override Boolean HasNoApplication => false;

        // Initializes a new instance of the plugin class.
        public KritaPlugin()
        {
            // Initialize the plugin log.
            PluginLog.Init(this.Log);

            // Initialize the plugin resources.
            PluginResources.Init(this.Assembly);
        }

        // This method is called when the plugin is loaded.
        public override async void Load()
        {
            Client = new Client();
            await Client.Connect();
        }

        // This method is called when the plugin is unloaded.
        public override async void Unload()
        {
            await Client.DisposeAsync();
        }
    }
}
