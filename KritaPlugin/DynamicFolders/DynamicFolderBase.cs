using System.Reflection;
using LoupedeckKritaApiClient;
using LoupedeckKritaApiClient.ClientBase;

namespace Loupedeck.KritaPlugin.DynamicFolders
{
    public abstract class DynamicFolderBase : PluginDynamicFolder
    {
        protected Client Client => ((KritaApplication)Plugin.ClientApplication).Client;
        internal KritaDialogBase Dialog { get; set; }
        protected DialogDefinition dialogDefinition;
        private string IconResourceName = null;

        private const string ShowDialogString = "Show dialog";

        internal DynamicFolderBase(string displayName, string iconResourceName, string groupName)
        {
            DisplayName = displayName;
            GroupName = groupName;
            dialogDefinition = null;
            IconResourceName = iconResourceName;
        }

        public override BitmapImage GetButtonImage(PluginImageSize imageSize)
        {
            if (IconResourceName == null)
            {
                return null;
            }

            return PluginResources.BitmapFromEmbaddedRessource(IconResourceName);
        }

        public override PluginDynamicFolderNavigation GetNavigationArea(DeviceType _)
        {
            return PluginDynamicFolderNavigation.None;
        }

        protected abstract bool ShowDialog();
        protected abstract void ResetDialog();

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

        public override IEnumerable<string> GetButtonPressActionNames(DeviceType deviceType)
        {
            List<string> commands = new List<string>();
            int numberOfCommandsPerPage = 12;
            ActionDefinition[] dialogCommands;

            if (deviceType == DeviceType.Loupedeck70)
            {
                numberOfCommandsPerPage = 8;
                dialogCommands = dialogDefinition.CommandsAndAdjustments;
            }
            else
            {
                dialogCommands = dialogDefinition.CommandsAndAdjustments.Where(c => c is CommandDefinition).ToArray();
            }

            commands.Add(CreateCommandName(ShowDialogString));

            var commandsCount = 1;
            if (dialogDefinition != null)
            {
                foreach (var command in dialogCommands)
                {
                    if (command is AdjustmentDefinition adjustment)
                    {
                        commands.Add(CreateAdjustmentName(adjustment.Name));
                        adjustment.ValueChanged += Adjustment_ValueChanged;
                    }
                    else
                    {
                        commands.Add(CreateCommandName(command.Name));
                    }
                    commandsCount++;

                    
                    if(commandsCount == numberOfCommandsPerPage - dialogDefinition.FixedCommands.Length)
                    { 
                        foreach(var fixedCommand in dialogDefinition.FixedCommands)
                        {
                            commands.Add(CreateCommandName(fixedCommand.Name));
                        }
                        commandsCount = 0;
                    }
                }
            }

            if (commandsCount > 0)
            {
                while (commandsCount < (numberOfCommandsPerPage - dialogDefinition.FixedCommands.Length))
                {
                    commands.Add(string.Empty);
                    commandsCount++;
                }

                foreach (var fixedCommand in dialogDefinition.FixedCommands)
                {
                    commands.Add(CreateCommandName(fixedCommand.Name));
                }
            }

            return commands;
        }

        public override IEnumerable<string> GetEncoderRotateActionNames(DeviceType deviceType)
        {
            if (deviceType == DeviceType.Loupedeck70)
            {
                return null;
            }

            List<string> adjustments = new List<string>();

            if (dialogDefinition != null)
            {
                foreach (var adjustment in dialogDefinition.CommandsAndAdjustments.Where(c => c is AdjustmentDefinition).Select(c => c as AdjustmentDefinition))
                {
                    adjustments.Add(CreateAdjustmentName(adjustment.Name));
                    adjustment.ValueChanged += Adjustment_ValueChanged;
                }
            }

            return adjustments;
        }

        public override IEnumerable<string> GetEncoderPressActionNames(DeviceType deviceType)
        {
            if (deviceType == DeviceType.Loupedeck70)
            {
                return null;
            }

            List<string> adjustments = new List<string>();

            if (dialogDefinition != null)
            {
                foreach (var adjustment in dialogDefinition.CommandsAndAdjustments.Where(c => c is AdjustmentDefinition).Select(c => c as AdjustmentDefinition))
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
            var adjustment = dialogDefinition.CommandsAndAdjustments.Where(adj => adj.Name == actionParameter).First() as AdjustmentDefinition;

            float targetAdjustment = diff;
            if (adjustment.OverrideAdjustmentCalculation != null)
            {
                targetAdjustment = adjustment.OverrideAdjustmentCalculation(adjustment.Value, diff);
            }

            adjustment.Value = adjustment.Adjust(this, targetAdjustment);
        }

        public override void RunCommand(string actionParameter)
        {
            if (actionParameter == ShowDialogString)
                    Activate();
            else
            {
                var command = dialogDefinition.CommandsAndAdjustments.Where(cmd => cmd.Name == actionParameter).FirstOrDefault() as CommandDefinition;
                if (command != null)
                {
                    SecureCall(() => command.Action(this).Wait(), command.ShoudClose);
                }
                else
                {
                    command = dialogDefinition.FixedCommands.Where(cmd => cmd.Name == actionParameter).FirstOrDefault();
                    if (command != null)
                    {
                        SecureCall(() => command.Action(this).Wait(), command.ShoudClose);
                    }
                    else
                    {
                        var adjustment = dialogDefinition.CommandsAndAdjustments.Where(adj => adj.Name == actionParameter).FirstOrDefault() as AdjustmentDefinition;
                        if (adjustment != null)
                            adjustment.Value = adjustment.Adjust(this, adjustment.DefaultValue - adjustment.Value);
                    }
                }
            }
        }

        public override string GetAdjustmentValue(string actionParameter)
        {
            return dialogDefinition.CommandsAndAdjustments.Where(adj => adj.Name == actionParameter).First().ToString();
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
