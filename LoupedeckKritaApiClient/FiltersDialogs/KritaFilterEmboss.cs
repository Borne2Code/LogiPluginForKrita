using LoupedeckKritaApiClient.ClientBase;

namespace LoupedeckKritaApiClient.FiltersDialogs
{
    public class KritaFilterEmboss(Client client) : FilterDialog(client)
    {
        protected override string ActionName => "krita_filter_emboss";

        public Task SetDepth(int depth)
        {
            return SetSpinBoxValue(depth, "depth");
        }
    }
}
