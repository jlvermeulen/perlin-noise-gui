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
            { Intensity = 1.0f, Levels = 1, Offset = 5, RangeHandling = RangeHandling.Absolute, Resolution = 8192, Seed = 0, Highlight = Color.White, Shadow = Color.Black, Threads = 8 };
            DateTime start = DateTime.Now;
            Image full = PerlinNoiseGenerator.GetImage(settings);
            DateTime end = DateTime.Now;
            Image thumb = full.GetThumbnailImage(512, 512, null, IntPtr.Zero);
            Form viewer = new ImageViewer(thumb);
            viewer.Show();
            MessageBox.Show("Generated image in " + (end - start).TotalSeconds + " seconds.");
            //start = DateTime.Now;
            //Image full2 = PerlinNoiseGenerator.GetImage2(settings);
            //end = DateTime.Now;
            //Image thumb2 = full.GetThumbnailImage(512, 512, null, IntPtr.Zero);
            //Form viewer2 = new ImageViewer(thumb2);
            //viewer2.Show();
            //MessageBox.Show("Generated image in " + (end - start).TotalSeconds + " seconds.");
        }
    }
}