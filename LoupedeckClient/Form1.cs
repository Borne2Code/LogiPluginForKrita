using LoupedeckKritaApiClient;
using LoupedeckKritaApiClient.ClientBase;

namespace LoupedeckClient
{
    public partial class Form1 : Form
    {
        private long dpi;
        private Client? client;

        private Window? window;
        private LoupedeckKritaApiClient.View? view;
        private Canvas? canvas;

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

            //ActionList.Items.AddRange((await client.KritaInstance.Actions()).ToArray());
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
                var action = await client.KritaInstance.Action((string)ActionList.SelectedItem);
                action?.Trigger();
            }
        }
    }
}
