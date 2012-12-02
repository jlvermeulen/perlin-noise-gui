using System;
using System.ComponentModel;
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

        private void generate_Click(object sender, EventArgs e)
        {
            PerlinNoiseSettings settings = new PerlinNoiseSettings()
            {
                Intensity = (float)intensity.Value,
                Levels = (int)levels.Value,
                Offset = (int)offset.Value,
                RangeHandling = (RangeHandling)Enum.Parse(typeof(RangeHandling), rangeHandling.Text),
                Resolution = (int)resolution.Value,
                Seed = (int)seed.Value,
                Highlight = Color.FromArgb((byte)highlightRed.Value, (byte)highlightGreen.Value, (byte)highlightBlue.Value),
                Shadow = Color.FromArgb((byte)shadowRed.Value, (byte)shadowGreen.Value, (byte)shadowBlue.Value),
                Threads = (int)threads.Value
            };
            DateTime start = DateTime.Now;
            Image full = PerlinNoiseGenerator.GetImage(settings);
            DateTime end = DateTime.Now;
            full.Save("test.png");
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

        private void resolution_Validated(object sender, EventArgs e)
        {
            double exp = Math.Log((double)resolution.Value, 2);
            int exp1 = (int)Math.Floor(exp);
            int exp2 = (int)Math.Ceiling(exp);
            int val1 = (int)Math.Pow(2, exp1);
            int val2 = (int)Math.Pow(2, exp2);
            decimal diff1 = Math.Abs(resolution.Value - val1);
            decimal diff2 = Math.Abs(resolution.Value - val2);
            if (diff1 <= diff2)
                resolution.Value = val1;
            else
                resolution.Value = val2;
        }
    }

    public class ResolutionUpDown : NumericUpDown
    {
        public override void UpButton()
        {
            decimal val = this.Value * 2;
            if (val > this.Maximum)
                this.Value = this.Maximum;
            else
                this.Value = val;
        }

        public override void DownButton()
        {
            decimal val = this.Value / 2;
            if (val < this.Minimum)
                this.Value = this.Minimum;
            else
                this.Value = val;
        }
    }
}