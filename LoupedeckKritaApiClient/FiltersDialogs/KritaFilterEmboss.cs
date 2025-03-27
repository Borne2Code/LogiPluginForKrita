using LoupedeckKritaApiClient.ClientBase;

namespace LoupedeckKritaApiClient.FiltersDialogs
{
    public class KritaFilterEmboss(Client client, bool isModal) : FilterDialogBase(client, isModal)
    {
        public override string ActionName => "krita_filter_emboss";

        public Task<int> AdjustDepth(int depth)
        {
            return AdjustIntSpinBoxValue(depth, "depth");
        }
    }
}
