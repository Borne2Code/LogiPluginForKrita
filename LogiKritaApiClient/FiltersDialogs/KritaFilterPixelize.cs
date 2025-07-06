using LogiKritaApiClient.ClientBase;

namespace LogiKritaApiClient.FiltersDialogs
{
    public class KritaFilterPixelize(Client client, bool isModal) : FilterDialogBase(client, isModal)
    {
        public override string ActionName => "krita_filter_pixelize";

        public Task<int> AdjustPixelWidth(int width)
        {
            return AdjustIntSpinBoxValue(width, "pixelWidth");
        }

        public Task<int> AdjustPixelHeight(int height)
        {
            return AdjustIntSpinBoxValue(height, "pixelHeight");
        }
    }
}
