using LoupedeckKritaApiClient.ClientBase;

namespace LoupedeckKritaApiClient.FiltersDialogs
{
    public class KritaFilterOilPaint(Client client) : FilterDialog(client)
    {
        protected override string ActionName => "krita_filter_oilpaint";

        public Task SetBrushSize(int value)
        {
            return SetSpinBoxValue(value, "brushSize");
        }

        public Task SetSmooth(int value)
        {
            return SetSpinBoxValue(value, "smooth");
        }
    }
}
