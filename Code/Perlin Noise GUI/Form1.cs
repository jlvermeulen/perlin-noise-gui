using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PerlinNoise;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.IO;

namespace Perlin_Noise_GUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = PerlinNoiseGenerator.GetImage();
        }
    }
}
