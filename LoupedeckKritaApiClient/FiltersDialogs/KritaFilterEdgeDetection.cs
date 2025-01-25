using System.Runtime.CompilerServices;
using LoupedeckKritaApiClient.ClientBase;

namespace LoupedeckKritaApiClient.FiltersDialogs
{
    public class KritaFilterEdgeDetecttion(Client client) : FilterDialog(client)
    {
        protected override string ActionName => "krita_filter_edge detection";

        public enum Formula
        {
            Prewitt = 0,
            Sobel,
            Simple
        }

        public enum Output
        {
            AllSides = 0,
            TopEdge,
            BottomEdge,
            RightEdge,
            LeftEdge,
            DirectionInRadians
        }

        public Task SelectFormula(Formula formula)
        {
            return SetComboBoxSelectedIndex((int)formula, "cmbType");
        }

        public Task SelectOutput(Output output)
        {
            return SetComboBoxSelectedIndex((int)output, "cmbOutput");
        }

        public Task SetHorizontalRadius(float value)
        {
            return SetSpinBoxValue(value, "sldHorizontalRadius");
        }

        public Task SetVerticalRadius(float value)
        {
            return SetSpinBoxValue(value, "sldVerticalRadius");
        }

        public Task ToggleApplyResultToAlphaChannel()
        {
            return ClickCheckBox("chkTransparent");
        }
    }
}
