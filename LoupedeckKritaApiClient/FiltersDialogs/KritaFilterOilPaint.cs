using LoupedeckKritaApiClient.ClientBase;

namespace LoupedeckKritaApiClient.FiltersDialogs
{
    public class KritaFilterOilPaint(Client client, bool isModal) : FilterDialogBase(client, isModal)
    {
        public override string ActionName => "krita_filter_oilpaint";

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
