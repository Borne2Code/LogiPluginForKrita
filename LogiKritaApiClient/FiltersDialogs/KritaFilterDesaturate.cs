using LogiKritaApiClient.ClientBase;

namespace LogiKritaApiClient.FiltersDialogs
{
    public class KritaFilterDesaturate(Client client, bool isModal) : FilterDialogBase(client, isModal)
    {
        public override string ActionName => "krita_filter_desaturate";

        public Task SelectLightness()
        {
            return ClickRadio("groupType", "radioLightness");
        }

        public Task SelectLuminosityBT709()
        {
            return ClickRadio("groupType", "radioLuminosityBT709");
        }

        public Task SelectLuminosityBT601()
        {
            return ClickRadio("groupType", "radioLuminosityBT601");
        }

        public Task SelectAverage()
        {
            return ClickRadio("groupType", "radioAverage");
        }

        public Task SelectMin()
        {
            return ClickRadio("groupType", "radioMin");
        }

        public Task SelectMax()
        {
            return ClickRadio("groupType", "radioMax");
        }   
    }
}
