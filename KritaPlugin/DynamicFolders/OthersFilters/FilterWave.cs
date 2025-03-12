using LoupedeckKritaApiClient.FiltersDialogs;

namespace Loupedeck.KritaPlugin.DynamicFolders
{
    public class FilterWave : FilterDialogBase
    {
        public FilterWave()
            : base(FilterNames.Wave)
        {
        }

        static internal DialogDefinition GetDefinition()
        {
            return new DialogDefinition("Wave",
                FilterNames.Wave,
                [
                    new CommandDefinition("Hor. shape Sinus", (dialog) => (dialog.Dialog as KritaFilterWave).SetHorizontalShape(KritaFilterWave.Shape.Sinusoidal)),
                    new CommandDefinition("Hor. shape Triangle", (dialog) => (dialog.Dialog as KritaFilterWave).SetHorizontalShape(KritaFilterWave.Shape.Triangle)),

                    new CommandDefinition("Vert. shape Sinus", (dialog) => (dialog.Dialog as KritaFilterWave).SetVerticalShape(KritaFilterWave.Shape.Sinusoidal)),
                    new CommandDefinition("Vert. shape Triangle", (dialog) => (dialog.Dialog as KritaFilterWave).SetVerticalShape(KritaFilterWave.Shape.Triangle)),
                ],
                [
                    new AdjustmentDefinition("Hor. Wave length", (dialog, delta) => (dialog.Dialog as KritaFilterWave).AdjustHorizontalWaveLength((int)delta).Result, 50),
                    new AdjustmentDefinition("Hor. Shift", (dialog, delta) => (dialog.Dialog as KritaFilterWave).AdjustHorizontalShift((int)delta).Result, 50),
                    new AdjustmentDefinition("Hor. Amplitude", (dialog, delta) => (dialog.Dialog as KritaFilterWave).AdjustHorizontalAmplitude((int)delta).Result, 4),

                    new AdjustmentDefinition("Vert. Wave length", (dialog, delta) => (dialog.Dialog as KritaFilterWave).AdjustVerticalWaveLength((int)delta).Result, 50),
                    new AdjustmentDefinition("Vert. Shift", (dialog, delta) => (dialog.Dialog as KritaFilterWave).AdjustVerticalShift((int)delta).Result, 50),
                    new AdjustmentDefinition("Vert. Amplitude", (dialog, delta) => (dialog.Dialog as KritaFilterWave).AdjustVerticalAmplitude((int)delta).Result, 4),
                ]);
        }
    }
}
