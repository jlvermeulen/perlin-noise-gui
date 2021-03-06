﻿using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace GUI
{
    public partial class PresetManager : Form
    {
        private Main main;

        internal PresetManager(Main main)
        {
            this.InitializeComponent();
            this.main = main;
            this.presetNames.Items.AddRange(new List<string>(main.LoadPresets().Keys).ToArray());
            this.CancelButton = this.close;
        }

        private void delete_Click(object sender, EventArgs e)
        {
            SortedDictionary<string, List<string>> presets = main.LoadPresets();
            if (MessageBox.Show("Delete selected presets permanently?", "Delete presets", MessageBoxButtons.YesNo) == DialogResult.Yes)
                foreach (string name in presetNames.SelectedItems)
                    presets.Remove(name);

            this.main.SavePresets(presets);
            this.presetNames.Items.Clear();
            this.presetNames.Items.AddRange(new List<string>(presets.Keys).ToArray());
        }

        private void restore_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Restore original presets to their default values?\nThis will not affect presets defined under a custom name.", "Restore default presets", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                this.main.RestoreDefaultPresets();
                SortedDictionary<string, List<string>> presets = main.LoadPresets();
                this.presetNames.Items.Clear();
                this.presetNames.Items.AddRange(new List<string>(presets.Keys).ToArray());
            }
        }

        private void close_Click(object sender, EventArgs e) { this.Close(); }
    }
}
