using LoupedeckKritaApiClient;
using LoupedeckKritaApiClient.ClientBase;

namespace Loupedeck.KritaPlugin.DynamicFolders
{
    public abstract class DynamicFolderBase : PluginDynamicFolder
    {
        protected Client Client => ((KritaApplication)Plugin.ClientApplication).Client;
        internal KritaDialogBase Dialog { get; set; }
        protected DialogDefinition dialogDefinition;
        protected CommandDefinition[] FixedCommands;

        private const string ShowDialogString = "Show dialog";

        private const string CancelString = "Cancel";
        private const string ValidateString = "OK";

        internal DynamicFolderBase(string displayName, string groupName, params CommandDefinition[] fixedCommands)
        {
            DisplayName = displayName;
            GroupName = groupName;
            FixedCommands = fixedCommands;
            dialogDefinition = null;
        }

        public override PluginDynamicFolderNavigation GetNavigationArea(DeviceType _)
        {
            return PluginDynamicFolderNavigation.None;
        }

        protected abstract bool ShowDialog();
        protected abstract void ResetDialog();
        protected abstract void ValidateDialog();
        protected abstract void CancelDialog();

        public override bool Activate()
        {
            ResetDialog();
            return ShowDialog();
        }

        public override bool Deactivate()
        {
            ResetDialog();
            return true;
        }

        public override IEnumerable<string> GetButtonPressActionNames(DeviceType _)
        {
            List<string> commands = new List<string>();

            commands.Add(CreateCommandName(ShowDialogString));

            var commandsCount = 1;
            if (dialogDefinition != null)
            {
                foreach (var command in dialogDefinition.Commands)
                {
                    commands.Add(CreateCommandName(command.Name));
                    commandsCount++;

                    if(commandsCount == 10 - FixedCommands.Length)
                    { 
                        foreach(var fixedCommand in FixedCommands)
                        {
                            commands.Add(CreateCommandName(fixedCommand.Name));
                        }
                        commands.Add(CreateCommandName(CancelString));
                        commands.Add(CreateCommandName(ValidateString));
                        commandsCount = 0;
                    }
                }
            }

            if (commandsCount > 0)
            {
                while (commandsCount < (10 - FixedCommands.Length))
                {
                    commands.Add(string.Empty);
                    commandsCount++;
                }

                foreach (var fixedCommand in FixedCommands)
                {
                    commands.Add(CreateCommandName(fixedCommand.Name));
                }
                commands.Add(CreateCommandName(CancelString));
                commands.Add(CreateCommandName(ValidateString));
            }

            return commands;
        }

        public override IEnumerable<string> GetEncoderRotateActionNames(DeviceType _)
        {
            List<string> adjustments = new List<string>();

            if (dialogDefinition != null)
            {
                foreach (var adjustment in dialogDefinition.Adjustments)
                {
                    adjustments.Add(CreateAdjustmentName(adjustment.Name));
                    adjustment.ValueChanged += Adjustment_ValueChanged;
                }
            }

            return adjustments;
        }

        public override IEnumerable<string> GetEncoderPressActionNames(DeviceType _)
        {
            List<string> adjustments = new List<string>();

            if (dialogDefinition != null)
            {
                foreach (var adjustment in dialogDefinition.Adjustments)
                {
                    adjustments.Add(CreateCommandName(adjustment.Name));
                }
            }

            return adjustments;
        }

        private void Adjustment_ValueChanged(object sender, ValueCHangedEventArg e)
        {
            AdjustmentValueChanged(((AdjustmentDefinition)sender).Name);
        }

        public override void ApplyAdjustment(string actionParameter, int diff)
        {
            var adjustment = dialogDefinition.Adjustments.Where(adj => adj.Name == actionParameter).First();

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
                case ShowDialogString:
                    Activate();
                    break;
                case ValidateString:
                    SecureCall(() =>
                    {
                        ValidateDialog();
                    }, true);
                    break;
                case CancelString:
                    SecureCall(() =>
                    {
                        CancelDialog();
                    }, true);
                    break;
                default:
                    var command = dialogDefinition.Commands.Where(cmd => cmd.Name == actionParameter).FirstOrDefault();
                    if (command != null)
                    {
                        SecureCall(() => command.Action(this).Wait(), command.ShoudClose);
                    }
                    else
                    {
                        command = FixedCommands.Where(cmd => cmd.Name == actionParameter).FirstOrDefault();
                        if (command != null)
                        {
                            SecureCall(() => command.Action(this).Wait(), command.ShoudClose);
                        }
                        else
                        {
                            var adjustment = dialogDefinition.Adjustments.Where(adj => adj.Name == actionParameter).FirstOrDefault();
                            if (adjustment != null)
                                adjustment.Value = adjustment.Adjust(this, adjustment.DefaultValue - adjustment.Value);
                        }
                    }
                    break;
            }
        }

        public override string GetAdjustmentValue(string actionParameter)
        {
            return dialogDefinition.Adjustments.Where(adj => adj.Name == actionParameter).First().ToString();
        }

        void SecureCall(Action action, bool shouldClose)
        {
            if (shouldClose)
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
            else
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
        }
    }
}
