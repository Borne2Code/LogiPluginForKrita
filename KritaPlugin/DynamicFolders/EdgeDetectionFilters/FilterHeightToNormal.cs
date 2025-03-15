using LoupedeckKritaApiClient.FiltersDialogs;

namespace Loupedeck.KritaPlugin.DynamicFolders
{
    public class FilterHeightToNormal : FilterDialogBase
    {
        public FilterHeightToNormal()
            : base(FilterNames.HeightToNormal)
        {
        }

        static internal FilterDialogDefinition GetDefinition()
        {
            return new FilterDialogDefinition("Height To Normal",
                FilterNames.HeightToNormal,
                "Loupedeck.KritaPlugin.images.Filters.filters-HeightToNormal.png",
                [
                    new CommandDefinition("Formula Prewitt", (dialog) => (dialog.Dialog as KritaFilterHeightToNormal).SetType(KritaFilterHeightToNormal.Type.Prewitt)),
                    new CommandDefinition("Formula Sobel", (dialog) => (dialog.Dialog as KritaFilterHeightToNormal).SetType(KritaFilterHeightToNormal.Type.Sobel)),
                    new CommandDefinition("Formula Simple", (dialog) => (dialog.Dialog as KritaFilterHeightToNormal).SetType(KritaFilterHeightToNormal.Type.Simple)),
                    
                    new CommandDefinition("Channel Blue", (dialog) => (dialog.Dialog as KritaFilterHeightToNormal).SetChannel(KritaFilterHeightToNormal.Channel.Blue)),
                    new CommandDefinition("Channel Green", (dialog) => (dialog.Dialog as KritaFilterHeightToNormal).SetChannel(KritaFilterHeightToNormal.Channel.Green)),
                    new CommandDefinition("Channel Red", (dialog) => (dialog.Dialog as KritaFilterHeightToNormal).SetChannel(KritaFilterHeightToNormal.Channel.Red)),
                    new CommandDefinition("Channel Alpha", (dialog) => (dialog.Dialog as KritaFilterHeightToNormal).SetChannel(KritaFilterHeightToNormal.Channel.Alpha)),

                    new CommandDefinition("Lock Hor./Vert.", (dialog) => (dialog.Dialog as KritaFilterHeightToNormal).ClickAspectButton()),

                    new CommandDefinition("X=X", (dialog) => (dialog.Dialog as KritaFilterHeightToNormal).SetXValue(KritaFilterHeightToNormal.XYZ.XPlus)),
                    new CommandDefinition("X=-X", (dialog) => (dialog.Dialog as KritaFilterHeightToNormal).SetXValue(KritaFilterHeightToNormal.XYZ.XMinus)),
                    new CommandDefinition("X=Y", (dialog) => (dialog.Dialog as KritaFilterHeightToNormal).SetXValue(KritaFilterHeightToNormal.XYZ.YPlus)),
                    new CommandDefinition("X=-Y", (dialog) => (dialog.Dialog as KritaFilterHeightToNormal).SetXValue(KritaFilterHeightToNormal.XYZ.YMinus)),
                    new CommandDefinition("X=Z", (dialog) => (dialog.Dialog as KritaFilterHeightToNormal).SetXValue(KritaFilterHeightToNormal.XYZ.ZPlus)),
                    new CommandDefinition("X=-Z", (dialog) => (dialog.Dialog as KritaFilterHeightToNormal).SetXValue(KritaFilterHeightToNormal.XYZ.ZMinus)),
                    new CommandDefinition("Y=X", (dialog) => (dialog.Dialog as KritaFilterHeightToNormal).SetYValue(KritaFilterHeightToNormal.XYZ.XPlus)),
                    new CommandDefinition("Y=-X", (dialog) => (dialog.Dialog as KritaFilterHeightToNormal).SetYValue(KritaFilterHeightToNormal.XYZ.XMinus)),
                    new CommandDefinition("Y=Y", (dialog) => (dialog.Dialog as KritaFilterHeightToNormal).SetYValue(KritaFilterHeightToNormal.XYZ.YPlus)),
                    new CommandDefinition("Y=-Y", (dialog) => (dialog.Dialog as KritaFilterHeightToNormal).SetYValue(KritaFilterHeightToNormal.XYZ.YMinus)),
                    new CommandDefinition("Y=Z", (dialog) => (dialog.Dialog as KritaFilterHeightToNormal).SetYValue(KritaFilterHeightToNormal.XYZ.ZPlus)),
                    new CommandDefinition("Y=-Z", (dialog) => (dialog.Dialog as KritaFilterHeightToNormal).SetYValue(KritaFilterHeightToNormal.XYZ.ZMinus)),
                    new CommandDefinition("Z=X", (dialog) => (dialog.Dialog as KritaFilterHeightToNormal).SetZValue(KritaFilterHeightToNormal.XYZ.XPlus)),
                    new CommandDefinition("Z=-X", (dialog) => (dialog.Dialog as KritaFilterHeightToNormal).SetZValue(KritaFilterHeightToNormal.XYZ.XMinus)),
                    new CommandDefinition("Z=Y", (dialog) => (dialog.Dialog as KritaFilterHeightToNormal).SetZValue(KritaFilterHeightToNormal.XYZ.YPlus)),
                    new CommandDefinition("Z=-Y", (dialog) => (dialog.Dialog as KritaFilterHeightToNormal).SetZValue(KritaFilterHeightToNormal.XYZ.YMinus)),
                    new CommandDefinition("Z=Z", (dialog) => (dialog.Dialog as KritaFilterHeightToNormal).SetZValue(KritaFilterHeightToNormal.XYZ.ZPlus)),
                    new CommandDefinition("Z=-Z", (dialog) => (dialog.Dialog as KritaFilterHeightToNormal).SetZValue(KritaFilterHeightToNormal.XYZ.ZMinus)),
                ],
                [
                    new AdjustmentDefinition("Horizontal radius", (dialog, delta) => (dialog.Dialog as KritaFilterHeightToNormal).AdjustHorizontalRadius(delta).Result, 1),
                    new AdjustmentDefinition("Vertical radius", (dialog, delta) => (dialog.Dialog as KritaFilterHeightToNormal).AdjustVerticalRadius(delta).Result, 1),
                ]);
        }
    }
}
