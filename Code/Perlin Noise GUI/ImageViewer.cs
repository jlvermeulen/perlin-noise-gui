using System;
using System.ComponentModel;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using PerlinNoise;

namespace GUI
{
    public partial class ImageViewer : Form
    {
        private Image image;
        private DateTime generationTime;
        private double generationSpeed;

        internal ImageViewer(int fieldCount)
        {
            this.InitializeComponent();
            this.progress.Maximum = fieldCount;
            PerlinNoiseGenerator.Progress = 0;
            this.backgroundWorker.RunWorkerAsync();
        }

        internal void SetImage(Image image) { this.image = image; }

        internal void SetImageThumbnail(Image image) { this.pictureBox.Image = image; }

        internal void SetGenerationTime(DateTime dateTime) { this.generationTime = dateTime; }

        internal void SetGenerationSpeed(double speed)
        {
            this.generationSpeed = speed;
            this.speed.Text += speed.ToString("0.000") + " sec";
            this.speed.Visible = true;
        }

        internal void EnableSaveButton() { this.save.Enabled = true; }

        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            while (progress.Value < progress.Maximum)
            {
                backgroundWorker.ReportProgress(0);
                Thread.Sleep(100);
            }
        }

        private void backgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            this.progress.Step = PerlinNoiseGenerator.Progress - this.progress.Value;
            this.progress.PerformStep();
        }

        private void save_Click(object sender, EventArgs e)
        {
            if (this.folderBrowser.ShowDialog() == DialogResult.OK)
                this.image.Save(this.folderBrowser.SelectedPath + "\\" + this.generationTime.GetTimestamp() + ".png");
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            this.backgroundWorker.CancelAsync();
            base.OnClosing(e);
        }
    }
}
