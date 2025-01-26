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
                FiltersEnum.EdgeDetection => new KritaFilterEdgeDetecttion(client),
                FiltersEnum.Emboss => new KritaFilterEmboss(client),
                FiltersEnum.EmbossAllDirections => new KritaFilterEmbossAllDirections(client),
                FiltersEnum.EmbossHorizontalAndVertical => new KritaFilterEmbossHorizontalAndVertical(client),
                FiltersEnum.EmbossHorizontalOnly => new KritaFilterEmbossHorizontalOnly(client),
                FiltersEnum.EmbossLaplascian => new KritaFilterEmbossLaplacian(client),
                FiltersEnum.EmbossVerticalOnly => new KritaFilterEmbossVerticalOnly(client),
                FiltersEnum.GaussianBlur => new KritaFilterGaussianBlur(client),
                FiltersEnum.GaussianHighPass => new KritaFilterGaussianHighPass(client),
                FiltersEnum.GaussianNoiseReducer => new KritaFilterGaussianNoiseReducer(client),
                FiltersEnum.GradientMap => new KritaFilterGradientMap(client),
                FiltersEnum.Halftone => new KritaFilterHalfTone(client),
                FiltersEnum.HeightToNormal => new KritaFilterHeightToNormal(client),
                FiltersEnum.HsvAdjustment => new KritaFilterHsvAdjustment(client),
                FiltersEnum.IndexColors => new KritaFilterIndexColors(client),
                FiltersEnum.Invert => new KritaFilterInvert(client),
                FiltersEnum.LensBlur => new KritaFilterLensBlur(client),
                FiltersEnum.Levels => new KritaFilterLevels(client),
                FiltersEnum.Maximize => new KritaFilterMaximize(client),
                FiltersEnum.MeanRemoval => new KritaFilterMeanRemoval(client),
                FiltersEnum.Minimize => new KritaFilterMinimize(client),
                FiltersEnum.MotionBlur => new KritaFilterMotionBlur(client),
                FiltersEnum.Noise => new KritaFilterNoise(client),
                FiltersEnum.Normalize => new KritaFilterNormalize(client),
                FiltersEnum.OilPaint => new KritaFilterOilPaint(client),
                FiltersEnum.Palettize => new KritaFilterPalettize(client),
                FiltersEnum.PerChannelColorAdjustment => new KritaFilterPerChannelColorAdjustment(client),
                FiltersEnum.PhongBumpMap => new KritaFilterPhongBumpMap(client),
                FiltersEnum.Pixelize => new KritaFilterPixelize(client),
                FiltersEnum.Posterize => new KritaFilterPosterize(client),
                FiltersEnum.RainDrops => new KritaFilterRainDrops(client),
                FiltersEnum.RandomPick => new KritaFilterRandomPick(client),
                FiltersEnum.ResetTransparent => new KritaFilterResetTransparent(client),
                FiltersEnum.RoundCorners => new KritaFilterRoundCorners(client),
                FiltersEnum.Sharpen => new KritaFilterSharpen(client),
                FiltersEnum.SmallTiles => new KritaFilterSmallTiles(client),
                FiltersEnum.Threshold => new KritaFilterThreshold(client),
                FiltersEnum.Unsharp => new KritaFilterUnsharp(client),
                FiltersEnum.Wave => new KritaFilterWave(client),
                FiltersEnum.WaveletNoiseReducer => new KritaFilterWaveletNoiseReducer(client),
                _ => throw new Exception("Not implement filter dialog")
            };

            await dialog.OpenDialog();

            return dialog;
        }
    }
}