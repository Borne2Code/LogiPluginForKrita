using LoupedeckKritaApiClient;
using LoupedeckKritaApiClient.ClientBase;

namespace LoupedeckClient
{
    public partial class Form1 : Form
    {
        private long dpi;
        private Client client;

        private Window window;
        private LoupedeckKritaApiClient.View view;
        private Canvas canvas;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            trackBar1.Value = 100;
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            trackBar1.Value = (int)(await canvas.ZoomLevel() * 7200 / dpi);
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            client = new Client();
            await client.Connect();

            var activeDocument = await client.KritaInstance.ActiveDocument();
            dpi = await activeDocument.GetResolution();
            window = await client.KritaInstance.ActiveWindow();
            view = await window.ActiveView();
            canvas = await view.CurrentCanvas();
            trackBar1.Value = (int)(await canvas.ZoomLevel() * 75 * 100 / dpi);
            trackBar2.Value = (int)(await canvas.Rotation());

            var response = await client.KritaInstance.Filters();
            label1.Text = string.Join(',', response);
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {

        }

        bool isRunning = false;
        private async void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            if (!isRunning)
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

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            client.Dispose();
        }

        private async void button3_Click(object sender, EventArgs e)
        {
            trackBar2.Value = (int)(await canvas.Rotation());
        }

        private async void trackBar2_ValueChanged(object sender, EventArgs e)
        {
            if (!isRunning)
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

        private void button4_Click(object sender, EventArgs e)
        {
            trackBar2.Value = 0;
        }
    }
}
