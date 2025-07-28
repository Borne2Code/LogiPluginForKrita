using LogiKritaApiClient.FiltersDialogs;

namespace Logi.KritaPlugin.DynamicFolders
{
    public class FilterDialogDefinition: DialogDefinition
    {
        public FilterDialogDefinition(string name,
            string filterName,
            bool isMaskEnabled,
            string iconResourceName = null,
            ActionDefinition[] commandsAndAdjustments = null):

            base(name, 
                commandsAndAdjustments,
                [])
        {
            FilterName = filterName;
            IsMaskEnabled = isMaskEnabled;
            IconResourceName = iconResourceName;
            HasDialog = commandsAndAdjustments != null;
        }

        public string FilterName { get; }
        public bool IsMaskEnabled { get; }
        public string IconResourceName { get; }
        public bool HasDialog { get; }

        internal static FilterDialogDefinition GetDialogDefinition(string filterName)
        {
            switch (filterName)
            {
                case FilterNames.AscCdl: return FilterAscCdl.GetDefinition();
                case FilterNames.AutoConstrast: return FilterAutoContrast.GetDefinition();
                case FilterNames.Burn: return FilterBurn.GetDefinition();
                case FilterNames.ColorBalance: return FilterColorsBalance.GetDefinition();
                case FilterNames.CrossChannel: return FilterCrossChannelColorAdjustment.GetDefinition();
                case FilterNames.Desaturate: return FilterDesaturate.GetDefinition();
                case FilterNames.Dodge: return FilterDodge.GetDefinition();
                case FilterNames.HsvAdjustment: return FilterHsvHsl.GetDefinition();
                case FilterNames.Invert: return FilterInvert.GetDefinition();
                case FilterNames.Levels: return FilterLevels.GetDefinition();
                case FilterNames.PerChannelColorAdjustment: return FilterPerChannelColorAdjustment.GetDefinition();
                case FilterNames.Threshold: return FilterThreshold.GetDefinition();
                case FilterNames.Halftone: return FilterHalftone.GetDefinition();
                case FilterNames.IndexColors: return FilterIndexColors.GetDefinition();
                case FilterNames.OilPaint: return FilterOilPaint.GetDefinition();
                case FilterNames.Pixelize: return FilterPixelize.GetDefinition();
                case FilterNames.Posterize: return FilterPosterize.GetDefinition();
                case FilterNames.RainDrops: return FilterRainDrops.GetDefinition();
                case FilterNames.Blur: return FilterBlur.GetDefinition();
                case FilterNames.GaussianBlur: return FilterGaussianBlur.GetDefinition();
                case FilterNames.LensBlur: return FilterLensBlur.GetDefinition();
                case FilterNames.MotionBlur: return FilterMotionBlur.GetDefinition();
                case FilterNames.Maximize: return FilterColorMaximize.GetDefinition();
                case FilterNames.Minimize: return FilterColorMinimize.GetDefinition();
                case FilterNames.ColorToAlpha: return FilterColorToAlpha.GetDefinition();
                case FilterNames.ColorTransfer: return FilterColorTransfer.GetDefinition();
                case FilterNames.EdgeDetection: return FilterEdgeDetection.GetDefinition();
                case FilterNames.GaussianHighPass: return FilterGaussianHighPass.GetDefinition();
                case FilterNames.HeightToNormal: return FilterHeightToNormal.GetDefinition();
                case FilterNames.Emboss: return FilterEmboss.GetDefinition();
                case FilterNames.EmbossAllDirections: return FilterEmbossAllDirections.GetDefinition();
                case FilterNames.EmbossHorizontalOnly: return FilterEmbossHorizontalOnly.GetDefinition();
                case FilterNames.EmbossLaplascian: return FilterEmbossLaplacian.GetDefinition();
                case FilterNames.EmbossHorizontalAndVertical: return FilterEmbossVerticalAndHorizontal.GetDefinition();
                case FilterNames.EmbossVerticalOnly: return FilterEmbossVerticalOnly.GetDefinition();
                case FilterNames.GaussianNoiseReducer: return FilterGaussianNoiseReducer.GetDefinition();
                case FilterNames.MeanRemoval: return FilterMeanRemoval.GetDefinition();
                case FilterNames.Sharpen: return FilterSharpen.GetDefinition();
                case FilterNames.Unsharp: return FilterUnsharpMask.GetDefinition();
                case FilterNames.WaveletNoiseReducer: return FilterWaveletNoiseReducer.GetDefinition();
                case FilterNames.GradientMap: return FilterGradientMap.GetDefinition();
                case FilterNames.Normalize: return FilterNormalize.GetDefinition();
                case FilterNames.Palettize: return FilterPalettize.GetDefinition();
                case FilterNames.PhongBumpMap: return FilterPhongBumpmap.GetDefinition();
                case FilterNames.RoundCorners: return FilterRoundCorners.GetDefinition();
                case FilterNames.SmallTiles: return FilterSmallTiles.GetDefinition();
                case FilterNames.Noise: return FilterRandomNoise.GetDefinition();
                case FilterNames.RandomPick: return FilterRandomPick.GetDefinition();
                case FilterNames.ResetTransparent: return FilterResetTransparent.GetDefinition();
                case FilterNames.Wave: return FilterWave.GetDefinition();
                default: throw new ArgumentException($"Filter named {filterName} is unkown");
            }
        }
    }
}
