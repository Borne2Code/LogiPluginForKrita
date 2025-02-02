using System.Reflection.Metadata.Ecma335;

namespace Loupedeck.KritaPlugin.DynamicFolders.FilterDefinitions
{
    internal class FilterAdjustmentDefinition
    {
        private float _value;
        public event EventHandler<ValueCHangedEventArg> ValueChanged;

        public string Name { get; }
        public Func<FilterDialogBase, int, float> Adjust { get; }
        public Action<FilterDialogBase> Action { get; }
        public float Value
        {
            get => _value;
            set
            {
                _value = value;
                ValueChanged(this, new ValueCHangedEventArg(Name));
            }
        }
        public int DisplayDigits { get; }
        public string DisplayUnit { get; }

        public FilterAdjustmentDefinition(string name, Func<FilterDialogBase, int, float> adjust, Action<FilterDialogBase> action = null, int displayDecimals = 0, string displayUnit = "")
        {
            Name = name;
            Adjust = adjust;
            Action = action;
            DisplayDigits = displayDecimals;
            DisplayUnit = displayUnit;
        }

        public override string ToString()
        {
            return $"{Math.Round(Value, DisplayDigits)}{(string.IsNullOrEmpty(DisplayUnit) ? "" : (" " + DisplayUnit))}";
        }
    }

    public class ValueCHangedEventArg : EventArgs
    {
        public string AdjustmentName { get; }
        public ValueCHangedEventArg(string adjustmentName)
        {
            AdjustmentName = adjustmentName;
        }
    }
}
