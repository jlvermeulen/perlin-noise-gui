using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace GUI
{
    public partial class PresetLoader : Form
    {
        internal PresetLoader(Main main)
        {
            this.InitializeComponent();
            this.presetNames.Items.AddRange(new List<string>(main.LoadPresets().Keys).ToArray());
        }

        internal string Selection { get { return this.presetNames.Text; } }

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
