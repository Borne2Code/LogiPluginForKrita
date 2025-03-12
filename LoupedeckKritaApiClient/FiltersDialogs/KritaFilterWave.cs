using LoupedeckKritaApiClient.ClientBase;

namespace LoupedeckKritaApiClient.FiltersDialogs
{
    public class KritaFilterWave(Client client) : FilterDialogBase(client)
    {
        internal override string ActionName => "krita_filter_wave";

        public enum Shape
        {
            Sinusoidal = 0,
            Triangle
        }

        public Task<int> AdjustHorizontalWaveLength(int length)
        {
            return AdjustIntSpinBoxValue(length, "groupBox1", "intHWavelength");
        }

        public Task<int> AdjustHorizontalShift(int value)
        {
            return AdjustIntSpinBoxValue(value, "groupBox1", "intHShift");
        }

        public Task<int> AdjustHorizontalAmplitude(int value)
        {
            return AdjustIntSpinBoxValue(value, "groupBox1", "intHAmplitude");
        }

        public Task SetHorizontalShape(Shape shape)
        {
            return SetComboBoxSelectedIndex((int)shape, "groupBox1", "cbHShape");
        }

        public Task<int> AdjustVerticalWaveLength(int length)
        {
            return AdjustIntSpinBoxValue(length, "Vertical_wave", "intVWavelength");
        }

        public Task<int> AdjustVerticalShift(int value)
        {
            return AdjustIntSpinBoxValue(value, "Vertical_wave", "intVShift");
        }

        public Task<int> AdjustVerticalAmplitude(int value)
        {
            return AdjustIntSpinBoxValue(value, "Vertical_wave", "intVAmplitude");
        }

        public Task SetVerticalShape(Shape shape)
        {
            return SetComboBoxSelectedIndex((int)shape, "Vertical_wave", "cbVShape");
        }
    }
}
