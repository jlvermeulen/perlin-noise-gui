using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace GUI
{
    public partial class PresetSaver : Form
    {
        Main main;

        public PresetSaver(Main main)
        {
            InitializeComponent();
            this.main = main;
        }

        public string PresetName
        {
            get { return presetName.Text; }
        }

        private void save_Click(object sender, EventArgs e)
        {
            SortedDictionary<string, List<string>> presets = main.LoadPresets();
            if (presetName.Text == "")
            {
                MessageBox.Show("Please enter a name for the preset.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (presets.ContainsKey(presetName.Text))
            {
                DialogResult result = MessageBox.Show("A preset by that name already exists.\nDo you want to overwrite it?", "Overwrite?", MessageBoxButtons.YesNo, MessageBoxIcon.None, MessageBoxDefaultButton.Button2);
                if (result == DialogResult.No)
                    return;
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}