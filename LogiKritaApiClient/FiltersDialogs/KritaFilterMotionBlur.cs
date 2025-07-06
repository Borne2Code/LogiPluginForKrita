using LogiKritaApiClient.ClientBase;

namespace LogiKritaApiClient.FiltersDialogs
{
    public class KritaFilterMotionBlur(Client client, bool isModal) : FilterDialogBase(client, isModal)
    {
        public override string ActionName => "krita_filter_motion blur";

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
