using LoupedeckKritaApiClient.ClientBase;

namespace LoupedeckKritaApiClient.FiltersDialogs
{
    public class KritaFilterUnsharp(Client client) : FilterDialog(client)
    {
        protected override string ActionName => "krita_filter_unsharp";

        public Task SetRadius(float radius)
        {
            return SetSpinBoxValue(radius, "doubleHalfSize");
        }

        public Task SetAmount(float amount)
        {
            return SetSpinBoxValue(amount, "doubleAmount");
        }

        public Task SetThreshold(int value)
        {
            return SetSpinBoxValue(value, "intThreshold");
        }
    }
}
