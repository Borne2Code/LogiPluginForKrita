using LoupedeckKritaApiClient.ClientBase;

namespace LoupedeckKritaApiClient.FiltersDialogs
{
    public class KritaFilterPixelize(Client client) : FilterDialog(client)
    {
        protected override string ActionName => "krita_filter_pixelize";

        public Task SetPixelWidth(int width)
        {
            return SetSpinBoxValue(width, "pixelWidth");
        }

        public Task SetPixelHeight(int height)
        {
            return SetSpinBoxValue(height, "pixelHeight");
        }
    }
}
