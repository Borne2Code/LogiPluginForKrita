using Loupedeck.KritaPlugin.DynamicFolders.FilterDefinitions;
using LoupedeckKritaApiClient.FiltersDialogs;

namespace Loupedeck.KritaPlugin.DynamicFolders
{
    public class FilterHeightToNormal : FilterDialogBase
    {
        public FilterHeightToNormal()
            : base(GetDefinition())
        {
        }

        static internal FilterDialogDefinition GetDefinition()
        {
            return new FilterDialogDefinition("Height To Normal",
                FiltersEnum.HeightToNormal,
                [
                    new FilterCommandDefinition("Formula Prewitt", (dialog) => ((KritaFilterHeightToNormal)dialog.Dialog).SetType(KritaFilterHeightToNormal.Type.Prewitt)),
                    new FilterCommandDefinition("Formula Sobel", (dialog) => ((KritaFilterHeightToNormal)dialog.Dialog).SetType(KritaFilterHeightToNormal.Type.Sobel)),
                    new FilterCommandDefinition("Formula Simple", (dialog) => ((KritaFilterHeightToNormal)dialog.Dialog).SetType(KritaFilterHeightToNormal.Type.Simple)),
                    
                    new FilterCommandDefinition("Channel Blue", (dialog) => ((KritaFilterHeightToNormal)dialog.Dialog).SetChannel(KritaFilterHeightToNormal.Channel.Blue)),
                    new FilterCommandDefinition("Channel Green", (dialog) => ((KritaFilterHeightToNormal)dialog.Dialog).SetChannel(KritaFilterHeightToNormal.Channel.Green)),
                    new FilterCommandDefinition("Channel Red", (dialog) => ((KritaFilterHeightToNormal)dialog.Dialog).SetChannel(KritaFilterHeightToNormal.Channel.Red)),
                    new FilterCommandDefinition("Channel Alpha", (dialog) => ((KritaFilterHeightToNormal)dialog.Dialog).SetChannel(KritaFilterHeightToNormal.Channel.Alpha)),

                    new FilterCommandDefinition("Lock Hor./Vert.", (dialog) => ((KritaFilterHeightToNormal)dialog.Dialog).ClickAspectButton()),

                    new FilterCommandDefinition("X=X", (dialog) => ((KritaFilterHeightToNormal)dialog.Dialog).SetXValue(KritaFilterHeightToNormal.XYZ.XPlus)),
                    new FilterCommandDefinition("X=-X", (dialog) => ((KritaFilterHeightToNormal)dialog.Dialog).SetXValue(KritaFilterHeightToNormal.XYZ.XMinus)),
                    new FilterCommandDefinition("X=Y", (dialog) => ((KritaFilterHeightToNormal)dialog.Dialog).SetXValue(KritaFilterHeightToNormal.XYZ.YPlus)),
                    new FilterCommandDefinition("X=-Y", (dialog) => ((KritaFilterHeightToNormal)dialog.Dialog).SetXValue(KritaFilterHeightToNormal.XYZ.YMinus)),
                    new FilterCommandDefinition("X=Z", (dialog) => ((KritaFilterHeightToNormal)dialog.Dialog).SetXValue(KritaFilterHeightToNormal.XYZ.ZPlus)),
                    new FilterCommandDefinition("X=-Z", (dialog) => ((KritaFilterHeightToNormal)dialog.Dialog).SetXValue(KritaFilterHeightToNormal.XYZ.ZMinus)),
                    new FilterCommandDefinition("Y=X", (dialog) => ((KritaFilterHeightToNormal)dialog.Dialog).SetYValue(KritaFilterHeightToNormal.XYZ.XPlus)),
                    new FilterCommandDefinition("Y=-X", (dialog) => ((KritaFilterHeightToNormal)dialog.Dialog).SetYValue(KritaFilterHeightToNormal.XYZ.XMinus)),
                    new FilterCommandDefinition("Y=Y", (dialog) => ((KritaFilterHeightToNormal)dialog.Dialog).SetYValue(KritaFilterHeightToNormal.XYZ.YPlus)),
                    new FilterCommandDefinition("Y=-Y", (dialog) => ((KritaFilterHeightToNormal)dialog.Dialog).SetYValue(KritaFilterHeightToNormal.XYZ.YMinus)),
                    new FilterCommandDefinition("Y=Z", (dialog) => ((KritaFilterHeightToNormal)dialog.Dialog).SetYValue(KritaFilterHeightToNormal.XYZ.ZPlus)),
                    new FilterCommandDefinition("Y=-Z", (dialog) => ((KritaFilterHeightToNormal)dialog.Dialog).SetYValue(KritaFilterHeightToNormal.XYZ.ZMinus)),
                    new FilterCommandDefinition("Z=X", (dialog) => ((KritaFilterHeightToNormal)dialog.Dialog).SetZValue(KritaFilterHeightToNormal.XYZ.XPlus)),
                    new FilterCommandDefinition("Z=-X", (dialog) => ((KritaFilterHeightToNormal)dialog.Dialog).SetZValue(KritaFilterHeightToNormal.XYZ.XMinus)),
                    new FilterCommandDefinition("Z=Y", (dialog) => ((KritaFilterHeightToNormal)dialog.Dialog).SetZValue(KritaFilterHeightToNormal.XYZ.YPlus)),
                    new FilterCommandDefinition("Z=-Y", (dialog) => ((KritaFilterHeightToNormal)dialog.Dialog).SetZValue(KritaFilterHeightToNormal.XYZ.YMinus)),
                    new FilterCommandDefinition("Z=Z", (dialog) => ((KritaFilterHeightToNormal)dialog.Dialog).SetZValue(KritaFilterHeightToNormal.XYZ.ZPlus)),
                    new FilterCommandDefinition("Z=-Z", (dialog) => ((KritaFilterHeightToNormal)dialog.Dialog).SetZValue(KritaFilterHeightToNormal.XYZ.ZMinus)),
                ],
                [
                    new FilterAdjustmentDefinition("Horizontal radius", (dialog, _, delta) => ((KritaFilterHeightToNormal)dialog.Dialog).AdjustHorizontalRadius(delta).Result),
                    new FilterAdjustmentDefinition("Vertical radius", (dialog, _, delta) => ((KritaFilterHeightToNormal)dialog.Dialog).AdjustVerticalRadius(delta).Result),
                ]);
        }
    }
}
