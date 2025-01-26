using LoupedeckKritaApiClient.ClientBase;

namespace LoupedeckKritaApiClient.FiltersDialogs
{
    public class KritaFilterRandomPick(Client client) : FilterDialog(client)
    {
        protected override string ActionName => "krita_filter_randompick";

        public Task SetLevel(int level)
        {
            return SetSpinBoxValue(level, "intLevel");
        }

        public Task SetWindowSize(int size)
        {
            return SetSpinBoxValue(size, "intWindowSize");
        }

        public Task SetOpacity(int opacity)
        {
            return SetSpinBoxValue(opacity, "intOpacity");
        }
    }
}
