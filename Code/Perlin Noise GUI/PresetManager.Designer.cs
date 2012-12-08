namespace GUI
{
    partial class PresetManager
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
            this.presetNames = new System.Windows.Forms.CheckedListBox();
            this.delete = new System.Windows.Forms.Button();
            this.restore = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // presetNames
            // 
            this.presetNames.CheckOnClick = true;
            this.presetNames.FormattingEnabled = true;
            this.presetNames.Location = new System.Drawing.Point(12, 12);
            this.presetNames.Name = "presetNames";
            this.presetNames.Size = new System.Drawing.Size(268, 244);
            this.presetNames.Sorted = true;
            this.presetNames.TabIndex = 0;
            // 
            // delete
            // 
            this.delete.Location = new System.Drawing.Point(286, 12);
            this.delete.Name = "delete";
            this.delete.Size = new System.Drawing.Size(100, 26);
            this.delete.TabIndex = 1;
            this.delete.Text = "Delete selected";
            this.delete.UseVisualStyleBackColor = true;
            this.delete.Click += new System.EventHandler(this.delete_Click);
            // 
            // restore
            // 
            this.restore.Location = new System.Drawing.Point(286, 44);
            this.restore.Name = "restore";
            this.restore.Size = new System.Drawing.Size(100, 26);
            this.restore.TabIndex = 2;
            this.restore.Text = "Restore defaults";
            this.restore.UseVisualStyleBackColor = true;
            this.restore.Click += new System.EventHandler(this.restore_Click);
            // 
            // PresetManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(398, 268);
            this.Controls.Add(this.restore);
            this.Controls.Add(this.delete);
            this.Controls.Add(this.presetNames);
            this.Name = "PresetManager";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Preset Manager";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckedListBox presetNames;
        private System.Windows.Forms.Button delete;
        private System.Windows.Forms.Button restore;
    }
}