using LoupedeckKritaApiClient.ClientBase;

namespace LoupedeckKritaApiClient.FiltersDialogs
{
    public class KritaFilterColorToAlpha(Client client) : FilterDialog(client)
    {
        protected override string ActionName => "krita_filter_colortoalpha";

        public Task SetThreshold(int value)
        {
            return SetSpinBoxValue(value, "intThreshold");
        }
        
        // TODO: color selection
    }
}
