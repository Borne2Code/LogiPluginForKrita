using LogiKritaApiClient.ClientBase;

namespace LogiKritaApiClient
{
    public class View() : LogiClientKritaBaseClass
    {
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
    }
}
