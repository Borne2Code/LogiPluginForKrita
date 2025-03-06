using LoupedeckKritaApiClient.ClientBase;

namespace LoupedeckKritaApiClient.FiltersDialogs
{
    public class KritaFilterPixelize(Client client) : FilterDialogBase(client)
    {
        protected override string ActionName => "krita_filter_pixelize";

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
