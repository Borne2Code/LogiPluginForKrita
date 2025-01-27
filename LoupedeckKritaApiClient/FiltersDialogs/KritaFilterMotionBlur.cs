using LoupedeckKritaApiClient.ClientBase;

namespace LoupedeckKritaApiClient.FiltersDialogs
{
    public class KritaFilterMotionBlur(Client client) : FilterDialog(client)
    {
        protected override string ActionName => "krita_filter_motion blur";

        public Task<int> AdjustBlurAngle(int value)
        {
            return AdjustAngleSelectorValue(value, "blurAngleSelector");
        }

        public Task<int> AdjustLength(int value)
        {
            return AdjustIntSpinBoxValue(value, "blurLength");
        }
    }
}
