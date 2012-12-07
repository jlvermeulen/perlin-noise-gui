using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace GUI
{
    public partial class PresetSaver : Form
    {
        List<string> keys;

        public PresetSaver(Dictionary<string, List<string>>.KeyCollection keys)
        {
            InitializeComponent();
            this.keys = new List<string>(keys);
        }

        public string PresetName
        {
            get { return presetName.Text; }
        }

        private void save_Click(object sender, EventArgs e)
        {
            if (presetName.Text == "")
            {
                MessageBox.Show("Please enter a name for the preset.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (keys.Contains(presetName.Text))
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