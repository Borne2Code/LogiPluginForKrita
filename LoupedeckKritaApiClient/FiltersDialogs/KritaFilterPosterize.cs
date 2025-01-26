using LoupedeckKritaApiClient.ClientBase;

namespace LoupedeckKritaApiClient.FiltersDialogs
{
    public class KritaFilterPosterize(Client client) : FilterDialog(client)
    {
        protected override string ActionName => "krita_filter_posterize";

        public Task SetSteps(int steps)
        {
            return SetSpinBoxValue(steps, "steps");
        }
    }
}
