using LoupedeckKritaApiClient.ClientBase;

namespace LoupedeckKritaApiClient.FiltersDialogs
{
    public class KritaFilterOilPaint(Client client) : FilterDialog(client)
    {
        protected override string ActionName => "krita_filter_oilpaint";

        public Task<int> AdjustBrushSize(int value)
        {
            return AdjustIntSpinBoxValue(value, "brushSize");
        }

        public Task<int> AdjustSmooth(int value)
        {
            return AdjustIntSpinBoxValue(value, "smooth");
        }
    }
}
