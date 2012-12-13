using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using PerlinNoise;

namespace GUI
{
    public partial class ImageViewer : Form
    {
        Image image;
        DateTime generationTime;
        double generationSpeed;

        public ImageViewer(int fieldCount)
        {
            InitializeComponent();
            progress.Maximum = fieldCount;
            backgroundWorker.RunWorkerAsync();
        }

        public void SetImage(Image image)
        {
            this.image = image;
        }

        public void SetImageThumbnail(Image image)
        {
            this.pictureBox.Image = image;
        }

        public void HideProgressBar()
        {
            this.progress.Enabled = false;
            this.progress.Visible = false;
        }

        public void SetGenerationTime(DateTime dateTime)
        {
            this.generationTime = dateTime;
        }

        public void SetGenerationSpeed(double speed)
        {
            this.generationSpeed = speed;
            this.speed.Text += speed.ToString("0.000") + " sec";
            this.speed.Visible = true;
        }

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
            progress.Step = PerlinNoiseGenerator.GetProgress() - progress.Value;
            progress.PerformStep();
        }
    }
}
