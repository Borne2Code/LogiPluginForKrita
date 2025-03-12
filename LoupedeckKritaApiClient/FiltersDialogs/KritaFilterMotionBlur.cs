using LoupedeckKritaApiClient.ClientBase;

namespace LoupedeckKritaApiClient.FiltersDialogs
{
    public class KritaFilterMotionBlur(Client client) : FilterDialogBase(client)
    {
        internal override string ActionName => "krita_filter_motion blur";

        public Task<float> AdjustBlurAngle(int value)
        {
            return AdjustAngleSelectorValue(value, "blurAngleSelector");
        }

        public Task<int> AdjustLength(int value)
        {
            return AdjustIntSpinBoxValue(value, "blurLength");
        }
    }
}
