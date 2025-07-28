using LogiKritaApiClient.ClientBase;

namespace LogiKritaApiClient
{
    public class View() : LogiClientKritaBaseClass
    {
        public Task<Canvas> CurrentCanvas() => Get<Canvas>("canvas");
        public Task<float> BrushSize() => GetFloat("brushSize");
        public Task SetBrushSize(float size) => Execute("setBrushSize", size);
        public Task<float> BrushRotation() => GetFloat("brushRotation");
        public Task SetBrushRotation(float size) => Execute("setBrushRotation", size);
        public Task<float> PaintingFlow() => GetFloat("paintingFlow");
        public Task SetPaintingFlow(float flow) => Execute("setPaintingFlow", flow);
        public Task<float> PaintingOpacity() => GetFloat("paintingOpacity");
        public Task SetPaintingOpacity(float opacity) => Execute("setPaintingOpacity", opacity);
        public Task<float> PatternSize() => GetFloat("patternSize");
        public Task SetPatternSize(float size) => Execute("setPatternSize", size);

        public Task<bool> GlobalAlphaLock() => GetBool("globalAlphaLock");
        public Task SetGlobalAlphaLock(bool alphaLock) => Execute("setGlobalAlphaLock", alphaLock);
        public Task<bool> DisablePressure() => GetBool("disablePreset");
        public Task SetDisablePressure(bool disable) => Execute("setDisablePreset", disable);
        public Task<bool> EraserMode() => GetBool("eraserMode");
        public Task SetEraserMode(bool disable) => Execute("setEraserMode", disable);
    }
}
