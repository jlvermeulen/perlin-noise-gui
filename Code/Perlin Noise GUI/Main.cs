using System;
using System.Collections.Generic;
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
            Image full = PerlinNoiseGenerator.GetImage(settings, (int)resolution.Value, (int)threads.Value, (int)seed.Value);
            DateTime end = DateTime.Now;
            full.Save("test.png");
            Image thumb = full.GetThumbnailImage(512, 512, null, IntPtr.Zero);
            ImageViewer viewer = new ImageViewer(thumb);
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
                    intensity.Value.ToString("0.00", CultureInfo.CreateSpecificCulture("en-GB")) + ", " +
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
                    channelWrap.Checked
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

        private void offset_ValueChanged(object sender, EventArgs e)
        {
            if (offset.Value + levels.Value > 11)
                offset.Value--;
        }

        private void levels_ValueChanged(object sender, EventArgs e)
        {
            if (offset.Value + levels.Value > 11)
                levels.Value--;
        }

        private void save_Click(object sender, EventArgs e)
        {
            if (layers.Items.Count == 0)
            {
                MessageBox.Show("A preset needs at least one layer.", "No layers", MessageBoxButtons.OK);
                return;
            }
            SortedDictionary<string, List<string>> presets = LoadPresets();
            PresetSaver presetSaver = new PresetSaver(this);
            DialogResult result = presetSaver.ShowDialog();
            if (result == DialogResult.OK)
            {
                if (presets.ContainsKey(presetSaver.PresetName))
                    presets[presetSaver.PresetName] = null;
                else
                    presets.Add(presetSaver.PresetName, null);
                List<string> presetLayers = new List<string>();
                foreach (object o in layers.Items)
                    presetLayers.Add((string)o);
                presets[presetSaver.PresetName] = presetLayers;
                SavePresets(presets);
            }
        }

        private void load_Click(object sender, EventArgs e)
        {
            SortedDictionary<string, List<string>> presets = LoadPresets();
            PresetLoader presetLoader = new PresetLoader(this);
            DialogResult result = presetLoader.ShowDialog();
            if (result == DialogResult.OK)
            {
                layers.Items.Clear();
                layers.Items.AddRange(presets[presetLoader.Selection].ToArray());
            }
            layers.ClearSelected();
        }

        public SortedDictionary<string, List<string>> LoadPresets()
        {
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

        public void SavePresets(SortedDictionary<string, List<string>> presets)
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

        public void RestoreDefaultPresets()
        {
            StreamReader reader = new StreamReader(Assembly.GetExecutingAssembly().GetManifestResourceStream("GUI.DefaultPresets.txt"));
            SortedDictionary<string, List<string>> presets = LoadPresets();
            string name, layer;
            List<string> presetLayers;
            while ((name = reader.ReadLine()) != null)
            {
                presetLayers = new List<string>();
                while ((layer = reader.ReadLine()) != "#")
                    presetLayers.Add(layer);
                name = name.Remove(0, 1);
                if (presets.ContainsKey(name))
                    presets[name] = presetLayers;
                else
                    presets.Add(name, presetLayers);
            }
            reader.Close();
            SavePresets(presets);
        }

        private void manage_Click(object sender, EventArgs e)
        {
            PresetManager manager = new PresetManager(this);
            manager.ShowDialog();
        }

        private void wrap_CheckedChanged(object sender, EventArgs e)
        {
            channelWrap.Enabled = !channelWrap.Enabled;
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