using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using PerlinNoise;

namespace GUI
{
    public partial class Main : Form
    {
        private ImageViewer viewer;
        private DateTime start, end;
        private Image full, thumb;

        internal Main() { this.InitializeComponent(); }

        private void generate_Click(object sender, EventArgs e)
        {
            if (layers.Items.Count == 0)
            {
                MessageBox.Show("Please add a layer.");
                return;
            }

            int layerCount = 0;
            foreach (string l in layers.Items)
                layerCount += PerlinNoiseSettings.Parse(l).Levels;

            this.viewer = new ImageViewer((int)this.resolution.Value * layerCount);
            this.viewer.Show();
            this.backgroundWorker.RunWorkerAsync();
        }

        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            PerlinNoiseSettings[] settings = new PerlinNoiseSettings[this.layers.Items.Count];
            for (int i = 0; i < this.layers.Items.Count; i++)
                settings[i] = PerlinNoiseSettings.Parse((string)this.layers.Items[i]);

            this.start = DateTime.Now;
            this.full = PerlinNoiseGenerator.GetImage(settings, (int)this.resolution.Value, (int)this.threads.Value, (int)this.seed.Value);
            this.end = DateTime.Now;
        }

        private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.thumb = this.full.GetThumbnailImage(512, 512, null, IntPtr.Zero);
            this.viewer.SetImage(this.full);
            this.viewer.SetImageThumbnail(this.thumb);

            this.viewer.SetGenerationTime(this.end);
            this.viewer.SetGenerationSpeed((this.end - this.start).TotalSeconds);

            this.viewer.EnableSaveButton();
        }

        private void resolution_Validated(object sender, EventArgs e)
        {
            double exp = Math.Log((double)this.resolution.Value, 2);

            int exp1 = (int)Math.Floor(exp);
            int exp2 = (int)Math.Ceiling(exp);

            int val1 = (int)Math.Pow(2, exp1);
            int val2 = (int)Math.Pow(2, exp2);

            decimal diff1 = Math.Abs(this.resolution.Value - val1);
            decimal diff2 = Math.Abs(this.resolution.Value - val2);

            if (diff1 <= diff2)
                this.resolution.Value = val1;
            else
                this.resolution.Value = val2;
        }

        private void add_Click(object sender, EventArgs e)
        {
            this.layers.Items.Add
                (
                    this.intensity.Value.ToString("0.00", CultureInfo.CreateSpecificCulture("en-GB")) + ", " +
                    this.levels.Value + ", " +
                    this.offset.Value + ", " +
                    this.rangeHandling.Text + ", " +
                    this.highlightRed.Value + ", " +
                    this.highlightGreen.Value + ", " +
                    this.highlightBlue.Value + ", " +
                    this.shadowRed.Value + ", " +
                    this.shadowGreen.Value + ", " +
                    this.shadowBlue.Value + ", " +
                    this.wrap.Checked + ", " +
                    this.channelWrap.Checked
                );
        }

        private void delete_Click(object sender, EventArgs e)
        {
            ListBox.SelectedIndexCollection selection = this.layers.SelectedIndices;
            List<int> indices = new List<int>();
            foreach (int s in selection)
                indices.Add(s);
            indices.Sort();

            for (int i = indices.Count - 1; i >= 0; i--)
                this.layers.Items.RemoveAt(indices[i]);
        }

        private void offset_ValueChanged(object sender, EventArgs e)
        {
            if (this.offset.Value + this.levels.Value > 11)
                this.offset.Value--;
        }

        private void levels_ValueChanged(object sender, EventArgs e)
        {
            if (this.offset.Value + this.levels.Value > 11)
                this.levels.Value--;
        }

        private void save_Click(object sender, EventArgs e)
        {
            if (this.layers.Items.Count == 0)
            {
                MessageBox.Show("A preset needs at least one layer.", "No layers", MessageBoxButtons.OK);
                return;
            }

            SortedDictionary<string, List<string>> presets = this.LoadPresets();
            PresetSaver presetSaver = new PresetSaver(this);

            if (presetSaver.ShowDialog() == DialogResult.OK)
            {
                presets[presetSaver.PresetName] = null;

                List<string> presetLayers = new List<string>();
                foreach (object o in layers.Items)
                    presetLayers.Add((string)o);

                presets[presetSaver.PresetName] = presetLayers;
                this.SavePresets(presets);
            }
        }

        private void load_Click(object sender, EventArgs e)
        {
            SortedDictionary<string, List<string>> presets = this.LoadPresets();
            PresetLoader presetLoader = new PresetLoader(this);

            if (presetLoader.ShowDialog() == DialogResult.OK)
            {
                this.layers.Items.Clear();
                this.layers.Items.AddRange(presets[presetLoader.Selection].ToArray());
            }

            this.layers.ClearSelected();
        }

        internal SortedDictionary<string, List<string>> LoadPresets()
        {
            if (!File.Exists("Presets.txt"))
                File.Create("Presets.txt").Close();

            StreamReader reader = new StreamReader("Presets.txt");
            SortedDictionary<string, List<string>> presets = new SortedDictionary<string, List<string>>();
            string name, layer;
            List<string> presetLayers;

            while ((name = reader.ReadLine()) != null)
            {
                presetLayers = new List<string>();
                while ((layer = reader.ReadLine()) != "#")
                    presetLayers.Add(layer);
                presets.Add(name.Remove(0, 1), presetLayers);
            }

            reader.Close();
            return presets;
        }

        internal void SavePresets(SortedDictionary<string, List<string>> presets)
        {
            StreamWriter writer = new StreamWriter("Presets.txt", false);
            foreach (KeyValuePair<string, List<string>> kvp in presets)
            {
                writer.WriteLine("#" + kvp.Key);
                foreach (string layer in kvp.Value)
                    writer.WriteLine(layer);
                writer.WriteLine("#");
            }
            writer.Close();
        }

        internal void RestoreDefaultPresets()
        {
            StreamReader reader = new StreamReader(Assembly.GetExecutingAssembly().GetManifestResourceStream("GUI.DefaultPresets.txt"));
            SortedDictionary<string, List<string>> presets = this.LoadPresets();
            string name, layer;
            List<string> presetLayers;

            while ((name = reader.ReadLine()) != null)
            {
                presetLayers = new List<string>();
                while ((layer = reader.ReadLine()) != "#")
                    presetLayers.Add(layer);
                name = name.Remove(0, 1);
                presets[name] = presetLayers;
            }

            reader.Close();
            this.SavePresets(presets);
        }

        private void manage_Click(object sender, EventArgs e) { new PresetManager(this).ShowDialog(); }

        private void wrap_CheckedChanged(object sender, EventArgs e) { this.channelWrap.Enabled = !this.channelWrap.Enabled; }

        private void clear_Click(object sender, EventArgs e) { this.layers.Items.Clear(); }
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

    public static class Extensions { public static string GetTimestamp(this DateTime value) { return value.ToString("yyyyMMdd_HHmmssfff"); } }
}