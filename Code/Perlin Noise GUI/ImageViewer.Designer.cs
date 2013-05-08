namespace GUI
{
    partial class ImageViewer
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
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.progress = new System.Windows.Forms.ProgressBar();
            this.backgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.speed = new System.Windows.Forms.Label();
            this.save = new System.Windows.Forms.Button();
            this.folderBrowser = new System.Windows.Forms.FolderBrowserDialog();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox
            // 
            this.pictureBox.Location = new System.Drawing.Point(12, 12);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(512, 512);
            this.pictureBox.TabIndex = 0;
            this.pictureBox.TabStop = false;
            // 
            // progress
            // 
            this.progress.Location = new System.Drawing.Point(12, 566);
            this.progress.Name = "progress";
            this.progress.Size = new System.Drawing.Size(512, 23);
            this.progress.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progress.TabIndex = 1;
            // 
            // backgroundWorker
            // 
            this.backgroundWorker.WorkerReportsProgress = true;
            this.backgroundWorker.WorkerSupportsCancellation = true;
            this.backgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker_DoWork);
            this.backgroundWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker_ProgressChanged);
            // 
            // speed
            // 
            this.speed.AutoSize = true;
            this.speed.Location = new System.Drawing.Point(9, 539);
            this.speed.Name = "speed";
            this.speed.Size = new System.Drawing.Size(101, 13);
            this.speed.TabIndex = 2;
            this.speed.Text = "Image generated in ";
            this.speed.Visible = false;
            // 
            // save
            // 
            this.save.Enabled = false;
            this.save.Location = new System.Drawing.Point(444, 530);
            this.save.Name = "save";
            this.save.Size = new System.Drawing.Size(80, 30);
            this.save.TabIndex = 3;
            this.save.Text = "Save Image";
            this.save.UseVisualStyleBackColor = true;
            this.save.Click += new System.EventHandler(this.save_Click);
            // 
            // ImageViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(536, 601);
            this.Controls.Add(this.save);
            this.Controls.Add(this.speed);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.progress);
            this.MaximizeBox = false;
            this.Name = "ImageViewer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Image Viewer";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.ProgressBar progress;
        private System.ComponentModel.BackgroundWorker backgroundWorker;
        private System.Windows.Forms.Label speed;
        private System.Windows.Forms.Button save;
        private System.Windows.Forms.FolderBrowserDialog folderBrowser;
    }
}