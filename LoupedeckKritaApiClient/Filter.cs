using LoupedeckKritaApiClient.ClientBase;
using LoupedeckKritaApiClient.FiltersDialogs;

namespace LoupedeckKritaApiClient
{
    public class Filter() : LoupedeckClientKritaBaseClass
    {
        public Task Apply() => Execute("apply");
        public static async Task<FilterDialog> GetFilterDialog(Client client, FiltersEnum filterType)
        {
            var dialog = filterType switch
            {
                FiltersEnum.AscCdl => (FilterDialog)new KritaFilterAscCdl(client),
                FiltersEnum.AutoConstrast => new KritaFilterAutoConstrast(client),
                FiltersEnum.Burn => new KritaFilterBurn(client),
                FiltersEnum.Blur => new KritaFilterBlur(client),
                FiltersEnum.ColorBalance => new KritaFilterColorBalance(client),
                FiltersEnum.ColorToAlpha => new KritaFilterColorToAlpha(client),
                FiltersEnum.ColorTransfer => new KritaFilterColorTranfer(client),
                FiltersEnum.CrossChannel => new KritaFilterCrossChannel(client),
                FiltersEnum.Desaturate => new KritaFilterDesaturate(client),
                FiltersEnum.Dodge => new KritaFilterDodge(client),
                _ => throw new Exception("Not implement filter dialog")
            };

            await dialog.OpenDialog();

            return dialog;
        }
    }
}