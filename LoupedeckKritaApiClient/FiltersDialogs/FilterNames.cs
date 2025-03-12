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

        public static FilterDialogBase GetFilterDialogByFilterName(Client client, string filterName)
        {
            return filterName switch
            {
                AscCdl => new KritaFilterAscCdl(client),
                AutoConstrast => new KritaFilterAutoConstrast(client),
                Burn => new KritaFilterBurn(client),
                Blur => new KritaFilterBlur(client),
                ColorBalance => new KritaFilterColorBalance(client),
                ColorToAlpha => new KritaFilterColorToAlpha(client),
                ColorTransfer => new KritaFilterColorTranfer(client),
                CrossChannel => new KritaFilterCrossChannel(client),
                Desaturate => new KritaFilterDesaturate(client),
                Dodge => new KritaFilterDodge(client),
                EdgeDetection => new KritaFilterEdgeDetecttion(client),
                Emboss => new KritaFilterEmboss(client),
                EmbossAllDirections => new KritaFilterEmbossAllDirections(client),
                EmbossHorizontalAndVertical => new KritaFilterEmbossHorizontalAndVertical(client),
                EmbossHorizontalOnly => new KritaFilterEmbossHorizontalOnly(client),
                EmbossLaplascian => new KritaFilterEmbossLaplacian(client),
                EmbossVerticalOnly => new KritaFilterEmbossVerticalOnly(client),
                GaussianBlur => new KritaFilterGaussianBlur(client),
                GaussianHighPass => new KritaFilterGaussianHighPass(client),
                GaussianNoiseReducer => new KritaFilterGaussianNoiseReducer(client),
                GradientMap => new KritaFilterGradientMap(client),
                Halftone => new KritaFilterHalfTone(client),
                HeightToNormal => new KritaFilterHeightToNormal(client),
                HsvAdjustment => new KritaFilterHsvAdjustment(client),
                IndexColors => new KritaFilterIndexColors(client),
                Invert => new KritaFilterInvert(client),
                LensBlur => new KritaFilterLensBlur(client),
                Levels => new KritaFilterLevels(client),
                Maximize => new KritaFilterMaximize(client),
                MeanRemoval => new KritaFilterMeanRemoval(client),
                Minimize => new KritaFilterMinimize(client),
                MotionBlur => new KritaFilterMotionBlur(client),
                Noise => new KritaFilterNoise(client),
                Normalize => new KritaFilterNormalize(client),
                OilPaint => new KritaFilterOilPaint(client),
                Palettize => new KritaFilterPalettize(client),
                PerChannelColorAdjustment => new KritaFilterPerChannelColorAdjustment(client),
                PhongBumpMap => new KritaFilterPhongBumpMap(client),
                Pixelize => new KritaFilterPixelize(client),
                Posterize => new KritaFilterPosterize(client),
                RainDrops => new KritaFilterRainDrops(client),
                RandomPick => new KritaFilterRandomPick(client),
                ResetTransparent => new KritaFilterResetTransparent(client),
                RoundCorners => new KritaFilterRoundCorners(client),
                Sharpen => new KritaFilterSharpen(client),
                SmallTiles => new KritaFilterSmallTiles(client),
                Threshold => new KritaFilterThreshold(client),
                Unsharp => new KritaFilterUnsharp(client),
                Wave => new KritaFilterWave(client),
                WaveletNoiseReducer => new KritaFilterWaveletNoiseReducer(client),
                _ => throw new Exception("Not implement filter dialog")
            };
        }
    }
}
