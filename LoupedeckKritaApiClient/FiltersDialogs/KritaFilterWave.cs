using LoupedeckKritaApiClient.ClientBase;

namespace LoupedeckKritaApiClient.FiltersDialogs
{
    public class KritaFilterWave(Client client) : FilterDialog(client)
    {
        protected override string ActionName => "krita_filter_wave";

        public enum Shape
        {
            Sinusoidal = 0,
            Triangle
        }

        public Task SetHorizontalWaveLength(int length)
        {
            return SetSpinBoxValue(length, "groupBox1", "intHWavelength");
        }

        public Task SetHorizontalShift(int value)
        {
            return SetSpinBoxValue(value, "groupBox1", "intHShift");
        }

        public Task SetHorizontalAmplitude(int value)
        {
            return SetSpinBoxValue(value, "groupBox1", "intHAmplitude");
        }

        public Task SetHorizontalShape(Shape shape)
        {
            return SetComboBoxSelectedIndex((int)shape, "groupBox1", "cbHShape");
        }

        public Task SetVerticalWaveLength(int length)
        {
            return SetSpinBoxValue(length, "Vertical_wave", "intVWavelength");
        }

        public Task SetVerticalShift(int value)
        {
            return SetSpinBoxValue(value, "Vertical_wave", "intVShift");
        }

        public Task SetVerticalAmplitude(int value)
        {
            return SetSpinBoxValue(value, "Vertical_wave", "intVAmplitude");
        }

        public Task SetVerticalShape(Shape shape)
        {
            return SetComboBoxSelectedIndex((int)shape, "Vertical_wave", "cbVShape");
        }
    }
}
