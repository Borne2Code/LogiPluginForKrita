using LoupedeckKritaApiClient;
using LoupedeckKritaApiClient.ClientBase;
using LoupedeckKritaApiClient.FiltersDialogs;

namespace LoupedeckClient
{
    public partial class Form1 : Form
    {
        private long dpi;
        private Client? client;

        private Window? window;
        private LoupedeckKritaApiClient.View? view;
        private Canvas? canvas;

        private FilterDialogBase filterDialog;

        public Form1()
        {
            InitializeComponent();
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            client = new Client();
            await client.Connect();

            await using var activeDocument = await client.KritaInstance.ActiveDocument();
            dpi = await activeDocument.GetResolution();
            window = await client.KritaInstance.ActiveWindow();
            view = await window.ActiveView();
            canvas = await view.CurrentCanvas();
            //trackBar1.Value = (int)(await canvas.ZoomLevel() * 75 * 100 / dpi);
            //trackBar2.Value = (int)(await canvas.Rotation());

            ActionList.Items.AddRange((await client.KritaInstance.Actions()).ToArray());
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            trackBar1.Value = 100;
        }

        private async void Button2_Click(object sender, EventArgs e)
        {
            if (canvas != null)
            {
                trackBar1.Value = (int)(await canvas.ZoomLevel() * 7200 / dpi);
            }
        }

        bool isRunning = false;
        private async void TrackBar1_ValueChanged(object sender, EventArgs e)
        {
            if (!isRunning && canvas != null)
            {
                try
                {
                    isRunning = true;
                    await canvas.SetZoomLevel((float)trackBar1.Value / 100);
                    label1.Text = trackBar1.Value.ToString();
                }
                catch (Exception ex)
                {
                    label1.Text = "Erreur : " + ex.Message;
                }
                finally
                {
                    isRunning = false;
                }
            }
        }

        private async void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            //if (window != null) await window.DisposeAsync();
            //if (view != null) await view.DisposeAsync();
            //if (canvas != null) await canvas.DisposeAsync();
            if (client != null) await client.DisposeAsync();
        }

        private async void Button3_Click(object sender, EventArgs e)
        {
            if (canvas != null)
            {
                trackBar2.Value = (int)(await canvas.Rotation());
            }
        }

        private async void TrackBar2_ValueChanged(object sender, EventArgs e)
        {
            if (!isRunning && canvas != null)
            {
                try
                {
                    isRunning = true;
                    await canvas.SetRotation(trackBar2.Value);
                }
                catch (Exception ex)
                {
                    label1.Text = "Erreur : " + ex.Message;
                }
                finally
                {
                    isRunning = false;
                }
            }
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            trackBar2.Value = 0;
        }

        private async void TriggerAction_Click(object sender, EventArgs e)
        {
            if (ActionList.SelectedItem != null && client != null)
            {
                await using var action = await client.KritaInstance.Action((string)ActionList.SelectedItem);
                action?.Trigger();
            }
        }

        private async Task ActivateFilterDialog(string filterName)
        {
            if (filterDialog != null)
            {
                await filterDialog.DisposeAsync();
            }

            //filterDialog = await FilterDialog.GetFilterDialog(client, filterName);
        }

        private async void button5_Click(object sender, EventArgs e)
        {
            await ActivateFilterDialog(FilterNames.Burn);
        }

        private async void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (filterDialog is KritaFilterBurn filter)
                if (radioButton3.Checked) await filter.SelectHighLights();
        }

        private async void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (filterDialog is KritaFilterBurn filter)
                if (radioButton1.Checked) await filter.SelectShadows();
        }

        private async void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (filterDialog is KritaFilterBurn filter)
                if (radioButton2.Checked) await filter.SelectMidTones();
        }

        private async void trackBar3_ValueChanged(object sender, EventArgs e)
        {
            //if (filterDialog is KritaFilterBurn filter)
            //    await filter.AdjustExposureValue(trackBar3.Value);
        }

        private async void BurnExposureMinus_Click(object sender, EventArgs e)
        {
            if (filterDialog is KritaFilterBurn filter)
            {
                var value = await filter.AdjustExposureValue(-5);
                trackBar3.Value = value;
            }
        }

        private async void BurnExposureplus_Click(object sender, EventArgs e)
        {
            if (filterDialog is KritaFilterBurn filter)
            {
                var value = await filter.AdjustExposureValue(5);
                trackBar3.Value = value;
            }
        }

        private async void bBlurActivate_Click(object sender, EventArgs e)
        {
            await ActivateFilterDialog(FilterNames.Blur);
        }

        private async void sliderBlurHorRadius_ValueChanged(object sender, EventArgs e)
        {
            if (filterDialog is KritaFilterBlur filter)
                await filter.AdjustHorizontalRadiusValue(sliderBlurHorRadius.Value);
        }

        private async void sliderBlurVerRadius_ValueChanged(object sender, EventArgs e)
        {
            if (filterDialog is KritaFilterBlur filter)
                await filter.AdjustVerticalRadiusValue(sliderBlurVerRadius.Value);
        }

        private async void sliderBlurStrength_ValueChanged(object sender, EventArgs e)
        {
            if (filterDialog is KritaFilterBlur filter)
                await filter.AdjustStrengthValue(sliderBlurStrength.Value);
        }

        private async void BlurSliderAngle_ValueChanged(object sender, EventArgs e)
        {
            if (filterDialog is KritaFilterBlur filter)
                await filter.AdjustAngle(BlurSliderAngle.Value);
        }

        private async void BlurCbShape_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (filterDialog is KritaFilterBlur filter)
                await filter.SetShape(BlurCbShape.SelectedIndex == 0 ? KritaFilterBlur.ShapeEnum.Circle : KritaFilterBlur.ShapeEnum.Rectangle);
        }

        private async void ColorBalanceActivate_Click(object sender, EventArgs e)
        {
            await ActivateFilterDialog(FilterNames.ColorBalance);
        }

        private async void ColorBalanceCyanRedShadows_ValueChanged(object sender, EventArgs e)
        {
            if (filterDialog is KritaFilterColorBalance filter)
                await filter.AdjustShadowsCyanRedValue(ColorBalanceCyanRedShadows.Value);
        }
    }
}
