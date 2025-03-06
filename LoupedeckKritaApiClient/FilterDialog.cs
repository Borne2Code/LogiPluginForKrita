using LoupedeckKritaApiClient.ClientBase;
using LoupedeckKritaApiClient.FiltersDialogs;

namespace LoupedeckKritaApiClient
{
    public class FilterDialog() : LoupedeckClientKritaBaseClass
    {
        public Task Apply() => Execute("apply");
        public static async Task<FilterDialogBase> GetFilterDialog(Client client, string filterName)
        {
            FilterDialogBase dialog = GetFilterDialogByFilterName(client, filterName);

            await dialog.OpenDialog();

            return dialog;
        }

        private static FilterDialogBase GetFilterDialogByFilterName(Client client, string filterName)
        {
            return filterName switch
            {
                FilterNames.AscCdl => new KritaFilterAscCdl(client),
                FilterNames.AutoConstrast => new KritaFilterAutoConstrast(client),
                FilterNames.Burn => new KritaFilterBurn(client),
                FilterNames.Blur => new KritaFilterBlur(client),
                FilterNames.ColorBalance => new KritaFilterColorBalance(client),
                FilterNames.ColorToAlpha => new KritaFilterColorToAlpha(client),
                FilterNames.ColorTransfer => new KritaFilterColorTranfer(client),
                FilterNames.CrossChannel => new KritaFilterCrossChannel(client),
                FilterNames.Desaturate => new KritaFilterDesaturate(client),
                FilterNames.Dodge => new KritaFilterDodge(client),
                FilterNames.EdgeDetection => new KritaFilterEdgeDetecttion(client),
                FilterNames.Emboss => new KritaFilterEmboss(client),
                FilterNames.EmbossAllDirections => new KritaFilterEmbossAllDirections(client),
                FilterNames.EmbossHorizontalAndVertical => new KritaFilterEmbossHorizontalAndVertical(client),
                FilterNames.EmbossHorizontalOnly => new KritaFilterEmbossHorizontalOnly(client),
                FilterNames.EmbossLaplascian => new KritaFilterEmbossLaplacian(client),
                FilterNames.EmbossVerticalOnly => new KritaFilterEmbossVerticalOnly(client),
                FilterNames.GaussianBlur => new KritaFilterGaussianBlur(client),
                FilterNames.GaussianHighPass => new KritaFilterGaussianHighPass(client),
                FilterNames.GaussianNoiseReducer => new KritaFilterGaussianNoiseReducer(client),
                FilterNames.GradientMap => new KritaFilterGradientMap(client),
                FilterNames.Halftone => new KritaFilterHalfTone(client),
                FilterNames.HeightToNormal => new KritaFilterHeightToNormal(client),
                FilterNames.HsvAdjustment => new KritaFilterHsvAdjustment(client),
                FilterNames.IndexColors => new KritaFilterIndexColors(client),
                FilterNames.Invert => new KritaFilterInvert(client),
                FilterNames.LensBlur => new KritaFilterLensBlur(client),
                FilterNames.Levels => new KritaFilterLevels(client),
                FilterNames.Maximize => new KritaFilterMaximize(client),
                FilterNames.MeanRemoval => new KritaFilterMeanRemoval(client),
                FilterNames.Minimize => new KritaFilterMinimize(client),
                FilterNames.MotionBlur => new KritaFilterMotionBlur(client),
                FilterNames.Noise => new KritaFilterNoise(client),
                FilterNames.Normalize => new KritaFilterNormalize(client),
                FilterNames.OilPaint => new KritaFilterOilPaint(client),
                FilterNames.Palettize => new KritaFilterPalettize(client),
                FilterNames.PerChannelColorAdjustment => new KritaFilterPerChannelColorAdjustment(client),
                FilterNames.PhongBumpMap => new KritaFilterPhongBumpMap(client),
                FilterNames.Pixelize => new KritaFilterPixelize(client),
                FilterNames.Posterize => new KritaFilterPosterize(client),
                FilterNames.RainDrops => new KritaFilterRainDrops(client),
                FilterNames.RandomPick => new KritaFilterRandomPick(client),
                FilterNames.ResetTransparent => new KritaFilterResetTransparent(client),
                FilterNames.RoundCorners => new KritaFilterRoundCorners(client),
                FilterNames.Sharpen => new KritaFilterSharpen(client),
                FilterNames.SmallTiles => new KritaFilterSmallTiles(client),
                FilterNames.Threshold => new KritaFilterThreshold(client),
                FilterNames.Unsharp => new KritaFilterUnsharp(client),
                FilterNames.Wave => new KritaFilterWave(client),
                FilterNames.WaveletNoiseReducer => new KritaFilterWaveletNoiseReducer(client),
                _ => throw new Exception("Not implement filter dialog")
            };
        }

        public static async Task<(FilterDialogBase? filterDialog,string? filterName)> GetFilterLayerDialog(Client client)
        {
            await using var filter = await client.CurrentNode.Filter();
            if (filter == null) 
            {
                return (null, null);
            }

            await client.KritaInstance.ExecuteAction(ActionsNames.Layer_properties);

            var filterName = await filter.name();
            var dialog = GetFilterDialogByFilterName(client, filterName);
            await dialog.AttachDialog();

            return (dialog, filterName);
        }
    }
}