using LoupedeckKritaApiClient;
using LoupedeckKritaApiClient.ClientBase;

namespace Loupedeck.KritaPlugin.DynamicFolders
{
    public abstract class FilterDialogBase : PluginDynamicFolder
    {
        protected Client Client => ((KritaApplication)Plugin.ClientApplication).Client;
        protected FilterDialogDefinition filterDialogDefinition;
        internal LoupedeckKritaApiClient.FiltersDialogs.FilterDialogBase Dialog { get; set; }

        private const string ShowDialog = "Show dialog";

        private const string ShowCreateFilterMaskName = "Set as mask";
        private const string Cancel = "Cancel";
        private const string Validate = "OK";
        private bool ShowCreateFilterMask;

        internal FilterDialogBase(string filterName)
        {
            filterDialogDefinition = FilterDialogDefinitionsList.FilterDialogDefintionList[filterName];
            DisplayName = filterDialogDefinition.Name;
            GroupName = ActionGroups.Filters;
            ShowCreateFilterMask = true;
        }

        internal FilterDialogBase()
        {
            DisplayName = "Filter Layer Properties";
            GroupName = ActionGroups.Filters;
            filterDialogDefinition = null;
            ShowCreateFilterMask = false;
        }

        public override PluginDynamicFolderNavigation GetNavigationArea(DeviceType _)
        {
            return PluginDynamicFolderNavigation.None;
        }

        public override bool Activate()
        {
            ResetDialog();

            Dialog = FilterDialog.GetFilterDialog(Client, filterDialogDefinition.FilterName).Result;

            return true;
        }

        public override bool Deactivate()
        {
            ResetDialog();
            return true;
        }

        protected void ResetDialog()
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
            if (filterDialogDefinition != null)
            {
                foreach (var command in filterDialogDefinition.Commands)
                {
                    commands.Add(CreateCommandName(command.Name));
                    commandsCount++;

                    if(commandsCount == 9 && ShowCreateFilterMask)
                    {
                        commands.Add(CreateCommandName(ShowCreateFilterMaskName));
                        commandsCount++;
                    }
                    if (commandsCount == 10)
                    {
                        commands.Add(CreateCommandName(Cancel));
                        commands.Add(CreateCommandName(Validate));
                        commandsCount = 0;
                    }
                }
            }

            if (commandsCount > 0)
            {
                while (commandsCount < (9 + (ShowCreateFilterMask?0:1)))
                {
                    commands.Add(string.Empty);
                    commandsCount++;
                }

                if (ShowCreateFilterMask)
                {
                    commands.Add(CreateCommandName(ShowCreateFilterMaskName));
                }
                commands.Add(CreateCommandName(Cancel));
                commands.Add(CreateCommandName(Validate));
            }

            return commands;
        }

        public override IEnumerable<string> GetEncoderRotateActionNames(DeviceType _)
        {
            List<string> adjustments = new List<string>();

            if (filterDialogDefinition != null)
            {
                foreach (var adjustment in filterDialogDefinition.Adjustments)
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

            if (filterDialogDefinition != null)
            {
                foreach (var adjustment in filterDialogDefinition.Adjustments)
                {
                    adjustments.Add(CreateCommandName(adjustment.Name));
                }
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
                case ShowCreateFilterMaskName:
                    SecureClose(() =>
                    {
                        Dialog.CreateMask().Wait();
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
