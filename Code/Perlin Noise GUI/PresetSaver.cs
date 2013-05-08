using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace GUI
{
    public partial class PresetSaver : Form
    {
        private Main main;

        internal PresetSaver(Main main)
        {
            this.InitializeComponent();
            this.main = main;
        }

        internal string PresetName { get { return this.presetName.Text; } }

        private void save_Click(object sender, EventArgs e)
        {
            SortedDictionary<string, List<string>> presets = this.main.LoadPresets();

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