using LoupedeckKritaApiClient.FiltersDialogs;

namespace Loupedeck.KritaPlugin.DynamicFolders
{
    public class FilterWave : FilterDialogBase
    {
        public FilterWave()
            : base(GetDefinition())
        {
        }

        static internal FilterDialogDefinition GetDefinition()
        {
            return new FilterDialogDefinition("Wave",
                FiltersEnum.Wave,
                [
                    new FilterCommandDefinition("Hor. shape Sinus", (dialog) => ((KritaFilterWave)dialog.Dialog).SetHorizontalShape(KritaFilterWave.Shape.Sinusoidal)),
                    new FilterCommandDefinition("Hor. shape Triangle", (dialog) => ((KritaFilterWave)dialog.Dialog).SetHorizontalShape(KritaFilterWave.Shape.Triangle)),

                    new FilterCommandDefinition("Vert. shape Sinus", (dialog) => ((KritaFilterWave)dialog.Dialog).SetVerticalShape(KritaFilterWave.Shape.Sinusoidal)),
                    new FilterCommandDefinition("Vert. shape Triangle", (dialog) => ((KritaFilterWave)dialog.Dialog).SetVerticalShape(KritaFilterWave.Shape.Triangle)),
                ],
                [
                    new FilterAdjustmentDefinition("Hor. Wave length", (dialog, delta) => ((KritaFilterWave)dialog.Dialog).AdjustHorizontalWaveLength((int)delta).Result, 50),
                    new FilterAdjustmentDefinition("Hor. Shift", (dialog, delta) => ((KritaFilterWave)dialog.Dialog).AdjustHorizontalShift((int)delta).Result, 50),
                    new FilterAdjustmentDefinition("Hor. Amplitude", (dialog, delta) => ((KritaFilterWave)dialog.Dialog).AdjustHorizontalAmplitude((int)delta).Result, 4),

                    new FilterAdjustmentDefinition("Vert. Wave length", (dialog, delta) => ((KritaFilterWave)dialog.Dialog).AdjustVerticalWaveLength((int)delta).Result, 50),
                    new FilterAdjustmentDefinition("Vert. Shift", (dialog, delta) => ((KritaFilterWave)dialog.Dialog).AdjustVerticalShift((int)delta).Result, 50),
                    new FilterAdjustmentDefinition("Vert. Amplitude", (dialog, delta) => ((KritaFilterWave)dialog.Dialog).AdjustVerticalAmplitude((int)delta).Result, 4),
                ]);
        }
    }
}
