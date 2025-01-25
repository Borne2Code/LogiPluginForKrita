using LoupedeckKritaApiClient.ClientBase;

namespace LoupedeckKritaApiClient.FiltersDialogs
{
    public class KritaFilterMotionBlur(Client client) : FilterDialog(client)
    {
        protected override string ActionName => "krita_filter_motion blur";

        public Task SetBlurAngle(int value)
        {
            return SetAngleSelectorValue(value, "blurAngleSelector");
        }

        public Task SetLength(int value)
        {
            return SetSpinBoxValue(value, "blurLength");
        }
    }
}
