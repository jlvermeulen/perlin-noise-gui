using System;
using System.Drawing;
using System.Windows.Forms;
using PerlinNoise;

namespace GUI
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PerlinNoiseSettings settings = new PerlinNoiseSettings()
            { Intensity = 1.0f, Levels = 1, Offset = 5, RangeHandling = RangeHandling.Absolute, Resolution = 8192, Seed = 0, Threads = 8 };
            DateTime start = DateTime.Now;
            Image full = PerlinNoiseGenerator.GetImage(settings);
            DateTime end = DateTime.Now;
            Image thumb = full.GetThumbnailImage(512, 512, null, IntPtr.Zero);
            Form viewer = new ImageViewer(thumb);
            full.Save("test.png");
            viewer.Show();
            MessageBox.Show("Generated image in " + (end - start).TotalSeconds + " seconds.");
        }
    }
}