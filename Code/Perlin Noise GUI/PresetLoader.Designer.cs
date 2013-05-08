namespace GUI
{
    partial class PresetLoader
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.presetNames = new System.Windows.Forms.ComboBox();
            this.cancel = new System.Windows.Forms.Button();
            this.load = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // presetNames
            // 
            this.presetNames.FormattingEnabled = true;
            this.presetNames.Location = new System.Drawing.Point(12, 12);
            this.presetNames.Name = "presetNames";
            this.presetNames.Size = new System.Drawing.Size(246, 21);
            this.presetNames.Sorted = true;
            this.presetNames.TabIndex = 0;
            // 
            // cancel
            // 
            this.cancel.Location = new System.Drawing.Point(320, 12);
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(50, 21);
            this.cancel.TabIndex = 2;
            this.cancel.Text = "Cancel";
            this.cancel.UseVisualStyleBackColor = true;
            this.cancel.Click += new System.EventHandler(this.cancel_Click);
            // 
            // load
            // 
            this.load.Location = new System.Drawing.Point(264, 12);
            this.load.Name = "load";
            this.load.Size = new System.Drawing.Size(50, 21);
            this.load.TabIndex = 1;
            this.load.Text = "Load";
            this.load.UseVisualStyleBackColor = true;
            this.load.Click += new System.EventHandler(this.load_Click);
            // 
            // PresetLoader
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(382, 45);
            this.Controls.Add(this.load);
            this.Controls.Add(this.cancel);
            this.Controls.Add(this.presetNames);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "PresetLoader";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Preset Loader";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox presetNames;
        private System.Windows.Forms.Button cancel;
        private System.Windows.Forms.Button load;
    }
}