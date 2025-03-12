namespace Loupedeck.KritaPlugin.DynamicFolders
{
    public class AdjustmentDefinition
    {
        private float _value;
        public event EventHandler<ValueCHangedEventArg> ValueChanged;

        public string Name { get; }
        public Func<float, int, float> OverrideAdjustmentCalculation { get; }
        public Func<DynamicFolderBase, float, float> Adjust { get; }
        public float Value
        {
            get => _value;
            set
            {
                _value = value;
                ValueChanged(this, new ValueCHangedEventArg(Name));
            }
        }
        public float DefaultValue { get; private set; }
        public int DisplayDigits { get; }
        public string DisplayUnit { get; }

        public AdjustmentDefinition(string name, Func<DynamicFolderBase, float, float> adjust, float defaultValue = 0, Func<float, int, float> overrideAdjustmentCalculation = null, int displayDecimals = 0, string displayUnit = "")
        {
            Name = name;
            Adjust = adjust;
            OverrideAdjustmentCalculation = overrideAdjustmentCalculation;
            DisplayDigits = displayDecimals;
            DisplayUnit = displayUnit;
            DefaultValue = defaultValue;
            _value = defaultValue;
        }

        public override string ToString()
        {
            return $"{Math.Round(Value, DisplayDigits)}{(string.IsNullOrEmpty(DisplayUnit) ? "" : " " + DisplayUnit)}";
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
