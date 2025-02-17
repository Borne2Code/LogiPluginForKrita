using LoupedeckKritaApiClient;
using LoupedeckKritaApiClient.FiltersDialogs;

namespace Loupedeck.KritaPlugin.DynamicFolders.FilterDefinitions
{
    public abstract class FilterDialogBase : PluginDynamicFolder
    {
        private KritaPlugin KritaPlugin => (KritaPlugin)Plugin;
        private FilterDialogDefinition filterDialogDefinition;
        internal FilterDialog Dialog { get; private set; }

        private const string ShowDialog = "Show dialog";

        private const string Cancel = "Cancel";
        private const string Validate = "OK";

        internal FilterDialogBase(FilterDialogDefinition filterDefinition)
        {
            DisplayName = filterDefinition.Name;
            GroupName = ActionGroups.Filters;
            filterDialogDefinition = filterDefinition;
        }

        public override PluginDynamicFolderNavigation GetNavigationArea(DeviceType _)
        {
            return PluginDynamicFolderNavigation.None;
        }

        public override bool Activate()
        {
            ResetDialog();

            Dialog = Filter.GetFilterDialog(KritaPlugin.Client, filterDialogDefinition.FilterType).Result;
            return true;
        }

        public override bool Deactivate()
        {
            ResetDialog();
            return true;
        }

        private void ResetDialog()
        {
            if (Dialog != null)
            {
                try
                {
                    Dialog.DisposeAsync().AsTask().Wait();
                }
                finally
                {
                    Dialog = null;
                }
            }
        }

        public override IEnumerable<string> GetButtonPressActionNames(DeviceType _)
        {
            List<string> commands = new List<string>();

            commands.Add(CreateCommandName(ShowDialog));

            var commandsCount = 1;
            foreach (var command in filterDialogDefinition.Commands)
            {
                commands.Add(CreateCommandName(command.Name));
                commandsCount++;

                if (commandsCount == 10)
                {
                    commands.Add(CreateCommandName(Cancel));
                    commands.Add(CreateCommandName(Validate));
                    commandsCount = 0;
                }
            }

            if (commandsCount > 0)
            {
                while (commandsCount < 10)
                {
                    commands.Add(string.Empty);
                    commandsCount++;
                }

                commands.Add(CreateCommandName(Cancel));
                commands.Add(CreateCommandName(Validate));
            }

            return commands;
        }

        public override IEnumerable<string> GetEncoderRotateActionNames(DeviceType _)
        {
            List<string> adjustments = new List<string>();

            foreach (var adjustment in filterDialogDefinition.Adjustments)
            {
                adjustments.Add(CreateAdjustmentName(adjustment.Name));
                adjustment.ValueChanged += Adjustment_ValueChanged;
            }

            return adjustments;
        }

        public override IEnumerable<string> GetEncoderPressActionNames(DeviceType _)
        {
            List<string> adjustments = new List<string>();

            foreach (var adjustment in filterDialogDefinition.Adjustments)
            {
                adjustments.Add(CreateCommandName(adjustment.Name));
            }

            return adjustments;
        }

        private void Adjustment_ValueChanged(object sender, ValueCHangedEventArg e)
        {
            AdjustmentValueChanged(((FilterAdjustmentDefinition)sender).Name);
        }

        public override void ApplyAdjustment(string actionParameter, int diff)
        {
            var adjustment = filterDialogDefinition.Adjustments.Where(adj => adj.Name == actionParameter).First();

            float targetAdjustment = diff;
            if (adjustment.OverrideAdjustmentCalculation != null)
            {
                targetAdjustment = adjustment.OverrideAdjustmentCalculation(adjustment.Value, diff);
            }

            adjustment.Value = adjustment.Adjust(this, targetAdjustment);
        }

        public override void RunCommand(string actionParameter)
        {
            switch (actionParameter)
            {
                case ShowDialog:
                    Activate();
                    break;
                case Validate:
                    SecureClose(() =>
                    {
                        Dialog.Confirm().Wait();
                    });
                    break;
                case Cancel:
                    SecureClose(() =>
                    {
                        Dialog.Cancel().Wait();
                    });
                    break;
                default:
                    var command = filterDialogDefinition.Commands.Where(cmd => cmd.Name == actionParameter).FirstOrDefault();
                    if (command != null)
                    {
                        command.Action(this);
                    }
                    else
                    {
                        var adjustment = filterDialogDefinition.Adjustments.Where(adj => adj.Name == actionParameter).FirstOrDefault();
                        adjustment.Value = adjustment.Adjust(this, adjustment.DefaultValue - adjustment.Value);
                    }
                    break;
            }
        }

        public override string GetAdjustmentValue(string actionParameter)
        {
            return filterDialogDefinition.Adjustments.Where(adj => adj.Name == actionParameter).First().ToString();
        }

        void SecureCall(Action action)
        {
            try
            {
                action();
            }
            catch
            {
                Deactivate();
                Activate();
            }
        }

        private void SecureClose(Action action)
        {
            try
            {
                action();
            }
            finally
            {
                Deactivate();
                Close();
            }
        }
    }
}
