using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace GUI
{
    public partial class PresetLoader : Form
    {
        public PresetLoader(List<string> presets)
        {
            InitializeComponent();
            presets.Sort();
            presetNames.Items.AddRange(presets.ToArray());
        }

        public string Selection
        {
            get { return presetNames.Text; }
        }

        private void load_Click(object sender, EventArgs e)
        {
            if (Selection == "")
            {
                MessageBox.Show("Please select a preset to load.");
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
