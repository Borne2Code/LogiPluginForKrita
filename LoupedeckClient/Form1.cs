using LoupedeckKritaApiClient.ClientBase;

namespace LoupedeckClient
{
    public partial class Form1 : Form
    {
        private long dpi;
        private Client client;

        public Form1()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            //await client.ExecuteCall("currentCanvas", "setZoomLevel", 1.0f);
            await client.CurrentCanvas.SetZoomLevel(1);
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            //var zoomLevel = (double)(await client.ExecuteCall("currentCanvas", "zoomLevel")).Value;

            //var zoom = (int)(zoomLevel * 72 / dpi * 100);
            //label1.Text = zoom.ToString();
            //trackBar1.Value = zoom;
            trackBar1.Value = (int)(await client.CurrentCanvas.GetZoomLevel() * 7200 / dpi);
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            client = new Client();
            await client.Connect();

            dpi = await client.CurrentDocument.GetResolution();
            trackBar1.Value = (int)(await client.CurrentCanvas.GetZoomLevel() * 75 * 100 / dpi);
            trackBar2.Value = (int)(await client.CurrentCanvas.GetRotation());
            //dpi = (long)(await client.ExecuteCall("currentDocument", "resolution")).Value;
            //var zoomLevel = (double)(await client.ExecuteCall("currentCanvas", "zoomLevel")).Value;
            //var rotation = (double)(await client.ExecuteCall("currentCanvas", "rotation")).Value;

            //var zoom = (int)(zoomLevel * 72 / dpi * 100);
            //label1.Text = zoom.ToString();

            //isRunning = true;
            //trackBar1.Value = zoom;
            //trackBar2.Value = (int)rotation;
            //isRunning = false;
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
                    await client.CurrentCanvas.SetZoomLevel((float)trackBar1.Value / 100);
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
            //var rotation = (double)(await client.ExecuteCall("currentCanvas", "rotation")).Value;
            trackBar2.Value = (int)(await client.CurrentCanvas.GetRotation());
        }

        private async void trackBar2_ValueChanged(object sender, EventArgs e)
        {
            if (!isRunning)
            {
                try
                {
                    isRunning = true;
                    await client.CurrentCanvas.SetRotation(trackBar2.Value);
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

        private async void button4_Click(object sender, EventArgs e)
        {
            await client.CurrentCanvas.SetRotation(0);
        }
    }
}
