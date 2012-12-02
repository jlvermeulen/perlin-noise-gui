using System;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using PerlinNoise;
using System.Collections.Generic;

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
            if (layers.Items.Count == 0)
            {
                MessageBox.Show("Please add a layer.");
                return;
            }
            PerlinNoiseSettings[] settings = new PerlinNoiseSettings[layers.Items.Count];
            for(int i = 0; i < layers.Items.Count; i++)
                settings[i] = PerlinNoiseGenerator.ParseSettings((string)layers.Items[i]);
            DateTime start = DateTime.Now;
            Image full = PerlinNoiseGenerator.GetImage(settings);
            DateTime end = DateTime.Now;
            full.Save("test.png");
            Image thumb = full.GetThumbnailImage(512, 512, null, IntPtr.Zero);
            Form viewer = new ImageViewer(thumb);
            viewer.Show();
            MessageBox.Show("Generated image in " + (end - start).TotalSeconds + " seconds.");
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

        private void add_Click(object sender, EventArgs e)
        {
            layers.Items.Add
                (
                    resolution.Value + ", " +
                    intensity.Value + ", " +
                    levels.Value + ", " +
                    offset.Value + ", " +
                    rangeHandling.Text + ", " +
                    highlightRed.Value + ", " +
                    highlightGreen.Value + ", " +
                    highlightBlue.Value + ", " +
                    shadowRed.Value + ", " +
                    shadowGreen.Value + ", " +
                    shadowBlue.Value + ", " +
                    wrap.Checked + ", " +
                    seed.Value + ", " +
                    threads.Value
                );
        }

        private void delete_Click(object sender, EventArgs e)
        {
            ListBox.SelectedIndexCollection selection = layers.SelectedIndices;
            List<int> indices = new List<int>();
            foreach (int s in selection)
                indices.Add(s);
            indices.Sort();

            for (int i = indices.Count - 1; i >= 0; i--)
                layers.Items.RemoveAt(indices[i]);
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