using LoupedeckKritaApiClient.ClientBase;

namespace LoupedeckKritaApiClient.FiltersDialogs
{
    public class FilterNames
    {
        public const string AscCdl = "asc-cdl";
        public const string AutoConstrast = "autocontrast";
        public const string Blur = "blur";
        public const string Burn = "burn";
        public const string ColorBalance = "colorbalance";
        public const string ColorToAlpha = "colortoalpha";
        public const string ColorTransfer = "colortransfer";
        public const string CrossChannel = "crosschannel";
        public const string Desaturate = "desaturate";
        public const string Dodge = "dodge";
        public const string EdgeDetection = "edge detection";
        public const string Emboss = "emboss";
        public const string EmbossAllDirections = "emboss all directions";
        public const string EmbossHorizontalAndVertical = "emboss horizontal and vertical";
        public const string EmbossHorizontalOnly = "emboss horizontal only";
        public const string EmbossLaplascian = "emboss laplascian";
        public const string EmbossVerticalOnly = "emboss vertical only";
        public const string GaussianBlur = "gaussian blur";
        public const string GaussianHighPass = "gaussianhighpass";
        public const string GaussianNoiseReducer = "gaussiannoisereducer";
        public const string GradientMap = "gradientmap";
        public const string Halftone = "halftone";
        public const string HeightToNormal = "height to normal";
        public const string HsvAdjustment = "hsvadjustment";
        public const string IndexColors = "indexcolors";
        public const string Invert = "invert";
        public const string LensBlur = "lens blur";
        public const string Levels = "levels";
        public const string Maximize = "maximize";
        public const string MeanRemoval = "mean removal";
        public const string Minimize = "minimize";
        public const string MotionBlur = "motion blur";
        public const string Noise = "noise";
        public const string Normalize = "normalize";
        public const string OilPaint = "oilpaint";
        public const string Palettize = "palettize";
        public const string PerChannelColorAdjustment = "perchannel";
        public const string PhongBumpMap = "phongbumpmap";
        public const string Pixelize = "pixelize";
        public const string Posterize = "posterize";
        public const string RainDrops = "raindrops";
        public const string RandomPick = "randompick";
        public const string ResetTransparent = "resettransparent";
        public const string RoundCorners = "roundcorners";
        public const string Sharpen = "sharpen";
        public const string SmallTiles = "smalltiles";
        public const string Threshold = "threshold";
        public const string Unsharp = "unsharp";
        public const string Wave = "wave";
        public const string WaveletNoiseReducer = "waveletnoisereducer";

        public static FilterDialogBase GetFilterDialogByFilterName(Client client, string filterName, bool isModal)
        {
            return filterName switch
            {
                AscCdl => new KritaFilterAscCdl(client, isModal),
                AutoConstrast => new KritaFilterAutoConstrast(client, isModal),
                Burn => new KritaFilterBurn(client, isModal),
                Blur => new KritaFilterBlur(client, isModal),
                ColorBalance => new KritaFilterColorBalance(client, isModal),
                ColorToAlpha => new KritaFilterColorToAlpha(client, isModal),
                ColorTransfer => new KritaFilterColorTranfer(client, isModal),
                CrossChannel => new KritaFilterCrossChannel(client, isModal),
                Desaturate => new KritaFilterDesaturate(client, isModal),
                Dodge => new KritaFilterDodge(client, isModal),
                EdgeDetection => new KritaFilterEdgeDetecttion(client, isModal),
                Emboss => new KritaFilterEmboss(client, isModal),
                EmbossAllDirections => new KritaFilterEmbossAllDirections(client, isModal),
                EmbossHorizontalAndVertical => new KritaFilterEmbossHorizontalAndVertical(client, isModal),
                EmbossHorizontalOnly => new KritaFilterEmbossHorizontalOnly(client, isModal),
                EmbossLaplascian => new KritaFilterEmbossLaplacian(client, isModal),
                EmbossVerticalOnly => new KritaFilterEmbossVerticalOnly(client, isModal),
                GaussianBlur => new KritaFilterGaussianBlur(client, isModal),
                GaussianHighPass => new KritaFilterGaussianHighPass(client, isModal),
                GaussianNoiseReducer => new KritaFilterGaussianNoiseReducer(client, isModal),
                GradientMap => new KritaFilterGradientMap(client, isModal),
                Halftone => new KritaFilterHalfTone(client, isModal),
                HeightToNormal => new KritaFilterHeightToNormal(client, isModal),
                HsvAdjustment => new KritaFilterHsvAdjustment(client, isModal),
                IndexColors => new KritaFilterIndexColors(client, isModal),
                Invert => new KritaFilterInvert(client, isModal),
                LensBlur => new KritaFilterLensBlur(client, isModal),
                Levels => new KritaFilterLevels(client, isModal),
                Maximize => new KritaFilterMaximize(client, isModal),
                MeanRemoval => new KritaFilterMeanRemoval(client, isModal),
                Minimize => new KritaFilterMinimize(client, isModal),
                MotionBlur => new KritaFilterMotionBlur(client, isModal),
                Noise => new KritaFilterNoise(client, isModal),
                Normalize => new KritaFilterNormalize(client, isModal),
                OilPaint => new KritaFilterOilPaint(client, isModal),
                Palettize => new KritaFilterPalettize(client, isModal),
                PerChannelColorAdjustment => new KritaFilterPerChannelColorAdjustment(client, isModal),
                PhongBumpMap => new KritaFilterPhongBumpMap(client, isModal),
                Pixelize => new KritaFilterPixelize(client, isModal),
                Posterize => new KritaFilterPosterize(client, isModal),
                RainDrops => new KritaFilterRainDrops(client, isModal),
                RandomPick => new KritaFilterRandomPick(client, isModal),
                ResetTransparent => new KritaFilterResetTransparent(client, isModal),
                RoundCorners => new KritaFilterRoundCorners(client, isModal),
                Sharpen => new KritaFilterSharpen(client, isModal),
                SmallTiles => new KritaFilterSmallTiles(client, isModal),
                Threshold => new KritaFilterThreshold(client, isModal),
                Unsharp => new KritaFilterUnsharp(client, isModal),
                Wave => new KritaFilterWave(client, isModal),
                WaveletNoiseReducer => new KritaFilterWaveletNoiseReducer(client, isModal),
                _ => throw new Exception("Not implement filter dialog")
            };
        }
    }
}
