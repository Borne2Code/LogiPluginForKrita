using LoupedeckKritaApiClient.ClientBase;

namespace LoupedeckKritaApiClient.FiltersDialogs
{
    public class KritaFilterRandomPick(Client client) : FilterDialogBase(client)
    {
        protected override string ActionName => "krita_filter_randompick";

        public Task<int> AdjustLevel(int level)
        {
            return AdjustIntSpinBoxValue(level, "intLevel");
        }

        public Task<int> AdjustWindowSize(int size)
        {
            return AdjustIntSpinBoxValue(size, "intWindowSize");
        }

        public Task<int> AdjustOpacity(int opacity)
        {
            return AdjustIntSpinBoxValue(opacity, "intOpacity");
        }
    }
}
